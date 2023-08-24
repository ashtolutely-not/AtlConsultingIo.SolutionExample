using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Index("CustomerId", Name = "IX_CustomerContacts_CustomerID")]
public partial class CustomerContact
{
    [Key]
    [Column("CustomerContactID")]
    public int CustomerContactId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(50)]
    public string Email { get; set; } = null!;

    [StringLength(20)]
    public string Phone { get; set; } = null!;

    [StringLength(20)]
    public string Phone2 { get; set; } = null!;

    [StringLength(20)]
    public string MobilePhone { get; set; } = null!;

    [StringLength(20)]
    public string Fax { get; set; } = null!;

    [StringLength(50)]
    public string Address1 { get; set; } = null!;

    [StringLength(50)]
    public string Address2 { get; set; } = null!;

    [StringLength(50)]
    public string City { get; set; } = null!;

    [StringLength(20)]
    public string State { get; set; } = null!;

    [StringLength(20)]
    public string Zip { get; set; } = null!;

    [StringLength(10)]
    public string Country { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}
