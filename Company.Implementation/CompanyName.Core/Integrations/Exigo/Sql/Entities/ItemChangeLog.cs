using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Table("ItemChangeLog")]
[Index("ItemId", Name = "IX_ItemChangeLog_ItemID")]
public partial class ItemChangeLog
{
    [Key]
    [Column("ItemChangeLogID")]
    public int ItemChangeLogId { get; set; }

    [Column("ItemID")]
    public int ItemId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [StringLength(50)]
    public string ModifiedBy { get; set; } = null!;

    public string Detail { get; set; } = null!;
}
