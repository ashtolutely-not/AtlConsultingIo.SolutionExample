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

public partial class Warehouse
{
    [Key]
    [Column("WarehouseID")]
    public int WarehouseId { get; set; }

    [StringLength(50)]
    public string WarehouseDescription { get; set; } = null!;

    [StringLength(50)]
    public string WarehouseAddress1 { get; set; } = null!;

    [StringLength(50)]
    public string WarehouseAddress2 { get; set; } = null!;

    [StringLength(30)]
    public string WarehouseCity { get; set; } = null!;

    [StringLength(10)]
    public string WarehouseState { get; set; } = null!;

    [StringLength(20)]
    public string WarehouseZip { get; set; } = null!;

    [StringLength(20)]
    public string WarehouseCountry { get; set; } = null!;

    [Column("TimeZoneID")]
    public int TimeZoneId { get; set; }
}
