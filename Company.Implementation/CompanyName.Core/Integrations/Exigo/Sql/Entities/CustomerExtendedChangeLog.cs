using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Index("CustomerId", Name = "IX_CustomerExtendedChangeLogs_CustomerId")]
public partial class CustomerExtendedChangeLog
{
    [Key]
    public int CustomerExtendedChangeLogId { get; set; }

    public int CustomerExtendedId { get; set; }

    public int ExtendedGroupId { get; set; }

    public int CustomerId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [StringLength(100)]
    public string ModifiedBy { get; set; } = null!;

    [StringLength(4000)]
    public string Detail { get; set; } = null!;
}
