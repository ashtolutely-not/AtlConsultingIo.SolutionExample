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

[PrimaryKey("ItemId", "LanguageId")]
public partial class ItemLanguage
{
    [Key]
    [Column("ItemID")]
    public int ItemId { get; set; }

    [Key]
    [Column("LanguageID")]
    public int LanguageId { get; set; }

    [StringLength(255)]
    public string ItemDescription { get; set; } = null!;

    [StringLength(2048)]
    public string ShortDetail { get; set; } = null!;

    [StringLength(2048)]
    public string ShortDetail2 { get; set; } = null!;

    [StringLength(2048)]
    public string ShortDetail3 { get; set; } = null!;

    [StringLength(2048)]
    public string ShortDetail4 { get; set; } = null!;

    public string LongDetail { get; set; } = null!;

    public string LongDetail2 { get; set; } = null!;

    public string LongDetail3 { get; set; } = null!;

    public string LongDetail4 { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}
