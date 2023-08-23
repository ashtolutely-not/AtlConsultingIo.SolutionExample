// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.
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

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CustomerResponse 
{
    public int CustomerID { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Company { get; init; }
    public int CustomerType { get; init; }
    public int CustomerStatus { get; init; }
    public string Email { get; init; }
    public string Phone { get; init; }
    public string Phone2 { get; init; }
    public string MobilePhone { get; init; }
    public string Fax { get; init; }
    public string MainAddress1 { get; init; }
    public string MainAddress2 { get; init; }
    public string MainCity { get; init; }
    public string MainState { get; init; }
    public string MainZip { get; init; }
    public string MainCountry { get; init; }
    public string MainCounty { get; init; }
    public string MailAddress1 { get; init; }
    public string MailAddress2 { get; init; }
    public string MailCity { get; init; }
    public string MailState { get; init; }
    public string MailZip { get; init; }
    public string MailCountry { get; init; }
    public string MailCounty { get; init; }
    public string OtherAddress1 { get; init; }
    public string OtherAddress2 { get; init; }
    public string OtherCity { get; init; }
    public string OtherState { get; init; }
    public string OtherZip { get; init; }
    public string OtherCountry { get; init; }
    public string OtherCounty { get; init; }
    public string LoginName { get; init; }
    public int EnrollerID { get; init; }
    public int SponsorID { get; init; }
    public int RankID { get; init; }
    public DateTime BirthDate { get; init; }
    public string Field1 { get; init; }
    public string Field2 { get; init; }
    public string Field3 { get; init; }
    public string Field4 { get; init; }
    public string Field5 { get; init; }
    public string Field6 { get; init; }
    public string Field7 { get; init; }
    public string Field8 { get; init; }
    public string Field9 { get; init; }
    public string Field10 { get; init; }
    public string Field11 { get; init; }
    public string Field12 { get; init; }
    public string Field13 { get; init; }
    public string Field14 { get; init; }
    public string Field15 { get; init; }
    public DateTime? Date1 { get; init; }
    public DateTime? Date2 { get; init; }
    public DateTime? Date3 { get; init; }
    public DateTime? Date4 { get; init; }
    public DateTime? Date5 { get; init; }
    public string CurrencyCode { get; init; }
    public string PayableToName { get; init; }
    public int DefaultWarehouseID { get; init; }
    public string PayableType { get; init; }
    public Decimal CheckThreshold { get; init; }
    public int PriceType { get; init; }
    public int LanguageID { get; init; }
    public Gender Gender { get; init; }
    public string SalesTaxID { get; init; }
    public string VatRegistration { get; init; }
    public bool IsSalesTaxExempt { get; init; }
    public bool IsSubscribedToBroadcasts { get; init; }
    public DateTime CreatedDate { get; init; }
    public DateTime ModifiedDate { get; init; }
    public string MiddleName { get; init; }
    public string NameSuffix { get; init; }
    public string MainAddress3 { get; init; }
    public string MailAddress3 { get; init; }
    public string OtherAddress3 { get; init; }
    public int BinaryPlacementPreference { get; init; }
    public bool UseBinaryHoldingTank { get; init; }
    public bool MainAddressVerified { get; init; }
    public bool MailAddressVerified { get; init; }
    public bool OtherAddressVerified { get; init; }
    public string CustomerKey { get; init; }
    public string EnrollerKey { get; init; }
    public string SponsorKey { get; init; }

    public CustomerResponse() : base()
    {
        FirstName = String.Empty;
        LastName = String.Empty;
        Company = String.Empty;
        Email = String.Empty;
        Phone = String.Empty;
        Phone2 = String.Empty;
        MobilePhone = String.Empty;
        Fax = String.Empty;
        MainAddress1 = String.Empty;
        MainAddress2 = String.Empty;
        MainCity = String.Empty;
        MainState = String.Empty;
        MainZip = String.Empty;
        MainCountry = String.Empty;
        MainCounty = String.Empty;
        MailAddress1 = String.Empty;
        MailAddress2 = String.Empty;
        MailCity = String.Empty;
        MailState = String.Empty;
        MailZip = String.Empty;
        MailCountry = String.Empty;
        MailCounty = String.Empty;
        OtherAddress1 = String.Empty;
        OtherAddress2 = String.Empty;
        OtherCity = String.Empty;
        OtherState = String.Empty;
        OtherZip = String.Empty;
        OtherCountry = String.Empty;
        OtherCounty = String.Empty;
        LoginName = String.Empty;
        Field1 = String.Empty;
        Field2 = String.Empty;
        Field3 = String.Empty;
        Field4 = String.Empty;
        Field5 = String.Empty;
        Field6 = String.Empty;
        Field7 = String.Empty;
        Field8 = String.Empty;
        Field9 = String.Empty;
        Field10 = String.Empty;
        Field11 = String.Empty;
        Field12 = String.Empty;
        Field13 = String.Empty;
        Field14 = String.Empty;
        Field15 = String.Empty;
        CurrencyCode = String.Empty;
        PayableToName = String.Empty;
        PayableType = String.Empty;
        SalesTaxID = String.Empty;
        VatRegistration = String.Empty;
        MiddleName = String.Empty;
        NameSuffix = String.Empty;
        MainAddress3 = String.Empty;
        MailAddress3 = String.Empty;
        OtherAddress3 = String.Empty;
        CustomerKey = String.Empty;
        EnrollerKey = String.Empty;
        SponsorKey = String.Empty;
    }
}
