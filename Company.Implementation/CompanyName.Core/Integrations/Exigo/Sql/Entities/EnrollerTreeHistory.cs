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

[PrimaryKey("EnrollerTreeHistoryId", "CustomerId")]
[Table("EnrollerTreeHistory")]
public partial class EnrollerTreeHistory
{
    [Key]
    [Column("EnrollerTreeHistoryID")]
    public int EnrollerTreeHistoryId { get; set; }

    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime MoveDate { get; set; }

    [Column("PreviousEnrollerID")]
    public int PreviousEnrollerId { get; set; }

    public int PreviousNestedLevel { get; set; }

    [Column("NewEnrollerID")]
    public int NewEnrollerId { get; set; }

    public int NewNestedLevel { get; set; }

    [StringLength(1000)]
    public string Reason { get; set; } = null!;
}
