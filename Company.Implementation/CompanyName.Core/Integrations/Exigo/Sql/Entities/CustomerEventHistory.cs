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

[PrimaryKey("CustomerEventId", "CustomerId", "Key1", "Key2", "Key3")]
[Table("CustomerEventHistory")]
public partial class CustomerEventHistory
{
    [Key]
    [Column("CustomerEventID")]
    public int CustomerEventId { get; set; }

    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Key]
    public int Key1 { get; set; }

    [Key]
    public int Key2 { get; set; }

    [Key]
    public int Key3 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EntryDate { get; set; }
}
