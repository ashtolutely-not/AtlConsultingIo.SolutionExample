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

[PrimaryKey("WarehouseId", "BatchId", "PrintedDate")]
public partial class OrderBatch
{
    [Key]
    [Column("WarehouseID")]
    public int WarehouseId { get; set; }

    [Key]
    [Column("BatchID")]
    public int BatchId { get; set; }

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime PrintedDate { get; set; }

    public int TotalOrders { get; set; }
}
