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

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("AutoOrderId", "OrderLine")]
public partial class AutoOrderDetail
{
    [Key]
    [Column("AutoOrderID")]
    public int AutoOrderId { get; set; }

    [Key]
    public int OrderLine { get; set; }

    [Column("AutoOrderDetailID")]
    public Guid? AutoOrderDetailId { get; set; }

    [Column("ParentAutoOrderDetailID")]
    public Guid? ParentAutoOrderDetailId { get; set; }

    [Column("ItemID")]
    public int ItemId { get; set; }

    public string? ItemCode { get; set; }

    [StringLength(255)]
    public string ItemDescription { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Quantity { get; set; }

    [Column(TypeName = "money")]
    public decimal PriceEach { get; set; }

    [Column(TypeName = "money")]
    public decimal PriceTotal { get; set; }

    [Column(TypeName = "money")]
    public decimal BusinessVolumeEach { get; set; }

    [Column(TypeName = "money")]
    public decimal BusinessVolume { get; set; }

    [Column(TypeName = "money")]
    public decimal CommissionableVolumeEach { get; set; }

    [Column(TypeName = "money")]
    public decimal CommissionableVolume { get; set; }

    [Column(TypeName = "money")]
    public decimal? PriceEachOverride { get; set; }

    [Column(TypeName = "money")]
    public decimal? TaxableEachOverride { get; set; }

    [Column(TypeName = "money")]
    public decimal? ShippingPriceEachOverride { get; set; }

    [Column(TypeName = "money")]
    public decimal? BusinessVolumeEachOverride { get; set; }

    [Column(TypeName = "money")]
    public decimal? CommissionableVolumeEachOverride { get; set; }

    [Column("ParentItemID")]
    public int? ParentItemId { get; set; }

    [StringLength(100)]
    public string Reference1 { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? DetailStartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DetailEndDate { get; set; }

    public int? DetailInterval { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DetailNextRunDate { get; set; }
}
