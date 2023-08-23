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

[PrimaryKey("ItemId", "CountryCode", "RegionCode")]
[Index("CountryCode", "ItemId", Name = "IX_CoCod_ItemID")]
public partial class ItemCountryRegion
{
    [Key]
    [Column("ItemID")]
    public int ItemId { get; set; }

    [Key]
    [StringLength(2)]
    public string CountryCode { get; set; } = null!;

    [Key]
    [StringLength(3)]
    public string RegionCode { get; set; } = null!;

    public bool UseTaxOverride { get; set; }

    [Column(TypeName = "money")]
    public decimal TaxOverridePercent { get; set; }

    public int Taxed { get; set; }

    public int TaxedFederal { get; set; }

    public int TaxedState { get; set; }
}
