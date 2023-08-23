using CompanyName.Core;
using CompanyName.Core.Entities;
using CompanyName.Core.Entities.Events;
using CompanyName.Core.Entities.Messaging;
using CompanyName.Core.Entities.Order;
using CompanyName.Core.Entities.Product;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;
using CompanyName.Core.Integrations.Exigo.Sql;
using CompanyName.Core.Integrations.KountApi;
using CompanyName.Core.Integrations.SendGridApi;
using AutoMapper;



namespace CompanyName.Core.Entities.User;

public class UserPaymentEntitiesMapper : ExigoEntityMapper
{
    public UserPaymentEntitiesMapper( )
    {
        RecognizePostfixes("ID","Id");

        CreateMap<GetCustomerBillingResponse , List<UserCreditCardAccount>> ( MemberList.None )
            .ConvertUsing ( new UserCreditCardsApiConverter ( ) );

        CreateMap<GetCustomerBillingResponse , List<UserWalletAccount>> ( MemberList.None )
            .ConvertUsing ( new UserWalletsApiConverter ( ) );

        CreateMap<GetCustomerBillingResponse , List<UserPaymentAccount>> ( MemberList.None )
            .ConvertUsing ( new UserPaymentAccountsApiConverter ( ) );

        CreateMap<CustomerAccount , List<UserCreditCardAccount>> ( MemberList.None )
            .ConvertUsing ( new UserCreditCardsDbConvert ( ) );

        CreateMap<CustomerAccount , List<UserWalletAccount>> ( MemberList.None )
            .ConvertUsing ( new UserWalletDbConverter ( ) );

        CreateMap<CustomerAccount , List<UserPaymentAccount>> ( MemberList.None )
            .ConvertUsing ( new UserPaymentAccountsDbConverter ( ) );

        CreateMap<GetCustomerBillingResponse , ECommAppUser> ( MemberList.None )
            .ForMember ( d => d.CreditCardAccounts , o => o.ConvertUsing ( new UserCreditCardsApiConverter ( ) ) )
            .ForMember ( d => d.WalletAccounts , o => o.ConvertUsing ( new UserWalletsApiConverter ( ) ) );

        CreateMap<CustomerAccount , ECommAppUser> ( MemberList.None )
            .ForMember ( d => d.CreditCardAccounts , o => o.ConvertUsing ( new UserCreditCardsDbConvert ( ) ) )
            .ForMember ( d => d.WalletAccounts , o => o.ConvertUsing ( new UserWalletDbConverter ( ) ) );

        // TODO
        CreateMap<UserCreditCardAccount, ChargeCreditCardTokenOnFileRequest> ( MemberList.None )
            .ForMember( d => d.CreditCardAccountType, o => o.MapFrom( s => s.ProfileType.AsCreditCardAccountType()));

        CreateMap<CreditCardAccount , ChargeCreditCardTokenRequest> ( MemberList.None );
        CreateMap<Address , ChargeCreditCardTokenRequest> ( MemberList.None )
            .ForMember ( dest => dest.BillingAddress , opt => opt.MapFrom ( src => src.Address1 ) )
            .ForMember ( dest => dest.BillingAddress2 , opt => opt.MapFrom ( src => src.Address2 ) )
            .ForMember ( dest => dest.BillingCity , opt => opt.MapFrom ( src => src.City ) )
            .ForMember ( dest => dest.BillingState , opt => opt.MapFrom ( src => src.Region ) )
            .ForMember ( dest => dest.BillingZip , opt => opt.MapFrom ( src => src.PostalCode ) )
            .ForMember ( dest => dest.BillingCountry , opt => opt.MapFrom ( src => src.Country ) );

        CreateMap<UserWalletAccount, ChargeWalletAccountOnFileRequest>( MemberList.None )
            .ForMember( d => d.WalletAccountType, o => o.MapFrom( s => s.ProfileType.AsWalletType()));
            
        CreateMap<WalletAccount, ChargeWalletAccountRequest> ( MemberList.None )
            .ForMember( d => d.WalletTy, o => o.MapFrom( s => s.WalletTypeId ))
            .ForMember( d => d.WalletAccountNumber, o => o.MapFrom( s => s.AccountNumber ));


    }

