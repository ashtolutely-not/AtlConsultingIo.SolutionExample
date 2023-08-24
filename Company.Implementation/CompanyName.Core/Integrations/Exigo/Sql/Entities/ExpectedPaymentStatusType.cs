using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class ExpectedPaymentStatusType
{
    [Key]
    [Column("ExpectedPaymentStatusTypeID")]
    public int ExpectedPaymentStatusTypeId { get; set; }

    [StringLength(50)]
    public string Description { get; set; } = null!;
}
