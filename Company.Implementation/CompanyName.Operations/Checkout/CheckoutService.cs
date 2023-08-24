using AtlConsultingIo.IntegrationOperations;

using AutoMapper;

using CompanyName.Core.Entities;
using CompanyName.Core.Entities.Messaging;
using CompanyName.Core.Entities.Order;
using CompanyName.Core.Entities.Product;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;
using CompanyName.Core.Integrations.KountApi;
using CompanyName.Operations.Account;

using FluentValidation;
using FluentValidation.Results;

using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using ExigoOrderType = CompanyName.Core.Integrations.Exigo.Rest.OrderType;


namespace CompanyName.Operations.Checkout;

public class CheckoutService : ICheckoutService
{
    private ExigoConfiguration.CheckoutSettings _settings 
        => _exigoOptionsMonitor?.CurrentValue.Checkout ?? ExigoConfiguration.CheckoutSettings.Instance;

    private readonly ILogger _logger;
    private readonly IDistributedCache _cache;

    private readonly IValidator<AccountRegistration> _registrationValidator;
    private readonly IValidator<ShoppingCartOrder> _orderValidator;

    private readonly IMapper _mapper;

    private readonly IOptionsMonitor<CheckoutServiceConfiguration.Options> _serviceOptions;
    private readonly IOptionsMonitor<ExigoConfiguration>? _exigoOptionsMonitor;
    private readonly IIntegrationsService _integrations;

    private BusinessRules _businessRules => _serviceOptions.CurrentValue.Rules;
    public CheckoutService(
            IValidator<AccountRegistration> registrationValidator, 
            IValidator<ShoppingCartOrder> orderValidator,
            IMapper domainMapper,
            IDistributedCache appCache ,
            IIntegrationsService integrationsService ,
            IOptionsMonitor<CheckoutServiceConfiguration.Options> serviceOptions ,
            IOptionsMonitor<ExigoConfiguration> exigoOptions,
            ILogger appLogger
        )
    {
        _registrationValidator = registrationValidator;
        _orderValidator = orderValidator;

        _integrations = integrationsService;
        _mapper = domainMapper;

        _cache = appCache;
        _logger = appLogger;

        _serviceOptions = serviceOptions;
        _exigoOptionsMonitor = exigoOptions;
    }

    public CheckoutService( IValidator<AccountRegistration> registrationValidator ,
            IValidator<ShoppingCartOrder> orderValidator ,
            IMapper domainMapper ,
            IDistributedCache appCache ,
            IIntegrationsService integrationsService ,
            IOptionsMonitor<CheckoutServiceConfiguration.Options> serviceOptions ,
            ILogger appLogger )
    {
        _registrationValidator = registrationValidator;
        _orderValidator = orderValidator;

        _integrations = integrationsService;
        _mapper = domainMapper;

        _cache = appCache;
        _logger = appLogger;

        _serviceOptions = serviceOptions;
    }