    internal class UserPaymentAccountsApiConverter : ITypeConverter<GetCustomerBillingResponse , List<UserPaymentAccount>>
    {
        private static readonly UserCreditCardsApiConverter ccConverter = new();
        private static readonly UserWalletsApiConverter walletConverter = new();

        public List<UserPaymentAccount> Convert( GetCustomerBillingResponse source , List<UserPaymentAccount> destination , ResolutionContext context )
        {
            var existingCCs = destination.Where( x => x.AccountData is CreditCardAccount ).Select( x => new UserCreditCardAccount(x.ProfileType, (CreditCardAccount)x.AccountData )) ;
            var existingWallets = destination.Where( x => x.AccountData is WalletAccount ).Select( x => new UserWalletAccount( x.ProfileType, (WalletAccount)x.AccountData )) ;


            List<UserPaymentAccount> accounts = new();
            List<UserCreditCardAccount> creditCards
                = !existingCCs.Any() ?
                        ccConverter.Convert( source , context ) :
                        ccConverter.Convert( source, existingCCs.ToList(), context ) ;

            if ( creditCards.Any ( ) )
                accounts.AddRange ( creditCards.Cast<UserPaymentAccount> ( ) );

            List<UserWalletAccount> wallets =
                !existingWallets.Any() ?
                walletConverter.Convert( source, context ) :
                walletConverter.Convert( source, existingWallets.ToList(), context ) ;

            if ( wallets.Any ( ) )
                accounts.AddRange ( wallets.Cast<UserPaymentAccount> ( ) );

            return accounts;
        }
    }
    internal class UserPaymentAccountsDbConverter : ITypeConverter<CustomerAccount , List<UserPaymentAccount>>
    {
        private static readonly UserCreditCardsDbConvert creditCardConverter = new();
        private static readonly UserWalletDbConverter walletConverter = new();
        public List<UserPaymentAccount> Convert( CustomerAccount source , List<UserPaymentAccount> destination , ResolutionContext context )
        {
            var accounts = new List<UserPaymentAccount>();

            var existingCCs = destination.Where( x => x.AccountData is CreditCardAccount ).Select( x => new UserCreditCardAccount( x.ProfileType, (CreditCardAccount)x.AccountData )) ;
            var existingWallets = destination.Where( x => x.AccountData is WalletAccount ).Select( x => new UserWalletAccount( x.ProfileType, (WalletAccount)x.AccountData )) ;

            List < UserCreditCardAccount > creditCards
                = !existingCCs.Any() ?
                        creditCardConverter.Convert( source , context ) :
                        creditCardConverter.Convert( source, existingCCs.ToList(), context ) ;
            if ( creditCards.Any ( ) )
                accounts.AddRange ( creditCards.Select ( x => ( UserPaymentAccount ) x ) );

            List < UserWalletAccount > wallets =
                !existingWallets.Any() ?
                walletConverter.Convert( source, context ) :
                walletConverter.Convert( source, existingWallets.ToList(), context ) ;
            if ( wallets.Any ( ) )
                accounts.AddRange ( wallets.Select ( x => ( UserPaymentAccount ) x ) );

            return accounts;
        }
    }
    internal class UserCreditCardsApiConverter : IValueConverter<GetCustomerBillingResponse , List<UserCreditCardAccount>>, ITypeConverter<GetCustomerBillingResponse , List<UserCreditCardAccount>>
    {
        public List<UserCreditCardAccount> Convert( GetCustomerBillingResponse source , ResolutionContext context )
        {
            var list = ToListResult( source );
            list.RemoveAll ( x => !x.AccountId.HasValue ( ) );

            return list;
        }
        public List<UserCreditCardAccount> Convert( GetCustomerBillingResponse source , List<UserCreditCardAccount> destination , ResolutionContext context )
        {
            var list = ToListResult( source );
            list.RemoveAll ( x => !x.AccountId.HasValue ( ) );

            if ( destination.Any ( ) )
                foreach ( var itm in destination )
                    if ( !list.Any ( x => x.AccountId.CaseInsensitiveEquals ( itm.AccountId ) ) )
                        if ( !list.Any ( x => x.ProfileType.Equals ( itm.ProfileType ) ) )
                            list.Add ( itm );

            return list;
        }

