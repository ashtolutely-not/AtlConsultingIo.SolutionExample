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

public partial class CustomerEvent
{
    [Key]
    [Column("CustomerEventID")]
    public int CustomerEventId { get; set; }

    [StringLength(50)]
    public string CustomerEventDescription { get; set; } = null!;

    [StringLength(50)]
    public string Key1Description { get; set; } = null!;

    [StringLength(50)]
    public string Key2Description { get; set; } = null!;

    [StringLength(50)]
    public string Key3Description { get; set; } = null!;

    public string Notes { get; set; } = null!;
}
