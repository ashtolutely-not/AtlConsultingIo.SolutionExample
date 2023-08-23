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

public partial class VolumePushCycleLog
{
    [Key]
    [Column("VolumePushCycleLogID")]
    public int VolumePushCycleLogId { get; set; }

    [Column("CommissionPlanID")]
    public int? CommissionPlanId { get; set; }

    [Column("PeriodID")]
    public int? PeriodId { get; set; }

    [Column("PeriodTypeID")]
    public int? PeriodTypeId { get; set; }

    public bool? VolumePushIsTrueUp { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? VolumePushCycleStartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? VolumePushCycleEndDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? VolumePushCycleErrorDate { get; set; }
}
