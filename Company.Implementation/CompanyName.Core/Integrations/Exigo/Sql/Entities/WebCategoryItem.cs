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

[PrimaryKey("WebId", "WebCategoryId", "ItemId")]
public partial class WebCategoryItem
{
    [Key]
    [Column("WebID")]
    public int WebId { get; set; }

    [Key]
    [Column("WebCategoryID")]
    public int WebCategoryId { get; set; }

    [Key]
    [Column("ItemID")]
    public int ItemId { get; set; }

    public int SortOrder { get; set; }
}
