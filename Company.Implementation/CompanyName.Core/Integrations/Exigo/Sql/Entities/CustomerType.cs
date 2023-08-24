using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class CustomerType
{
    [Key]
    [Column("CustomerTypeID")]
    public int CustomerTypeId { get; set; }

    [StringLength(50)]
    public string CustomerTypeDescription { get; set; } = null!;

    [Column("PriceTypeID")]
    public int PriceTypeId { get; set; }
}
