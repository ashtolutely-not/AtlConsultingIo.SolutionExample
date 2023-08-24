using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("CustomerEventId", "CustomerId", "Key1", "Key2", "Key3")]
[Table("CustomerEventHistory")]
public partial class CustomerEventHistory
{
    [Key]
    [Column("CustomerEventID")]
    public int CustomerEventId { get; set; }

    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Key]
    public int Key1 { get; set; }

    [Key]
    public int Key2 { get; set; }

    [Key]
    public int Key3 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EntryDate { get; set; }
}
