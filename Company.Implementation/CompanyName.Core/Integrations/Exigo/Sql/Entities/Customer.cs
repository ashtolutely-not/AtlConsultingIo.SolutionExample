using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Index("CustomerStatusId", "MainCountry", "CustomerTypeId", Name = "IX_CStID_MainCountry_CTyID_Inc")]
[Index("CreatedDate", "CustomerId", Name = "IX_CrDt_CuId_Inc")]
[Index("CreatedDate", Name = "IX_Createddate_INC")]
[Index("CustomerId", "CustomerTypeId", Name = "IX_CustID_CTypeID_Inc")]
[Index("CustomerStatusId", "CustomerTypeId", "CreatedDate", Name = "IX_CustStatusIDCustTypeIDCreatedDt")]
[Index("CustomerTypeId", "CustomerStatusId", "EnrollerId", Name = "IX_CustTyIdCustStIDEnrId")]
[Index("CustomerTypeId", "CustomerId", Name = "IX_CustTypeID_CustID_Inc")]
[Index("CustomerTypeId", "CustomerStatusId", Name = "IX_CustomerType_CustomerStatus")]
[Index("CustomerStatusId", Name = "IX_Customers_CustomerStatusID")]
[Index("CustomerTypeId", Name = "IX_Customers_CustomerTypeID")]
[Index("Email", Name = "IX_Customers_Email")]
[Index("EnrollerId", Name = "IX_Customers_EnrollerID")]
[Index("Field13", Name = "IX_Customers_Field13")]
[Index("Field2", "Field3", Name = "IX_Customers_Field2_Field3")]
[Index("Field3", Name = "IX_Customers_Field3")]
[Index("LoginName", Name = "IX_Customers_LoginName")]
[Index("ModifiedDate", Name = "IX_Customers_ModifiedDate")]
[Index("CustomerTypeId", "Phone", Name = "IX_Customers_Phone_CustType")]
[Index("CustomerTypeId", "CustomerStatusId", "CustomerId", "LastName", Name = "IX_Customers_Type_Status_ID_Last")]
[Index("EnrollerId", "CustomerTypeId", Name = "IX_EnrID_CustTypeID_Inc")]
[Index("Field8", Name = "IX_Field8")]
[Index("CustomerId", Name = "IX_SalesForce")]
[Index("EnrollerId", "CustomerStatusId", "CustomerId", Name = "_dta_index_Customers_9_37949536__K45_K8_K1_2_4_9_10_18_20_44_88")]
public partial class Customer
{
    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string MiddleName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(50)]
    public string NameSuffix { get; set; } = null!;

    [StringLength(100)]
    public string Company { get; set; } = null!;

    [Column("CustomerTypeID")]
    public int CustomerTypeId { get; set; }

    [Column("CustomerStatusID")]
    public int CustomerStatusId { get; set; }

    [StringLength(50)]
    public string Email { get; set; } = null!;

    [StringLength(20)]
    public string Phone { get; set; } = null!;

    [StringLength(20)]
    public string Phone2 { get; set; } = null!;

    [StringLength(20)]
    public string MobilePhone { get; set; } = null!;

    [StringLength(20)]
    public string Fax { get; set; } = null!;

    [StringLength(100)]
    public string MainAddress1 { get; set; } = null!;

    [StringLength(100)]
    public string? MainAddress2 { get; set; }

    [StringLength(100)]
    public string MainAddress3 { get; set; } = null!;

    [StringLength(50)]
    public string MainCity { get; set; } = null!;

    [StringLength(50)]
    public string MainState { get; set; } = null!;

    [StringLength(50)]
    public string MainZip { get; set; } = null!;

    [StringLength(50)]
    public string MainCountry { get; set; } = null!;

    [StringLength(50)]
    public string MainCounty { get; set; } = null!;

    public bool MainVerified { get; set; }

    [StringLength(100)]
    public string MailAddress1 { get; set; } = null!;

    [StringLength(100)]
    public string? MailAddress2 { get; set; }

    [StringLength(100)]
    public string MailAddress3 { get; set; } = null!;

    [StringLength(50)]
    public string MailCity { get; set; } = null!;

    [StringLength(50)]
    public string MailState { get; set; } = null!;

    [StringLength(50)]
    public string MailZip { get; set; } = null!;

    [StringLength(50)]
    public string MailCountry { get; set; } = null!;

    [StringLength(50)]
    public string MailCounty { get; set; } = null!;

    public bool MailVerified { get; set; }

    [StringLength(100)]
    public string OtherAddress1 { get; set; } = null!;

    [StringLength(100)]
    public string? OtherAddress2 { get; set; }

    [StringLength(100)]
    public string OtherAddress3 { get; set; } = null!;

    [StringLength(50)]
    public string OtherCity { get; set; } = null!;

    [StringLength(50)]
    public string OtherState { get; set; } = null!;

    [StringLength(50)]
    public string OtherZip { get; set; } = null!;

    [StringLength(50)]
    public string OtherCountry { get; set; } = null!;

    [StringLength(50)]
    public string OtherCounty { get; set; } = null!;

    public bool OtherVerified { get; set; }

    public bool CanLogin { get; set; }

    [StringLength(100)]
    public string? LoginName { get; set; }

    [MaxLength(50)]
    public byte[]? PasswordHash { get; set; }

    [Column("RankID")]
    public int? RankId { get; set; }

    [Column("EnrollerID")]
    public int? EnrollerId { get; set; }

    [Column("SponsorID")]
    public int? SponsorId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? BirthDate { get; set; }

    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    [StringLength(50)]
    public string PayableToName { get; set; } = null!;

    [Column("DefaultWarehouseID")]
    public int? DefaultWarehouseId { get; set; }

    [Column("PayableTypeID")]
    public int PayableTypeId { get; set; }

    [Column(TypeName = "money")]
    public decimal CheckThreshold { get; set; }

    [Column("LanguageID")]
    public int? LanguageId { get; set; }

    [StringLength(1)]
    public string Gender { get; set; } = null!;

    [StringLength(50)]
    public string? TaxCode { get; set; }

    [Column("TaxCodeTypeID")]
    public int TaxCodeTypeId { get; set; }

    public bool IsSalesTaxExempt { get; set; }

    [StringLength(50)]
    public string? SalesTaxCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SalesTaxExemptExpireDate { get; set; }

    [StringLength(50)]
    public string VatRegistration { get; set; } = null!;

    [Column("BinaryPlacementTypeID")]
    public int BinaryPlacementTypeId { get; set; }

    public bool UseBinaryHoldingTank { get; set; }

    public bool IsInBinaryHoldingTank { get; set; }

    public bool? IsEmailSubscribed { get; set; }

    [Column("EmailSubscribeIP")]
    [StringLength(50)]
    public string? EmailSubscribeIp { get; set; }

    [Column("IsSMSSubscribed")]
    public bool? IsSmssubscribed { get; set; }

    public string? Notes { get; set; }

    [StringLength(100)]
    public string Field1 { get; set; } = null!;

    [StringLength(100)]
    public string Field2 { get; set; } = null!;

    [StringLength(100)]
    public string Field3 { get; set; } = null!;

    [StringLength(100)]
    public string Field4 { get; set; } = null!;

    [StringLength(100)]
    public string Field5 { get; set; } = null!;

    [StringLength(100)]
    public string Field6 { get; set; } = null!;

    [StringLength(100)]
    public string Field7 { get; set; } = null!;

    [StringLength(100)]
    public string Field8 { get; set; } = null!;

    [StringLength(100)]
    public string Field9 { get; set; } = null!;

    [StringLength(100)]
    public string Field10 { get; set; } = null!;

    [StringLength(100)]
    public string Field11 { get; set; } = null!;

    [StringLength(100)]
    public string Field12 { get; set; } = null!;

    [StringLength(100)]
    public string Field13 { get; set; } = null!;

    [StringLength(100)]
    public string Field14 { get; set; } = null!;

    [StringLength(100)]
    public string Field15 { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? Date1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Date2 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Date3 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Date4 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Date5 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [StringLength(30)]
    public string CreatedBy { get; set; } = null!;

    [StringLength(30)]
    public string ModifiedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? EmailUnsubscribeDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EmailSubscribeDate { get; set; }

    [Column("SMSSubscribeDate", TypeName = "datetime")]
    public DateTime? SmssubscribeDate { get; set; }

    [Column("SMSUnsubscribeDate", TypeName = "datetime")]
    public DateTime? SmsunsubscribeDate { get; set; }

    public int? TerminationReason { get; set; }

    [StringLength(50)]
    public string? CustomerKey { get; set; }
}
