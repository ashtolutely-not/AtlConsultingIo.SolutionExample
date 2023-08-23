using CompanyName.Core;
using CompanyName.Core.Entities;
using CompanyName.Core.Entities.Events;
using CompanyName.Core.Entities.Messaging;
using CompanyName.Core.Entities.Order;
using CompanyName.Core.Entities.Product;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;
using CompanyName.Core.Integrations.Exigo.Sql;
using CompanyName.Core.Integrations.KountApi;
using CompanyName.Core.Integrations.SendGridApi;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Table("CustomerWall")]
[Index("CustomerId", "Field1", Name = "IX_CustIDField1")]
[Index("CustomerId", Name = "IX_CustomerWall_CustomerID")]
public partial class CustomerWall
{
    [Key]
    [Column("CustomerWallItemID")]
    public int CustomerWallItemId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EntryDate { get; set; }

    [StringLength(2000)]
    public string Text { get; set; } = null!;

    [StringLength(50)]
    public string? Field1 { get; set; }

    [StringLength(50)]
    public string? Field2 { get; set; }

    [StringLength(50)]
    public string? Field3 { get; set; }
}
