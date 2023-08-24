using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class SmsStatus
{
    [Key]
    [Column("SmsStatusID")]
    public int SmsStatusId { get; set; }

    [StringLength(50)]
    public string SmsStatusDescription { get; set; } = null!;
}
