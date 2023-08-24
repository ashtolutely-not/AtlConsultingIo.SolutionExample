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
