using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("OrderId", "OrderLine")]
[Index("ItemCode", Name = "IX_ItemCode")]
public partial class OrderDetail
{
    [Key]
    [Column("OrderID")]
    public int OrderId { get; set; }

    [Key]
    public int OrderLine { get; set; }

    [Column("OrderDetailID")]
    public Guid? OrderDetailId { get; set; }

    [Column("ParentOrderDetailID")]
    public Guid? ParentOrderDetailId { get; set; }

    [Column("ItemID")]
    public int ItemId { get; set; }

    [StringLength(20)]
    public string ItemCode { get; set; } = null!;

    [StringLength(500)]
    public string ItemDescription { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Quantity { get; set; }

    [Column(TypeName = "money")]
    public decimal PriceEach { get; set; }

    [Column(TypeName = "money")]
    public decimal PriceTotal { get; set; }

    [Column(TypeName = "money")]
    public decimal Tax { get; set; }

    [Column(TypeName = "money")]
    public decimal WeightEach { get; set; }

    [Column(TypeName = "money")]
    public decimal? Weight { get; set; }

    [Column(TypeName = "money")]
    public decimal BusinessVolumeEach { get; set; }

    [Column(TypeName = "money")]
    public decimal BusinessVolume { get; set; }

    [Column(TypeName = "money")]
    public decimal CommissionableVolumeEach { get; set; }

    [Column(TypeName = "money")]
    public decimal CommissionableVolume { get; set; }

    [Column(TypeName = "money")]
    public decimal Other1Each { get; set; }

    [Column(TypeName = "money")]
    public decimal Other1 { get; set; }

    [Column(TypeName = "money")]
    public decimal Other2Each { get; set; }

    [Column(TypeName = "money")]
    public decimal Other2 { get; set; }

    [Column(TypeName = "money")]
    public decimal Other3Each { get; set; }

    [Column(TypeName = "money")]
    public decimal Other3 { get; set; }

    [Column(TypeName = "money")]
    public decimal Other4Each { get; set; }

    [Column(TypeName = "money")]
    public decimal Other4 { get; set; }

    [Column(TypeName = "money")]
    public decimal Other5Each { get; set; }

    [Column(TypeName = "money")]
    public decimal Other5 { get; set; }

    [Column(TypeName = "money")]
    public decimal OriginalTaxableEach { get; set; }

    [Column(TypeName = "money")]
    public decimal OriginalBusinessVolumeEach { get; set; }

    [Column(TypeName = "money")]
    public decimal OriginalCommissionableVolumeEach { get; set; }

    [Column(TypeName = "money")]
    public decimal Other6Each { get; set; }

    [Column(TypeName = "money")]
    public decimal Other6 { get; set; }

    [Column(TypeName = "money")]
    public decimal Other7Each { get; set; }

    [Column(TypeName = "money")]
    public decimal Other7 { get; set; }

    [Column(TypeName = "money")]
    public decimal Other8Each { get; set; }

    [Column(TypeName = "money")]
    public decimal Other8 { get; set; }

    [Column(TypeName = "money")]
    public decimal Other9Each { get; set; }

    [Column(TypeName = "money")]
    public decimal Other9 { get; set; }

    [Column(TypeName = "money")]
    public decimal Other10Each { get; set; }

    [Column(TypeName = "money")]
    public decimal Other10 { get; set; }

    [Column("ParentItemID")]
    public int? ParentItemId { get; set; }

    [Column(TypeName = "money")]
    public decimal Taxable { get; set; }

    [Column(TypeName = "money")]
    public decimal FedTax { get; set; }

    [Column(TypeName = "money")]
    public decimal StateTax { get; set; }

    [Column(TypeName = "money")]
    public decimal CityTax { get; set; }

    [Column(TypeName = "money")]
    public decimal CityLocalTax { get; set; }

    [Column(TypeName = "money")]
    public decimal CountyTax { get; set; }

    [Column(TypeName = "money")]
    public decimal CountyLocalTax { get; set; }

    [Column(TypeName = "money")]
    public decimal ManualTax { get; set; }

    public bool IsStateTaxOverride { get; set; }

    [StringLength(100)]
    public string Reference1 { get; set; } = null!;
}
