using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("ItemId", "CurrencyCode", "PriceTypeId")]
[Index("CurrencyCode", "PriceTypeId", Name = "IX_ItemPrices_Currency_PriceType")]
public partial class ItemPrice
{
    [Key]
    [Column("ItemID")]
    public int ItemId { get; set; }

    [Key]
    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    [Key]
    [Column("PriceTypeID")]
    public int PriceTypeId { get; set; }

    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    [Column(TypeName = "money")]
    public decimal CommissionableVolume { get; set; }

    [Column(TypeName = "money")]
    public decimal BusinessVolume { get; set; }

    [Column(TypeName = "money")]
    public decimal TaxablePrice { get; set; }

    [Column(TypeName = "money")]
    public decimal ShippingPrice { get; set; }

    [Column(TypeName = "money")]
    public decimal Other1Price { get; set; }

    [Column(TypeName = "money")]
    public decimal Other2Price { get; set; }

    [Column(TypeName = "money")]
    public decimal Other3Price { get; set; }

    [Column(TypeName = "money")]
    public decimal Other4Price { get; set; }

    [Column(TypeName = "money")]
    public decimal Other5Price { get; set; }

    [Column(TypeName = "money")]
    public decimal Other6Price { get; set; }

    [Column(TypeName = "money")]
    public decimal Other7Price { get; set; }

    [Column(TypeName = "money")]
    public decimal Other8Price { get; set; }

    [Column(TypeName = "money")]
    public decimal Other9Price { get; set; }

    [Column(TypeName = "money")]
    public decimal Other10Price { get; set; }
}