        private static List<UserCreditCardAccount> ToListResult( GetCustomerBillingResponse source )
        {
            List<UserCreditCardAccount> list = new();

            if ( source.PrimaryCreditCard is CreditCardAccountResponse _card )
                list.Add ( new UserCreditCardAccount (
                        PaymentProfileType.Primary ,
                        new CreditCardAccount
                        {
                            CreditCardTypeId = _card.CreditCardType ,
                            ExpirationMonth = _card.ExpirationMonth ,
                            ExpirationYear = _card.ExpirationYear ,
                            BillingName = _card.BillingName ,
                            CreditCardToken = _card.CreditCardToken ,
                            CvcCode = String.Empty ,
                            DisplayValue = _card.CreditCardNumberDisplay ,
                            BillingAddress = new Address
                            {
                                Address1 = _card.BillingAddress ,
                                Address2 = _card.BillingAddress2 ,
                                City = _card.BillingCity ,
                                Region = _card.BillingState ,
                                PostalCode = _card.BillingZip ,
                                Country = _card.BillingCountry ,
                            }
                        }
                    ) );

            if ( source.SecondaryCreditCard is CreditCardAccountResponse _card2 )
                list.Add ( new UserCreditCardAccount (
                        PaymentProfileType.Secondary ,
                        new CreditCardAccount
                        {
                            CreditCardTypeId = _card2.CreditCardType ,
                            ExpirationMonth = _card2.ExpirationMonth ,
                            ExpirationYear = _card2.ExpirationYear ,
                            BillingName = _card2.BillingName ,
                            CreditCardToken = _card2.CreditCardToken ,
                            CvcCode = String.Empty ,
                            DisplayValue = _card2.CreditCardNumberDisplay ,
                            BillingAddress = new Address
                            {
                                Address1 = _card2.BillingAddress ,
                                Address2 = _card2.BillingAddress2 ,
                                City = _card2.BillingCity ,
                                Region = _card2.BillingState ,
                                PostalCode = _card2.BillingZip ,
                                Country = _card2.BillingCountry ,
                            }
                        }
                    ) );

            return list;
        }
    }
    internal class UserCreditCardsDbConvert : IValueConverter<CustomerAccount , List<UserCreditCardAccount>>, ITypeConverter<CustomerAccount , List<UserCreditCardAccount>>
    {
        public List<UserCreditCardAccount> Convert( CustomerAccount source , ResolutionContext context )
        {
            var list = ToListResult( source );
            list.RemoveAll ( x => !x.AccountId.HasValue ( ) );
            return list;
        }
        public List<UserCreditCardAccount> Convert( CustomerAccount source , List<UserCreditCardAccount> destination , ResolutionContext context )
        {
            var list = ToListResult( source );
            list.RemoveAll ( x => !x.AccountId.HasValue ( ) );

            foreach ( var itm in destination )
                if ( !list.Any ( x => x.AccountId.CaseInsensitiveEquals ( itm.AccountId ) ) )
                    if ( !list.Any ( x => x.ProfileType.Equals ( itm.ProfileType ) ) )
                        list.Add ( itm );

            return list;
        }
        private static List<UserCreditCardAccount> ToListResult( CustomerAccount source )
            => new ( )
            {
                new UserCreditCardAccount
                (
                    PaymentProfileType.Primary ,
                    new CreditCardAccount
                    {
                        CreditCardTypeId = source.PrimaryCreditCardTypeId ,
                        ExpirationMonth = source.PrimaryExpirationMonth ?? 0 ,
                        ExpirationYear = source.PrimaryExpirationYear ?? 0 ,
                        CreditCardToken = source.CreditCardToken.EmptyIfNull() ,
                        CvcCode = string.Empty ,
                        BillingName = source.PrimaryBillingName ,
                        DisplayValue = source.PrimaryCreditCardDisplay.EmptyIfNull() ,
                        BillingAddress = new(
                            source.PrimaryBillingAddress ,
                            source.PrimaryBillingAddress2 ,
                            null ,
                            source.PrimaryBillingCity ,
                            source.PrimaryBillingState ,
                            source.PrimaryBillingCountry ,
                            source.PrimaryBillingZip
                        )
                    }
                ),
                new UserCreditCardAccount
                (
                    PaymentProfileType.Secondary ,
                    new CreditCardAccount
                    {
                        CreditCardTypeId = source.SecondaryCreditCardTypeId ,
                        ExpirationMonth = source.SecondaryExpirationMonth ?? 0 ,
                        ExpirationYear = source.SecondaryExpirationYear ?? 0 ,
                        CreditCardToken = source.CreditCardToken2.EmptyIfNull() ,
                        CvcCode = string.Empty ,
                        BillingName = source.SecondaryBillingName ,
                        DisplayValue = source.SecondaryCreditCardDisplay.EmptyIfNull() ,
                        BillingAddress = new(
                            source.SecondaryBillingAddress ,
                            source.SecondaryBillingAddress2 ,
                            null ,
                            source.SecondaryBillingCity ,
                            source.SecondaryBillingState ,
                            source.SecondaryBillingCountry ,
                            source.SecondaryBillingZip
                        )
                    }
                )
            };
    }
    internal class UserWalletsApiConverter : IValueConverter<GetCustomerBillingResponse , List<UserWalletAccount>>, ITypeConverter<GetCustomerBillingResponse , List<UserWalletAccount>>
    {
        public List<UserWalletAccount> Convert( GetCustomerBillingResponse source , ResolutionContext context )
        {
            List<UserWalletAccount> list =  ToListResult( source );
            list.RemoveAll ( x => !x.AccountId.HasValue ( ) );

            return list;
        }
        public List<UserWalletAccount> Convert( GetCustomerBillingResponse source , List<UserWalletAccount> destination , ResolutionContext context )
        {
            List<UserWalletAccount> list =  ToListResult( source );
            list.RemoveAll ( x => !x.AccountId.HasValue ( ) );

            if ( destination.Any ( ) )
                foreach ( var itm in destination )
                    if ( !list.Any ( x => x.AccountId.CaseInsensitiveEquals ( itm.AccountId ) ) )
                        if ( !list.Any ( x => x.ProfileType.Equals ( itm.ProfileType ) ) )
                            list.Add ( itm );

            return list;
        }

