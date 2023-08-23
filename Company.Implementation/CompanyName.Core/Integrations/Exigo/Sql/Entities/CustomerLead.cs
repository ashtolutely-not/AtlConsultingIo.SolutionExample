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

[Index("CustomerId", Name = "IX_CustomerLeads_CustomerID")]
public partial class CustomerLead
{
    [Key]
    [Column("CustomerLeadID")]
    public int CustomerLeadId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(50)]
    public string Company { get; set; } = null!;

    [StringLength(50)]
    public string Email { get; set; } = null!;

    [StringLength(50)]
    public string Phone { get; set; } = null!;

    [StringLength(50)]
    public string Phone2 { get; set; } = null!;

    [StringLength(50)]
    public string MobilePhone { get; set; } = null!;

    [StringLength(50)]
    public string Fax { get; set; } = null!;

    [StringLength(50)]
    public string Address1 { get; set; } = null!;

    [StringLength(50)]
    public string Address2 { get; set; } = null!;

    [StringLength(50)]
    public string City { get; set; } = null!;

    [StringLength(50)]
    public string State { get; set; } = null!;

    [StringLength(50)]
    public string Zip { get; set; } = null!;

    [StringLength(50)]
    public string Country { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? BirthDate { get; set; }

    [StringLength(2000)]
    public string Notes { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}
