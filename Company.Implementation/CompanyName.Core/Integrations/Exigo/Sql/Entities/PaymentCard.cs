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

[Index("CustomerId", Name = "IX_PaymentCards_CustomerID")]
public partial class PaymentCard
{
    [Key]
    [Column("PaymentCardID")]
    public int PaymentCardId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("PaymentCardTypeID")]
    public int PaymentCardTypeId { get; set; }

    [StringLength(50)]
    public string? CardNumberDisplay { get; set; }

    public bool IsPrimary { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}