        private static List<UserWalletAccount> ToListResult( GetCustomerBillingResponse source )
        {
            List<UserWalletAccount> list = new();
            if ( source.PrimaryWalletAccount is WalletAccountResponse _wallet )
                list.Add ( new UserWalletAccount (
                        PaymentProfileType.Primary ,
                        new WalletAccount
                        {
                            WalletTypeId = _wallet.WalletType ,
                            AccountNumber = _wallet.WalletAccountDisplay ,
                            Field1 = _wallet.WalletOther1 ,
                            Field2 = _wallet.WalletOther2 ,
                            Field3 = _wallet.WalletOther3
                        }
                    ) );

            if ( source.SecondaryWallletAccount is WalletAccountResponse _wallet2 )
                list.Add ( new UserWalletAccount (
                        PaymentProfileType.Secondary ,
                        new WalletAccount
                        {
                            WalletTypeId = _wallet2.WalletType ,
                            AccountNumber = _wallet2.WalletAccountDisplay ,
                            Field1 = _wallet2.WalletOther1 ,
                            Field2 = _wallet2.WalletOther2 ,
                            Field3 = _wallet2.WalletOther3
                        }
                    ) );

            if ( source.ThirdWalletAccount is WalletAccountResponse _wallet3 )
                list.Add ( new UserWalletAccount (
                        PaymentProfileType.Third ,
                        new WalletAccount
                        {
                            WalletTypeId = _wallet3.WalletType ,
                            AccountNumber = _wallet3.WalletAccountDisplay ,
                            Field1 = _wallet3.WalletOther1 ,
                            Field2 = _wallet3.WalletOther2 ,
                            Field3 = _wallet3.WalletOther3
                        }
                    ) );

            if ( source.FourthWalletAccount is WalletAccountResponse _wallet4 )
                list.Add ( new UserWalletAccount (
                        PaymentProfileType.Fourth ,
                        new WalletAccount
                        {
                            WalletTypeId = _wallet4.WalletType ,
                            AccountNumber = _wallet4.WalletAccountDisplay ,
                            Field1 = _wallet4.WalletOther1 ,
                            Field2 = _wallet4.WalletOther2 ,
                            Field3 = _wallet4.WalletOther3
                        }
                    ) );

            if ( source.FifthWalletAccount is WalletAccountResponse _wallet5 )
                list.Add ( new UserWalletAccount (
                        PaymentProfileType.Fifth ,
                        new WalletAccount
                        {
                            WalletTypeId = _wallet5.WalletType ,
                            AccountNumber = _wallet5.WalletAccountDisplay ,
                            Field1 = _wallet5.WalletOther1 ,
                            Field2 = _wallet5.WalletOther2 ,
                            Field3 = _wallet5.WalletOther3
                        }
                    ) );

            return list;
        }
    }
    internal class UserWalletDbConverter : IValueConverter<CustomerAccount , List<UserWalletAccount>>, ITypeConverter<CustomerAccount , List<UserWalletAccount>>
    {
        public List<UserWalletAccount> Convert( CustomerAccount source , ResolutionContext context )
        {
            List<UserWalletAccount> list = ToListResult( source);
            list.RemoveAll ( x => !x.AccountId.HasValue ( ) );
            return list;
        }
        public List<UserWalletAccount> Convert( CustomerAccount source , List<UserWalletAccount> destination , ResolutionContext context )
        {
            List<UserWalletAccount> list = ToListResult( source);
            list.RemoveAll ( x => !x.AccountId.HasValue ( ) );

            if ( destination.Any ( ) )
                foreach ( var itm in destination )
                    if ( !list.Any ( x => x.AccountId.CaseInsensitiveEquals ( itm.AccountId ) ) )
                        if ( !list.Any ( x => x.ProfileType.Equals ( itm.ProfileType ) ) )
                            list.Add ( itm );

            return list;
        }

