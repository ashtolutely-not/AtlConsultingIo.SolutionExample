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

[PrimaryKey("CommissionRunId", "CustomerId")]
[Index("CustomerId", Name = "IX_CustID")]
[Index("Earnings", Name = "NonClusteredIndex-20200814-190823")]
public partial class Commission
{
    [Key]
    [Column("CommissionRunID")]
    public int CommissionRunId { get; set; }

    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Earnings { get; set; }

    [Column(TypeName = "money")]
    public decimal PreviousBalance { get; set; }

    [Column(TypeName = "money")]
    public decimal BalanceForward { get; set; }

    [Column(TypeName = "money")]
    public decimal Fee { get; set; }

    [Column(TypeName = "money")]
    public decimal Total { get; set; }
}
