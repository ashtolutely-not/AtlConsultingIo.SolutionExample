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

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class Currency
{
    [Key]
    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    [StringLength(50)]
    public string? CurrencyDescription { get; set; }

    [StringLength(10)]
    public string? CurrencySymbol { get; set; }
}