    public async Task<CheckoutState> CompleteCheckout( CheckoutRequest request , CancellationToken cancellationToken )
    {
        CheckoutRequest _request = SetExigoDefaults( request );
        CheckoutState _state = new( request.CartId );

        try
        {
            if ( _request.CartId.IsNullOrDefault )
            {
                _state = _state with { ProcessingError = new UIDisplayString ( CheckoutErrors.EmptyCartID ) };
                if ( _serviceOptions.CurrentValue.SaveOnInvalidCartIdError )
                    await SaveState ( _state , cancellationToken );

                return _state;
            };

            EnsureOrderNotExists orderCheck = new ( _state.OperationContextID, _state.CartID, _integrations );
            orderCheck = await orderCheck.ExecuteAsync ( cancellationToken ).ConfigureAwait ( false );
            if ( orderCheck.Result.HasValue )
            {
                _state = _state with { ProcessingError = new UIDisplayString ( CheckoutErrors.OrderExists ( orderCheck.Result.Value , _state.CartID ) ) };
                if ( _serviceOptions.CurrentValue.SaveOnDuplicateError )
                    await SaveState ( _state , cancellationToken );

                return _state;
            }

            GetOrAddCartProcessingLock addLock = new( _request, _cache, _serviceOptions.CurrentValue.CacheOptions );
            addLock = await addLock.ExecuteAsync ( cancellationToken ).ConfigureAwait ( false );
            if ( addLock.ExistingLock is not null )
            {
                _state = _state with { ProcessingError = new UIDisplayString ( CheckoutErrors.DuplicateRequest ( _state.CartID ) ) };
                if ( _serviceOptions.CurrentValue.SaveOnDuplicateError )
                    await SaveState ( _state , cancellationToken );

                return _state;
            }

            _state = await SetContext ( _request , _state , cancellationToken );

            if ( _state.Context.IsGuestCart )
                _request = await AddGuestAccount ( _state.OperationContextID , _request , cancellationToken );

            _state = ValidateRequest ( _request , _state );
            if ( _state.ProcessingError.HasValue )
            {
                if( _serviceOptions.CurrentValue.SaveOnValidationError )
                    await SaveState ( _state , cancellationToken );
                return _state;
            }

            if ( _request.PointPaymentAmount > 0 )
            {
                _state = await CreatePointPaymentTransactions (
                    _request.UserId ,
                    _request.CartId ,
                    _request.PointPaymentAmount ,
                    _state ,
                    cancellationToken );

                if ( _state.ProcessingError.HasValue )
                {
                    if( _serviceOptions.CurrentValue.SaveOnPointTransactionError || ( _state.Context.PointTransactions?.Any() ?? false ) )
                        await SaveState ( _state , cancellationToken ).ConfigureAwait ( false );
                    return _state;
                }
            }

            var operationResult = InitializeExigoOperation( request, _state);
            if( operationResult.Error.HasValue )
            {
                _state = _state with { ProcessingError = operationResult.Error.Value } ;
                await SaveState( _state, cancellationToken ).ConfigureAwait ( false );
                return _state;
            }

            var transaction = await operationResult.Operation.ExecuteAsync ( cancellationToken ).ConfigureAwait ( false );  

            _state = _state with
            {
                Result = transaction.Result ,
                ProcessingError = transaction.OperationError.HasValue ( ) ? new UIDisplayString ( new ExigoApiError() ) : null
            };

            await SaveState ( _state , cancellationToken );
        }
        catch ( Exception err )
        {
            _state = _state with { ProcessingError = new UIDisplayString( CheckoutErrors.Unknown( _state.CartID ) )};
            _logger.LogCritical( err, "Unhandled exception thrown processing CartID: {0}", _state.CartID.Value );
        }

        return _state;
    }



