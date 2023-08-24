using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("UnilevelTreeHistoryId", "CustomerId")]
[Table("UnilevelTreeHistory")]
public partial class UnilevelTreeHistory
{
    [Key]
    [Column("UnilevelTreeHistoryID")]
    public int UnilevelTreeHistoryId { get; set; }

    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime MoveDate { get; set; }

    [Column("PreviousSponsorID")]
    public int PreviousSponsorId { get; set; }

    public int PreviousNestedLevel { get; set; }

    [Column("NewSponsorID")]
    public int NewSponsorId { get; set; }

    public int NewNestedLevel { get; set; }

    [StringLength(1000)]
    public string Reason { get; set; } = null!;

    public int PreviousPlacement { get; set; }

    public int NewPlacement { get; set; }
}
