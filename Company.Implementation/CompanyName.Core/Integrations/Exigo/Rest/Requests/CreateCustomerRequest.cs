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
public record CreateCustomerRequest : ApiRequest, ITransactionMember
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }
    public int CustomerType { get; set; }
    public int? CustomerStatus { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Phone2 { get; set; }
    public string MobilePhone { get; set; }
    public string Fax { get; set; }
    public string Notes { get; set; }
    public string MainAddress1 { get; set; }
    public string MainAddress2 { get; set; }
    public string MainAddress3 { get; set; }
    public string MainCity { get; set; }
    public string MainState { get; set; }
    public string MainZip { get; set; }
    public string MainCountry { get; set; }
    public string MainCounty { get; set; }
    public string MailAddress1 { get; set; }
    public string MailAddress2 { get; set; }
    public string MailAddress3 { get; set; }
    public string MailCity { get; set; }
    public string MailState { get; set; }
    public string MailZip { get; set; }
    public string MailCountry { get; set; }
    public string MailCounty { get; set; }
    public string OtherAddress1 { get; set; }
    public string OtherAddress2 { get; set; }
    public string OtherAddress3 { get; set; }
    public string OtherCity { get; set; }
    public string OtherState { get; set; }
    public string OtherZip { get; set; }
    public string OtherCountry { get; set; }
    public string OtherCounty { get; set; }
    public bool CanLogin { get; set; }
    public string LoginName { get; set; }
    public string LoginPassword { get; set; }
    public bool InsertEnrollerTree { get; set; }
    public int EnrollerID { get; set; }
    public bool InsertUnilevelTree { get; set; }
    public int SponsorID { get; set; }
    public bool UseManualCustomerID { get; set; }
    public int ManualCustomerID { get; set; }
    public string TaxID { get; set; }
    public string SalesTaxID { get; set; }
    public DateTime? SalesTaxExemptExpireDate { get; set; }
    public bool? IsSalesTaxExempt { get; set; }
    public DateTime BirthDate { get; set; }
    public string Field1 { get; set; }
    public string Field2 { get; set; }
    public string Field3 { get; set; }
    public string Field4 { get; set; }
    public string Field5 { get; set; }
    public string Field6 { get; set; }
    public string Field7 { get; set; }
    public string Field8 { get; set; }
    public string Field9 { get; set; }
    public string Field10 { get; set; }
    public string Field11 { get; set; }
    public string Field12 { get; set; }
    public string Field13 { get; set; }
    public string Field14 { get; set; }
    public string Field15 { get; set; }
    public bool SubscribeToBroadcasts { get; set; }
    public string SubscribeFromIPAddress { get; set; }
    public string CurrencyCode { get; set; }
    public string PayableToName { get; set; }
    public DateTime EntryDate { get; set; }
    public int? DefaultWarehouseID { get; set; }
    public int? PayableType { get; set; }
    public Decimal? CheckThreshold { get; set; }
    public string TaxIDType { get; set; }
    public int LanguageID { get; set; }
    public Gender? Gender { get; set; }
    public string VatRegistration { get; set; }
    public DateTime? Date1 { get; set; }
    public DateTime? Date2 { get; set; }
    public DateTime? Date3 { get; set; }
    public DateTime? Date4 { get; set; }
    public DateTime? Date5 { get; set; }
    public string MiddleName { get; set; }
    public string NameSuffix { get; set; }
    public int? BinaryPlacementPreference { get; set; }
    public bool? UseBinaryHoldingTank { get; set; }
    public bool? MainAddressVerified { get; set; }
    public bool? MailAddressVerified { get; set; }
    public bool? OtherAddressVerified { get; set; }
    public string SponsorKey { get; set; }
    public string EnrollerKey { get; set; }
    public string ManualCustomerKey { get; set; }

    public CreateCustomerRequest() : base()
    {
        FirstName = String.Empty;
        LastName = String.Empty;
        Company = String.Empty;
        Email = String.Empty;
        Phone = String.Empty;
        Phone2 = String.Empty;
        MobilePhone = String.Empty;
        Fax = String.Empty;
        Notes = String.Empty;
        MainAddress1 = String.Empty;
        MainAddress2 = String.Empty;
        MainAddress3 = String.Empty;
        MainCity = String.Empty;
        MainState = String.Empty;
        MainZip = String.Empty;
        MainCountry = String.Empty;
        MainCounty = String.Empty;
        MailAddress1 = String.Empty;
        MailAddress2 = String.Empty;
        MailAddress3 = String.Empty;
        MailCity = String.Empty;
        MailState = String.Empty;
        MailZip = String.Empty;
        MailCountry = String.Empty;
        MailCounty = String.Empty;
        OtherAddress1 = String.Empty;
        OtherAddress2 = String.Empty;
        OtherAddress3 = String.Empty;
        OtherCity = String.Empty;
        OtherState = String.Empty;
        OtherZip = String.Empty;
        OtherCountry = String.Empty;
        OtherCounty = String.Empty;
        LoginName = String.Empty;
        LoginPassword = String.Empty;
        TaxID = String.Empty;
        SalesTaxID = String.Empty;
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
        SubscribeFromIPAddress = String.Empty;
        CurrencyCode = String.Empty;
        PayableToName = String.Empty;
        TaxIDType = String.Empty;
        VatRegistration = String.Empty;
        MiddleName = String.Empty;
        NameSuffix = String.Empty;
        SponsorKey = String.Empty;
        EnrollerKey = String.Empty;
        ManualCustomerKey = String.Empty;
    }
}
