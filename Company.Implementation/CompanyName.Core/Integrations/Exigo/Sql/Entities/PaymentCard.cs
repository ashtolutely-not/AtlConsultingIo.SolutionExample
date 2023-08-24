using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Index("CustomerId", Name = "IX_PaymentCards_CustomerID")]
public partial class PaymentCard
{
    [Key]
    [Column("PaymentCardID")]
    public int PaymentCardId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("PaymentCardTypeID")]
    public int PaymentCardTypeId { get; set; }

    [StringLength(50)]
    public string? CardNumberDisplay { get; set; }

    public bool IsPrimary { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}
