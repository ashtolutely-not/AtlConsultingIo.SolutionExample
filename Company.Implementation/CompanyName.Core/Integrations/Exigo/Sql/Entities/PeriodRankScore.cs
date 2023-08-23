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

[PrimaryKey("PeriodTypeId", "PeriodId", "CustomerId", "PaidRankId")]
[Index("CustomerId", "Score", Name = "IX_PeriodRankScore")]
public partial class PeriodRankScore
{
    [Key]
    [Column("PeriodTypeID")]
    public int PeriodTypeId { get; set; }

    [Key]
    [Column("PeriodID")]
    public int PeriodId { get; set; }

    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Key]
    [Column("PaidRankID")]
    public int PaidRankId { get; set; }

    [Column(TypeName = "money")]
    public decimal Score { get; set; }
}
