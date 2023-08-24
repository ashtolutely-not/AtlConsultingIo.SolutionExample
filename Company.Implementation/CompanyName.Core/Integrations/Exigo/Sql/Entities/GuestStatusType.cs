using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class GuestStatusType
{
    [Key]
    [Column("GuestStatusTypeID")]
    public int GuestStatusTypeId { get; set; }

    [StringLength(50)]
    public string GuestStatusTypeDescription { get; set; } = null!;
}