    private async Task<CheckoutState> SetContext( CheckoutRequest request , CheckoutState state, CancellationToken cancellationToken )
    {
        TotalLifePriceType priceType = request.PriceType;
        ICompanyAccountType? accountType =
            ICompanyAccountType.Values
            .FirstOrDefault( i => i.PriceTypes.Any( pt => pt.TypeID.Equals(priceType.TypeID)   || pt.CommerceCloudApiKey.Equals( priceType.CommerceCloudApiKey) )  );

        var businessRules = _serviceOptions.CurrentValue.Rules;
        var context = new CheckoutContext
        {
            IsGuestCart = request.CartOrder.CustomerID == 0 && request.CartOrder.CheckoutSite.HasValue,
            IsHighDollarCart = request.CartOrder.CartTotal >= businessRules.SalesOrderRules.HighRiskTotalThreshold,
            IsEnrollmentCart = businessRules.RegistrationRules.EnrollmentAccountTypeFilter.Contains ( request.AccountRegistration?.CustomerType ?? 0 ),
            AccountType = accountType ?? new RetailCustomerAccount(),
            PaymentContext = GetPaymentProperties( request ),
            SmartshipContext = GetSmartshipProperties( request.CartOrder ),
            ProductContext = await GetProductProperties( request.CartOrder, cancellationToken )
        };

        if( request.AccountRegistration is AccountRegistration _registration )
            context = context with { SignupContext = GetRegistrationProperties( _registration , request ) };

        return state with { Context = context };
    }
    private CheckoutContext.RegistrationProperties GetRegistrationProperties( AccountRegistration registration , CheckoutRequest request )
    {
        PhoneNumber contactPhone = !string.IsNullOrEmpty( registration.Phone )
                                        ? PhoneNumber.Parse( registration.Phone )
                                            : !string.IsNullOrEmpty( registration.MobilePhone )
                                                ? PhoneNumber.Parse( registration.MobilePhone )
                                                : PhoneNumber.Parse( registration.Phone2 );

        string? shirtSize = request.ContextData.TryGetValue( CheckoutContextKeys.AffiliateShirtSize, out var obj) && obj is string _str && _str.Length > 0 ? _str : null;

        return new CheckoutContext.RegistrationProperties
        {
            EmailContact = new ContactEmail ( )
            {
                EmailAddress = new EmailAddress ( registration.Email ) ,
                IsSubscribed = registration.HasEmailOptIn ? Enabled.True : Enabled.False
            } ,
            PhoneContact = new ContactPhoneNumber
            {
                PhoneNumber = contactPhone ,
                IsSubscribed = registration.HasSmsOptIn ? Enabled.True : Enabled.False
            } ,
            ShirtSize = shirtSize 
        };
    }
    private CheckoutContext.PaymentProperties GetPaymentProperties( CheckoutRequest request )
    {
        var properties = new CheckoutContext.PaymentProperties();
        if( request.GiftCardPaymentAmount > 0 )
        {
            GiftCardInfo? info = request.TryGetContextValue<GiftCardInfo>( CheckoutContextKeys.GiftCardPaymentInfo );

            properties = properties with
            {
                GiftCardRedemption = new GiftCardPayment( request.CartId, request.GiftCardPaymentAmount, info )
                {
                    UserId = request.UserId.IsDefault ? null : request.UserId
                } ,
            };
        }

        RiskTransactionResponse? riskResponse = request.TryGetContextValue<RiskTransactionResponse>( CheckoutContextKeys.RiskInquiryResponse );
        return properties with { RiskInquiryResponse = riskResponse };
    }
    private async Task<CheckoutContext.ProductProperties> GetProductProperties( ShoppingCartOrder cartOrder , CancellationToken cancellationToken )
    {
        var orderItems = cartOrder.Details.Select( i => i.ItemCode )?.ToList();
        if( orderItems is null || !orderItems.Any() )
            return new CheckoutContext.ProductProperties();

        var getCbdItems = new GetCbdItemsFromCacheOrSource( _integrations, _cache, _serviceOptions.CurrentValue.CacheOptions );
        getCbdItems = await getCbdItems.ExecuteAsync( cancellationToken ).ConfigureAwait(false);

        var getEnrollmentItems = new GetEnrollmentKitsFromCacheOrSource(_integrations, _cache, _serviceOptions.CurrentValue.CacheOptions);
        getEnrollmentItems = await getEnrollmentItems.ExecuteAsync( cancellationToken );

        List<CbdItemCode> cbdItems = getCbdItems.Result ?? new ();
        List<EnrollmentKitItemCode> kitItems = getEnrollmentItems.Result ?? new ();
        return new CheckoutContext.ProductProperties
        {
            CbdItemCount = orderItems.Intersect( cbdItems.Select( i => i.Value)).Count(),
            EnrollmentKitItemCount = orderItems.Intersect( kitItems.Select( i => i.Value) ).Count(),
            GiftCardItemCount = orderItems.Intersect( _serviceOptions.CurrentValue.Rules.SalesOrderRules.GiftCardItemsFilter ).Count(),
        };
    }
    private CheckoutContext.SmartshipProperties GetSmartshipProperties( ShoppingCartOrder cartOrder )
    {
        if( !cartOrder.SmartshipItems.Any() )
            return new CheckoutContext.SmartshipProperties();

        var startCalculator = new CalculateSmartshipDate( cartOrder.SelectedSmartshipDay.GetValueOrDefault().Value,  _serviceOptions.CurrentValue.Rules.SmartshipRules );
        return new CheckoutContext.SmartshipProperties
        {
            SmartshipStartDate = CalculateSmartshipDate.Execute( startCalculator ),
            SmartshipItems = cartOrder.SmartshipItems,
        };
    }


