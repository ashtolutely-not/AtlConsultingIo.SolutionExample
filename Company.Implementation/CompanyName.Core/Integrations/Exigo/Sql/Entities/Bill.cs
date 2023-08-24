using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Index("BillId", "ModifiedDate", Name = "IX_BillIDModDt")]
[Index("CustomerId", "CreatedBy", Name = "IX_CustIDCreatedBy")]
public partial class Bill
{
    [Key]
    [Column("BillID")]
    public int BillId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("BillStatusID")]
    public int BillStatusId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DueDate { get; set; }

    [Column("BillTypeID")]
    public int BillTypeId { get; set; }

    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Amount { get; set; }

    [Column("CommissionRunID")]
    public int? CommissionRunId { get; set; }

    public bool IsOtherIncome { get; set; }

    [StringLength(50)]
    public string? Reference { get; set; }

    [Column("PayableTypeIDOverride")]
    public int? PayableTypeIdoverride { get; set; }

    [StringLength(500)]
    public string Notes { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [StringLength(30)]
    public string CreatedBy { get; set; } = null!;

    [StringLength(30)]
    public string ModifiedBy { get; set; } = null!;

    [Column("TaxablePeriodTypeID")]
    public int? TaxablePeriodTypeId { get; set; }

    [Column("TaxablePeriodID")]
    public int? TaxablePeriodId { get; set; }
}
