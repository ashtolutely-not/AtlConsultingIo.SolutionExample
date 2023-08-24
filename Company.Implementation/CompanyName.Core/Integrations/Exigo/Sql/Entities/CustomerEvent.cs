using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class CustomerEvent
{
    [Key]
    [Column("CustomerEventID")]
    public int CustomerEventId { get; set; }

    [StringLength(50)]
    public string CustomerEventDescription { get; set; } = null!;

    [StringLength(50)]
    public string Key1Description { get; set; } = null!;

    [StringLength(50)]
    public string Key2Description { get; set; } = null!;

    [StringLength(50)]
    public string Key3Description { get; set; } = null!;

    public string Notes { get; set; } = null!;
}