    public CheckoutState ValidateRequest ( CheckoutRequest request, CheckoutState state  )
    {
        state = ValidateOrder( request.CartOrder, state );
        if( state.ProcessingError.HasValue || request.AccountRegistration is null )
            return state;

        return ValidateAccount( request.AccountRegistration, state );
    }
    private CheckoutState ValidateOrder( ShoppingCartOrder order, CheckoutState state )
    {
        var ctx =  new ValidationContext<ShoppingCartOrder>( order );
        ctx.RootContextData[ ValidationContextKeys.Context ] = state.Context;
        ctx.RootContextData[ ValidationContextKeys.AccountRules ] = _businessRules.RegistrationRules;

        if ( _exigoOptionsMonitor is not null )
            ctx.RootContextData[ ValidationContextKeys.ExigoConfiguration ] = _exigoOptionsMonitor.CurrentValue;

        ValidationResult result = _orderValidator.Validate( ctx );
        return result.IsValid ? state : state with { ProcessingError = new UIDisplayString( result.ToString() ) };
    }
    private CheckoutState ValidateAccount( AccountRegistration account, CheckoutState state )
    {
        var ctx =  new ValidationContext<AccountRegistration>( account );
        ctx.RootContextData[ ValidationContextKeys.Context ] = state.Context;
        ctx.RootContextData[ ValidationContextKeys.AccountRules ] = _businessRules.RegistrationRules;

        if ( _exigoOptionsMonitor is not null )
            ctx.RootContextData[ ValidationContextKeys.ExigoConfiguration ] = _exigoOptionsMonitor.CurrentValue;

        ValidationResult result = _registrationValidator.Validate( ctx );
        return result.IsValid ? state : state with { ProcessingError = new UIDisplayString ( result.ToString ( ) ) };
    }

    private async Task<CheckoutRequest> AddGuestAccount( OperationContextID contextID, CheckoutRequest request , CancellationToken cancellationToken )
    {
        GuestAccountSearchParams searchParams = new()
        {
            PhoneNumber = PhoneNumber.Parse( request.CartOrder.Phone ),
            EmailAddress = new( request.CartOrder.Email ),
            CheckoutSiteAlias = request.CartOrder.CheckoutSite?.SiteAlias ?? WebAlias.Default
        };

        GuestAccountMatch? match = await GuestAccountSqlSearch.Execute( 
                new GuestAccountSqlSearch( searchParams, contextID ), 
                _integrations, 
                cancellationToken 
            ).ConfigureAwait( false );

        return match is not null ? request.WithGuestCustomer( searchParams, match ) : request.WithGuestRegistration( searchParams, null );
    }

    private CheckoutRequest SetExigoDefaults( CheckoutRequest transaction )
    {
        return transaction.AccountRegistration is not AccountRegistration _registration
                ? transaction with { CartOrder = SetOrderDefaults ( transaction.CartOrder , transaction.PriceType ) }
                : transaction with
                {
                    CartOrder = SetOrderDefaults ( transaction.CartOrder , transaction.PriceType ) ,
                    AccountRegistration = SetAccountDefaults ( _registration )
                };
    }
    private ShoppingCartOrder SetOrderDefaults( ShoppingCartOrder cartOrder , TotalLifePriceType priceType )
    {
        return cartOrder with
        {
            ShipMethodID = cartOrder.ShipMethodID.Equals ( 0 ) ?
                            _settings.Defaults.ShipMethodID :
                            cartOrder.ShipMethodID ,
            WarehouseID = cartOrder.WarehouseID.Equals ( 0 ) ?
                            _settings.Defaults.WarehouseID :
                            cartOrder.WarehouseID ,
            OrderType = ( ExigoOrderType ) ( ( int ) _settings.TypeIDs.CommerceCloudOrderType ) ,
            OrderDate = CstDateTime.Now ,
            PriceType = TotalLifePriceType.Values.FirstOrDefault ( x => x.TypeID.Equals ( priceType.TypeID ) )?.TypeID
                        ?? _settings.Defaults.PriceTypeID
        };
    }
    private AccountRegistration SetAccountDefaults( AccountRegistration registration )
        => registration with
        {
            CanLogin = true ,
            InsertEnrollerTree = true ,
            EntryDate = CstDateTime.Now ,
            BinaryPlacementPreference = registration.BinaryPlacementPreference.GetValueOrDefault ( ).Equals ( 0 ) ?
                                        _settings.Defaults.PlacementTypeID :
                                        registration.BinaryPlacementPreference.GetValueOrDefault ( ) ,
            PayableType = registration.PayableType.GetValueOrDefault ( ).Equals ( 0 ) ?
                                        _settings.Defaults.PayableTypeID :
                                        registration.PayableType.GetValueOrDefault ( ) ,
            DefaultWarehouseID = registration.DefaultWarehouseID.GetValueOrDefault ( ).Equals ( 0 ) ?
                                        _settings.Defaults.WarehouseID :
                                        registration.DefaultWarehouseID.GetValueOrDefault ( ) ,
            LanguageID = !registration.LanguageID.Equals ( 0 ) ? registration.LanguageID :
                                        _settings.Defaults.LanguageID ,
            CustomerStatus = !registration.CustomerStatus.Equals ( 0 ) ? registration.CustomerStatus :
                                        _settings.Defaults.AccountStatus
        };


