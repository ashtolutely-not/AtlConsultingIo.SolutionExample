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
public partial class UserEntitiesMapper : ExigoEntityMapper
{
    public UserEntitiesMapper()
    {
        //so properties on the UserSite class are mappable by convention
        RecognizePrefixes( "Site" );
        //Combined with prefix, this supports mapping WebAlias to SiteAlias using convention
        ReplaceMemberName( "Web" , "" );

        ReplaceMemberName("LoginName","Username");
        ReplaceMemberName("Subscribed","OptedIn");
        ReplaceMemberName("subscribed", "OptedIn");

        CreateMap<CustomerResponse , AccountResult>( MemberList.None )
            .ForMember( d => d.AccountId, o => o.MapFrom( s => new CustomerID(s.CustomerID)))
            .ForMember( d => d.EnrollerId, o => o.MapFrom( s => new CustomerID(s.EnrollerID)))
            .ForMember( d => d.RankId, o => o.MapFrom( s => new ExigoTypeID(s.RankID)))
            .ForMember( d => d.AccountStatusId, o => o.MapFrom( s => new ExigoTypeID(s.CustomerStatus)))
            .ForMember( d => d.BirthDate, o => o.MapFrom( s => DateOnly.FromDateTime(s.BirthDate)))
            .ForMember( d => d.Gender, o => o.MapFrom( s => s.Gender.ToString()))
            .ForMember( d => d.LanguageId, o => o.MapFrom( s => new ExigoTypeID(s.LanguageID)))
            .ForMember( d => d.CustomerTypeId, o => o.MapFrom( s => new ExigoTypeID(s.CustomerType)))
            .ForMember( d => d.WarehouseId, o => o.MapFrom( s => new ExigoTypeID(s.DefaultWarehouseID)))
            .ForMember( d => d.IsEmailOptedIn, o => o.MapFrom( s => s.IsSubscribedToBroadcasts))
            .ForMember( d => d.MainAddress, o => o.MapFrom(s => MainAddress(s)))
            .ForMember( d => d.MailAddress, o => o.MapFrom(s => MailAddress(s)))
            .ForMember( d => d.OtherAddress, o => o.MapFrom(s => OtherAddress(s)))
            .ForMember( d => d.EnrollmentDate, o => o.MapFrom( s => EnrollmentDate(s)));

        CreateMap<Customer , AccountResult>( MemberList.None )
            .ForMember( d => d.AccountId, o => o.MapFrom( s => new CustomerID(s.CustomerId)))
            .ForMember( d => d.EnrollerId, o => o.MapFrom( s => new ExigoTypeID(s.EnrollerId ?? 0)))
            .ForMember( d => d.RankId, o => o.MapFrom( s => new ExigoTypeID(s.RankId ?? 0 )))
            .ForMember( d => d.AccountStatusId, o => o.MapFrom( s => new ExigoTypeID(s.CustomerStatusId)))
            .ForMember( d => d.BirthDate, o => o.MapFrom( s => s.BirthDate.HasValue ? DateOnly.FromDateTime(s.BirthDate.Value) : DateOnly.MinValue))
            .ForMember( d => d.Gender, o => o.MapFrom( s => s.Gender.ToString()))
            .ForMember( d => d.LanguageId, o => o.MapFrom( s => new ExigoTypeID(s.LanguageId ?? 0 )))
            .ForMember( d => d.CustomerTypeId, o => o.MapFrom( s => new ExigoTypeID(s.CustomerTypeId)))
            .ForMember( d => d.WarehouseId, o => o.MapFrom( s => new ExigoTypeID(s.DefaultWarehouseId ?? ExigoConfiguration.Checkout.Defaults.WarehouseID)))
            .ForMember( d => d.MainAddress, o => o.MapFrom(s => MainAddress(s) ))
            .ForMember( d => d.MailAddress, o => o.MapFrom(s => MailAddress(s)))
            .ForMember( d => d.OtherAddress, o => o.MapFrom(s => OtherAddress(s)))
            .ForMember( d => d.EnrollmentDate, o => o.MapFrom( s => EnrollmentDate(s)))
            .ForMember( d => d.TaxId, o => o.MapFrom( s => !string.IsNullOrEmpty(s.TaxCode) ? new IncomeTaxID(s.TaxCode) : (IncomeTaxID?)null));

        //TODO : Check mappings 
        CreateMap<CustomerSite , UserSite>( MemberList.None )
            .ForMember( d => d.SitePhone , o => o.MapFrom( s => string.IsNullOrWhiteSpace(s.Phone) ? s.Phone2 : s.Phone ))
            .ForMember( d => d.UserId, o => o.MapFrom( s => new CustomerID(s.CustomerId)));
        CreateMap<GetCustomerSiteResponse , UserSite>( MemberList.None )
            .ForMember( d => d.SitePhone , o => o.MapFrom( s => string.IsNullOrWhiteSpace(s.Phone) ? s.Phone2 : s.Phone ))
            .ForMember( d => d.UserId, o => o.MapFrom( s => new CustomerID(s.CustomerID)));

        CreateMap<UserSite , SetCustomerSiteRequest>( MemberList.None )
            .ForMember( d => d.CustomerID , o => o.MapFrom( s => (int)s.UserId));

    }

