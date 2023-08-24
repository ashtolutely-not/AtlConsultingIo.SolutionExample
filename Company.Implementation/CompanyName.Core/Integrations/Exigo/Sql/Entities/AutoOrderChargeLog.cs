using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Table("AutoOrderChargeLog")]
public partial class AutoOrderChargeLog
{
    [Key]
    [Column("AutoOrderChargeLogID")]
    public int AutoOrderChargeLogId { get; set; }

    [Column("PaymentTypeID")]
    public int PaymentTypeId { get; set; }

    [Column("WarehouseID")]
    public int WarehouseId { get; set; }

    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    [Column("OrderID")]
    public int OrderId { get; set; }

    [Column(TypeName = "money")]
    public decimal Amount { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EntryDate { get; set; }

    [Column("BatchID")]
    public int BatchId { get; set; }

    public bool IsAuthorized { get; set; }

    [StringLength(1000)]
    public string ServerResponse { get; set; } = null!;

    [Column("PaymentID")]
    public int? PaymentId { get; set; }
}