    public async Task<CheckoutState> CreatePointPaymentTransactions(
        CustomerID userID ,
        CartID cartID ,
        PointAcccountPaymentAmount paymentAmount ,
        CheckoutState state ,
        CancellationToken cancellationToken )
    {
        var accountsQuery = new UserPointAccountAggregateQuery( userID, ExigoConfiguration.Instance.Checkout.PointPaymentAccounts );
        List<UserPointAccount> accounts = await UserPointAccountAggregateQuery.Execute( accountsQuery, _integrations, cancellationToken );
        decimal balance = accounts.Any() ? accounts.Sum ( a => a.AccountBalance ) : 0;
        if ( balance < paymentAmount )
            return state with { ProcessingError = new UIDisplayString ( CheckoutErrors.InsufficientPointBalance ( paymentAmount , balance ) ) };


        state = state with { Context = state.Context with { PointTransactions = new ( ) } };
        List<PointAccountPayment> payments = InitializePointPayments( cartID, userID, paymentAmount, accounts );
        var completedPayments = await ProcessRedemptions(
                payments,
                state.OperationContextID,
                cancellationToken
            ).ConfigureAwait(false);

        foreach ( var payment in completedPayments )
            state.Context.PointTransactions!.Add ( payment );

        if ( completedPayments.Count.Equals ( payments.Count ) )
            return state;

        var reversals = await ProcessReversals(
                completedPayments.Select(p => new PointPaymentReversal(p)).ToList(),
                state.OperationContextID,
                cancellationToken
            ).ConfigureAwait( false );

        reversals.ForEach ( itm => state.Context.PointTransactions!.Add ( itm ) );


        return state with { ProcessingError = new UIDisplayString ( "Point payment processing error. Cannot complete order." ) };
    }