    private static DateTime? EnrollmentDate( CustomerResponse customer )
        => DistributorAccount.Instance.Equals( customer.CustomerType ) ? 
            customer.Date5 ?? customer.CreatedDate : default;

    private static DateTime? EnrollmentDate( Customer customer )
        => DistributorAccount.Instance.Equals( customer.CustomerTypeId ) ? 
            customer.Date5 ?? customer.CreatedDate : default;

    #region Address Mappings

    private static Address MainAddress( CustomerResponse customer ) => new ( )
    {
        Address1 = customer.MainAddress1 ,
        Address2 = customer.MainAddress2 ,
        Address3 = customer.MainAddress3 ,
        City = customer.MainCity ,
        Region = customer.MainState ,
        PostalCode = customer.MainZip ,
        Country = customer.MainCountry ,
        IsVerified = customer.MainAddressVerified
    };

    private static Address MailAddress( CustomerResponse customer ) => new ( )
    {
        Address1 = customer.MailAddress1 ,
        Address2 = customer.MailAddress2 ,
        Address3 = customer.MailAddress3 ,
        City = customer.MailCity ,
        Region = customer.MailState ,
        PostalCode = customer.MailZip ,
        Country = customer.MailCountry ,
        IsVerified = customer.MailAddressVerified
    };

    private static Address OtherAddress( CustomerResponse customer ) => new ( )
    {
        Address1 = customer.OtherAddress1 ,
        Address2 = customer.OtherAddress2 ,
        Address3 = customer.OtherAddress3 ,
        City = customer.OtherCity ,
        Region = customer.OtherState ,
        PostalCode = customer.OtherZip ,
        Country = customer.OtherCountry ,
        IsVerified = customer.OtherAddressVerified
    };

    private static Address MainAddress( Customer customer ) => new ( )
    {
        Address1 = customer.MainAddress1 ,
        Address2 = customer.MainAddress2 ?? String.Empty ,
        Address3 = customer.MainAddress3 ,
        City = customer.MainCity ,
        Region = customer.MainState ,
        PostalCode = customer.MainZip ,
        Country = customer.MainCountry ,
        IsVerified = customer.MainVerified
    };

    private static Address MailAddress( Customer customer ) => new ( )
    {
        Address1 = customer.MailAddress1 ,
        Address2 = customer.MailAddress2 ?? String.Empty ,
        Address3 = customer.MailAddress3 ,
        City = customer.MailCity ,
        Region = customer.MailState ,
        PostalCode = customer.MailZip ,
        Country = customer.MailCountry ,
        IsVerified = customer.MailVerified
    };

    private static Address OtherAddress( Customer customer ) => new ( )
    {
        Address1 = customer.OtherAddress1 ,
        Address2 = customer.OtherAddress2 ?? String.Empty ,
        Address3 = customer.OtherAddress3 ,
        City = customer.OtherCity ,
        Region = customer.OtherState ,
        PostalCode = customer.OtherZip ,
        Country = customer.OtherCountry ,
        IsVerified = customer.OtherVerified
    };

    #endregion

}
