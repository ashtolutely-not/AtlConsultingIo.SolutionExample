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

[Index("WebAlias", Name = "IX_CustomerSites_WebAlias")]
public partial class CustomerSite
{
    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [StringLength(100)]
    public string WebAlias { get; set; } = null!;

    [StringLength(100)]
    public string FirstName { get; set; } = null!;

    [StringLength(100)]
    public string LastName { get; set; } = null!;

    [StringLength(255)]
    public string Company { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    [StringLength(100)]
    public string Phone { get; set; } = null!;

    [StringLength(100)]
    public string Phone2 { get; set; } = null!;

    [StringLength(100)]
    public string Fax { get; set; } = null!;

    [StringLength(200)]
    public string Address1 { get; set; } = null!;

    [StringLength(200)]
    public string Address2 { get; set; } = null!;

    [StringLength(100)]
    public string City { get; set; } = null!;

    [StringLength(100)]
    public string State { get; set; } = null!;

    [StringLength(100)]
    public string Zip { get; set; } = null!;

    [StringLength(50)]
    public string Country { get; set; } = null!;

    public string Notes1 { get; set; } = null!;

    public string Notes2 { get; set; } = null!;

    public string Notes3 { get; set; } = null!;

    public string Notes4 { get; set; } = null!;

    [StringLength(200)]
    public string Url1 { get; set; } = null!;

    [StringLength(200)]
    public string Url2 { get; set; } = null!;

    [StringLength(200)]
    public string Url3 { get; set; } = null!;

    [StringLength(200)]
    public string Url4 { get; set; } = null!;

    [StringLength(200)]
    public string Url5 { get; set; } = null!;

    [StringLength(200)]
    public string Url6 { get; set; } = null!;

    [StringLength(200)]
    public string Url7 { get; set; } = null!;

    [StringLength(200)]
    public string Url8 { get; set; } = null!;

    [StringLength(200)]
    public string Url9 { get; set; } = null!;

    [StringLength(200)]
    public string Url10 { get; set; } = null!;

    [StringLength(200)]
    public string Url1Description { get; set; } = null!;

    [StringLength(200)]
    public string Url2Description { get; set; } = null!;

    [StringLength(200)]
    public string Url3Description { get; set; } = null!;

    [StringLength(200)]
    public string Url4Description { get; set; } = null!;

    [StringLength(200)]
    public string Url5Description { get; set; } = null!;

    [StringLength(200)]
    public string Url6Description { get; set; } = null!;

    [StringLength(200)]
    public string Url7Description { get; set; } = null!;

    [StringLength(200)]
    public string Url8Description { get; set; } = null!;

    [StringLength(200)]
    public string Url9Description { get; set; } = null!;

    [StringLength(200)]
    public string Url10Description { get; set; } = null!;

    public byte[]? DataImage1 { get; set; }

    [StringLength(200)]
    public string? DataImageType1 { get; set; }

    public byte[]? DataImage2 { get; set; }

    [StringLength(200)]
    public string? DataImageType2 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}
