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

public partial class PointAccount
{
    [Key]
    [Column("PointAccountID")]
    public int PointAccountId { get; set; }

    [StringLength(50)]
    public string PointAccountDescription { get; set; } = null!;

    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    public bool? CanPayForOrders { get; set; }

    public bool? LimitPaymentToSubTotal { get; set; }
}
