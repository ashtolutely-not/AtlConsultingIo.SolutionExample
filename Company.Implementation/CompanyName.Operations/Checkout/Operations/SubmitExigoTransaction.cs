using AtlConsultingIo.IntegrationOperations;

using CompanyName.Core.Entities;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;

using Newtonsoft.Json.Linq;


namespace CompanyName.Operations.Checkout;
public record SubmitExigoTransaction : RestClientJsonTransaction, ICheckoutOperation<SubmitExigoTransaction, CheckoutResult>
{
    private readonly CartID CartId;
    private readonly CreateCustomerRequest ? AccountRequest;
    private readonly CreateOrderRequest OrderRequest;
    private readonly ApiRequest ? PaymentRequest;

    private readonly IIntegrationsService _integrations;
    public CheckoutResult? Result { get; set; }
    public string? OperationError { get; set; }
    public SubmitExigoTransaction(
        OperationContextID contextID ,
        CartID cartId ,
        CreateOrderRequest orderRequest ,
        ApiRequest? paymentRequest ,
        CreateCustomerRequest? accountRequest,
        IIntegrationsService integrationService )
    {
        CartId = cartId;
        OrderRequest = orderRequest;
        PaymentRequest = paymentRequest;
        AccountRequest = accountRequest;
        _integrations = integrationService;

        Key = ExigoTransactionApiKey.Instance;
        ContextID = contextID;
        HttpMethod = HttpMethod.Post;
        JsonData = GetJsonRequestContent ( this );
        Deserialize = async( response ) => JObject.Parse( await response.Content.ReadAsStringAsync() );
    }

    private SubmitExigoTransaction( )
    {
        OrderRequest = new();
        _integrations = null!;
    }

    private static JObject GetJsonRequestContent( SubmitExigoTransaction transaction )
    {
        var requests = new List<JObject>
            {
                new JObject
                {
                    new JProperty( JsonPropertyNames.RequestOrResponseType, transaction.OrderRequest.GetType ( ).Name ),
                    new JProperty( JsonPropertyNames.RequestJsonObject, transaction.OrderRequest )
                }
            };

        if ( transaction.AccountRequest is not null )
            requests.Add ( new JObject
            {
                    new JProperty( JsonPropertyNames.RequestOrResponseType, transaction.AccountRequest.GetType ( ).Name ),
                    new JProperty( JsonPropertyNames.RequestJsonObject, transaction.AccountRequest )
            } );

        if ( transaction.PaymentRequest is not null )
            requests.Add ( new JObject
            {
                    new JProperty( JsonPropertyNames.RequestOrResponseType, transaction.PaymentRequest.GetType ( ).Name ),
                    new JProperty( JsonPropertyNames.RequestJsonObject, transaction.PaymentRequest )
            } );

        return new JObject { new JProperty ( JsonPropertyNames.RequestArray , JArray.FromObject ( requests ) ) };
    }
    private CheckoutResult? ParseResult( JObject resultJson )
    {
        var responses = resultJson.Property( JsonPropertyNames.ResponseArray )?.Value<List<JObject>>();
        if( responses is not List<JObject> _responses )
            return null;

        CheckoutResult result = new CheckoutResult{ CartId = this.CartId };
        foreach( JObject resp in _responses )
        {
            string? responseType = resp.Property( JsonPropertyNames.RequestOrResponseType )?.Value<string>();
            if( !responseType.HasValue() ) 
                continue;

            var _resp = resp.Property( JsonPropertyNames.ResponseJsonObject )?.Value<JObject>();
            if( _resp is not JObject _json )
                continue;

            var _type = ExpectedResponseTypes.TryGetValue( responseType!, out var value ) ? value : null;
            result = _type switch
            {
                 CreateOrderResponse  => SetOrderID ( result , _resp ),
                 CreateCustomerResponse => SetAccountID( result, _resp ),
                 ChargeCreditCardResponse => SetCreditCardPaymentResult(result , _resp ),
                 ChargeWalletAccountResponse => SetWalletPaymentResult(result , _resp ),
                 _ => result
            };
        }

        return result;
    }
    private static CheckoutResult SetOrderID( CheckoutResult result, JObject orderResponse )
    {
        CreateOrderResponse? order = orderResponse.ToObject<CreateOrderResponse>();
        return  order is null ? result : result with { OrderId = new OrderID( order.OrderID ) } ;
    }
    private static CheckoutResult SetAccountID( CheckoutResult result , JObject customerResponse )
    {
        CreateCustomerResponse? customer = customerResponse.ToObject<CreateCustomerResponse>();
        return customer is null ? result : result with { AccountId = new CustomerID( customer.CustomerID ) };
    }
    private static CheckoutResult SetCreditCardPaymentResult( CheckoutResult result , JObject creditCardResponse )
    {
        ChargeCreditCardResponse? creditCard = creditCardResponse.ToObject<ChargeCreditCardResponse>();
        return creditCard is null ? result : result with 
        { 
            PaymentAuthorization = new TransactionKey(creditCard.AuthorizationCode), 
            PaymentId = new ExigoEntityID( creditCard.PaymentID )
        };
    }
    private static CheckoutResult SetWalletPaymentResult( CheckoutResult result, JObject walletResponse )
    {
        ChargeWalletAccountResponse? wallet = walletResponse.ToObject<ChargeWalletAccountResponse>();
        return wallet is null ? result : result with
        {
            PaymentId = new ExigoEntityID( wallet.PaymentID ),
            PaymentAuthorization = new TransactionKey( wallet.AuthorizationCode )
        };
    }

    public async Task<SubmitExigoTransaction> ExecuteAsync( CancellationToken cancellationToken )
    {
        var result = await _integrations.ExecuteIntegtrationTransaction<RestClientJsonTransaction,JObject>( this, cancellationToken );

         return result.Match (
                success => this with { Result = ParseResult ( success.Result ) }  ,
                err => this with { OperationError = err.Error.Message }
            );

    }

    private static readonly Dictionary<string,object> ExpectedResponseTypes 
        = new Dictionary<string, object>( StringComparer.OrdinalIgnoreCase)
    {
        [typeof(CreateOrderResponse).Name ] = new CreateOrderResponse(),
        [typeof(CreateCustomerResponse).Name] = new CreateCustomerResponse(),
        [typeof(ChargeCreditCardResponse).Name] = new ChargeCreditCardResponse(),
        [typeof(ChargeWalletAccountResponse).Name] = new ChargeWalletAccountResponse()
    };

    public static readonly SubmitExigoTransaction Default = new();
    struct JsonPropertyNames
    {
        public const string RequestOrResponseType = "typeName";
        public const string RequestJsonObject = "request";
        public const string ResponseJsonObject = "response";
        public const string RequestArray = "transactionRequests";
        public const string ResponseArray = "transactionResponses";
    }

}