    private static List<PointAccountPayment> InitializePointPayments( CartID cartID , CustomerID userID , PointAcccountPaymentAmount paymentAmount , List<UserPointAccount> pointAccounts )
    {
        decimal amount = paymentAmount;
        List<PointAccountPayment> payments = new();
        while ( amount > 0 )
            for ( int i = 0 ; i < pointAccounts.Count ; i++ )
            {
                decimal acctPayment = amount > pointAccounts[i].AccountBalance ? pointAccounts[i].AccountBalance : paymentAmount;
                payments.Add ( new PointAccountPayment
                {
                    UserID = userID ,
                    CartID = cartID ,
                    PointAccountID = pointAccounts[ i ].PointAccountID ,
                    TransactionAmount = -( acctPayment )
                } );

                amount -= acctPayment;
            }
        return payments;
    }
    private async Task<List<PointAccountPayment>> ProcessRedemptions( List<PointAccountPayment> payments , OperationContextID contextID , CancellationToken cancellationToken )
    {
        var completedPayments = new List<PointAccountPayment>();
        for ( int i = 0 ; i < payments.Count ; i++ )
        {
            var payment = payments[i];
            var submit = new UserPointAccountTransaction( payment, contextID );

            IOrderPointTransaction result = await UserPointAccountTransaction.Execute( submit, _integrations, cancellationToken );
            if ( !result.TransactionID.HasValue )
                break;

            completedPayments.Add ( payment with { TransactionID = result.TransactionID.Value } );
        }

        return completedPayments;
    }
    private async Task<List<PointPaymentReversal>> ProcessReversals( List<PointPaymentReversal> reversals , OperationContextID contextID , CancellationToken cancellationToken )
    {
        for ( int i = 0 ; i < reversals.Count ; i++ )
        {
            var reverse = reversals[i];
            var submit = new UserPointAccountTransaction( reverse, contextID );

            IOrderPointTransaction result = await UserPointAccountTransaction.Execute( submit, _integrations, cancellationToken );
            reverse = result.TransactionID.HasValue
                        ? reverse with { TransactionID = result.TransactionID.Value }
                        : reverse with { ProcessingError = result.ProcessingError ?? String.Empty };

            if ( !result.TransactionID.HasValue )
                _logger.LogWarning ( $" Point payment reversal failed. ( CustomerID: {reverse.UserID.Value} | CartID: {reverse.CartID.Value} | OriginalTransactionID: {reverse.PaymentTransactionID.Value} )" );
        }

        return reversals;
    }
    private async Task SaveState( CheckoutState state , CancellationToken cancellationToken )
    {
        await SaveStateBlob ( state , cancellationToken ).ConfigureAwait ( false );
        if ( state.Result is not null )
            await AddCompletedCartTriggers ( state , cancellationToken );
    }
    private async Task SaveStateBlob( CheckoutState state , CancellationToken cancellationToken )
    {
        var upload = new UploadCheckoutStateBlob(
                state.OperationContextID,
                CheckoutSerializer.GetBlobJson(state), 
                new StorageBlobContainerName( _serviceOptions.CurrentValue.CheckoutBlobsContainer  ),
                state.GetBlobName()
            );
        _ = await _integrations.ExecuteIntegrationCommand<UploadJsonBlob> ( upload , cancellationToken );
    }
    private async Task AddCompletedCartTriggers( CheckoutState state , CancellationToken cancellationToken )
    {
        if ( state.Result is null )
            return;

        var queueNames = _serviceOptions.CurrentValue.CheckoutSuccessQueues;
        foreach ( var queue in queueNames )
        {
            var insert = new InsertCheckoutQueueTrigger( state, queue );
            _ = await _integrations.ExecuteIntegrationCommand( insert , cancellationToken );
        }
    }

    private (SubmitExigoTransaction Operation, UIDisplayString? Error) InitializeExigoOperation( CheckoutRequest request , CheckoutState state )
    {
        ApiRequest? paymentRequest = null;
        if( request.MerchantPayment is not null )
        {
            Type sourceType = request.MerchantPayment.ChargeAccount.GetType();
            Type? destType = request.MerchantPayment.ChargeAccount switch
            {
                UserCreditCardAccount => typeof(ChargeCreditCardTokenOnFileRequest),
                UserWalletAccount => typeof(ChargeWalletAccountOnFileRequest),
                CreditCardAccount => typeof(ChargeCreditCardTokenRequest),
                WalletAccount => typeof(ChargeWalletAccountRequest),
                _ => null
            };

            if( destType is null )
                return ( SubmitExigoTransaction.Default, new UIDisplayString(CheckoutErrors.UnsupportedPaymentType( sourceType )));

            paymentRequest = _mapper.Map( request.MerchantPayment.ChargeAccount , sourceType, destType ) as ApiRequest;
        }

        if ( state.Context.ProductContext.CbdItemCount > 0 )
            if( paymentRequest is ChargeCreditCardTokenOnFileRequest _savedToken )
                paymentRequest = _savedToken with { MerchantWarehouseIDOverride = ExigoConfiguration.CheckoutSettings.Instance.TypeIDs.CbdMerchantWarehouse };
            else if( paymentRequest is ChargeCreditCardTokenRequest _newToken )
                paymentRequest = _newToken with { MerchantWarehouseIDOverride = ExigoConfiguration.CheckoutSettings.Instance.TypeIDs.CbdMerchantWarehouse };

        SubmitExigoTransaction operation = new SubmitExigoTransaction ( 
                state.OperationContextID, 
                request.CartId, 
                request.CartOrder, 
                paymentRequest, 
                request.AccountRegistration , 
                _integrations
            );

        return ( operation , null);
    }


}