        private static List<UserWalletAccount> ToListResult( CustomerAccount source )
            => new ( )
            {
                new UserWalletAccount
                (
                    profileType: PaymentProfileType.Primary ,
                    new WalletAccount(
                            source.PrimaryWalletTypeId,
                            source.PrimaryWalletAccount.EmptyIfNull(),
                            source.PrimaryWalletOther1,
                            source.PrimaryWalletOther2,
                            source.PrimaryWalletOther3
                        )
                ),
                new UserWalletAccount
                (
                    profileType: PaymentProfileType.Secondary ,
                    new WalletAccount(
                            source.SecondaryWalletTypeId,
                            source.SecondaryWalletAccount.EmptyIfNull(),
                            source.SecondaryWalletOther1,
                            source.SecondaryWalletOther2,
                            source.SecondaryWalletOther3
                        )
                ),
                new UserWalletAccount
                (
                    profileType: PaymentProfileType.Third ,
                    new WalletAccount(
                            source.TertiaryWalletTypeId,
                            source.TertiaryWalletAccount.EmptyIfNull(),
                            source.TertiaryWalletOther1,
                            source.TertiaryWalletOther2,
                            source.TertiaryWalletOther3
                        )
                ),
                new UserWalletAccount
                (
                    profileType: PaymentProfileType.Fourth ,
                    new WalletAccount(
                            source.QuaternaryWalletTypeId,
                            source.QuaternaryWalletAccount.EmptyIfNull(),
                            source.QuaternaryWalletOther1,
                            source.QuaternaryWalletOther2,
                            source.QuaternaryWalletOther3
                        )
                ),
                new UserWalletAccount
                (
                    profileType: PaymentProfileType.Fifth ,
                    new WalletAccount(
                            source.QuinaryWalletTypeId,
                            source.QuinaryWalletAccount.EmptyIfNull(),
                            source.QuinaryWalletOther1,
                            source.QuinaryWalletOther2,
                            source.QuinaryWalletOther3
                        )
                ),
            };

    }
}
