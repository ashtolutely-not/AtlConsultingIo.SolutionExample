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

[PrimaryKey("CommissionRunId", "CustomerId", "BonusId")]
public partial class CommissionBonus
{
    [Key]
    [Column("CommissionRunID")]
    public int CommissionRunId { get; set; }

    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Key]
    [Column("BonusID")]
    public int BonusId { get; set; }

    [Column(TypeName = "money")]
    public decimal Amount { get; set; }
}
