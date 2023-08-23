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
