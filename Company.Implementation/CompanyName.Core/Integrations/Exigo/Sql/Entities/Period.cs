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

[PrimaryKey("PeriodTypeId", "PeriodId")]
[Index("StartDate", "EndDate", "PeriodTypeId", "PeriodId", Name = "IX_StDtEndDt")]
public partial class Period
{
    [Key]
    [Column("PeriodTypeID")]
    public int PeriodTypeId { get; set; }

    [Key]
    [Column("PeriodID")]
    public int PeriodId { get; set; }

    [StringLength(50)]
    public string PeriodDescription { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AcceptedDate { get; set; }
}
