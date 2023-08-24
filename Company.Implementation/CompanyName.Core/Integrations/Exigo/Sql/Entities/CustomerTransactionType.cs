using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class CustomerTransactionType
{
    [Key]
    [Column("CustomerTransactionTypeID")]
    public int CustomerTransactionTypeId { get; set; }

    [StringLength(50)]
    public string CustomerTransactionTypeDescription { get; set; } = null!;
}
