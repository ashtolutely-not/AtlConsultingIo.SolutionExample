using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("PartyId", "GuestId")]
public partial class PartyGuest
{
    [Key]
    [Column("PartyID")]
    public int PartyId { get; set; }

    [Key]
    [Column("GuestID")]
    public int GuestId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}
