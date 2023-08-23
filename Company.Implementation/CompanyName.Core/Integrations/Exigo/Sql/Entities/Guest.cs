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

[Index("CustomerId", Name = "IX_Guests_CustomerID")]
[Index("HostId", Name = "IX_Guests_HostID")]
public partial class Guest
{
    [Key]
    [Column("GuestID")]
    public int GuestId { get; set; }

    [Column("CustomerID")]
    public int? CustomerId { get; set; }

    [Column("HostID")]
    public int HostId { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string MiddleName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(50)]
    public string NameSuffix { get; set; } = null!;

    [StringLength(50)]
    public string Company { get; set; } = null!;

    [StringLength(1)]
    public string Gender { get; set; } = null!;

    [Column("GuestStatusTypeID")]
    public int GuestStatusTypeId { get; set; }

    [Column("LanguageID")]
    public int LanguageId { get; set; }

    [StringLength(100)]
    public string Address1 { get; set; } = null!;

    [StringLength(100)]
    public string Address2 { get; set; } = null!;

    [StringLength(100)]
    public string Address3 { get; set; } = null!;

    [StringLength(50)]
    public string City { get; set; } = null!;

    [StringLength(50)]
    public string County { get; set; } = null!;

    [StringLength(50)]
    public string State { get; set; } = null!;

    [StringLength(50)]
    public string Zip { get; set; } = null!;

    [StringLength(50)]
    public string Country { get; set; } = null!;

    [StringLength(20)]
    public string Phone { get; set; } = null!;

    [StringLength(20)]
    public string Phone2 { get; set; } = null!;

    [StringLength(20)]
    public string MobilePhone { get; set; } = null!;

    [StringLength(50)]
    public string Email { get; set; } = null!;

    [StringLength(100)]
    public string Field1 { get; set; } = null!;

    [StringLength(100)]
    public string Field2 { get; set; } = null!;

    [StringLength(100)]
    public string Field3 { get; set; } = null!;

    [StringLength(100)]
    public string Field4 { get; set; } = null!;

    [StringLength(100)]
    public string Field5 { get; set; } = null!;

    [StringLength(100)]
    public string Field6 { get; set; } = null!;

    [StringLength(100)]
    public string Field7 { get; set; } = null!;

    [StringLength(100)]
    public string Field8 { get; set; } = null!;

    [StringLength(100)]
    public string Field9 { get; set; } = null!;

    [StringLength(100)]
    public string Field10 { get; set; } = null!;

    [StringLength(100)]
    public string Field11 { get; set; } = null!;

    [StringLength(100)]
    public string Field12 { get; set; } = null!;

    [StringLength(100)]
    public string Field13 { get; set; } = null!;

    [StringLength(100)]
    public string Field14 { get; set; } = null!;

    [StringLength(100)]
    public string Field15 { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? Date1 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Date2 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Date3 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Date4 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Date5 { get; set; }

    public string? Notes { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EntryDate { get; set; }

    [StringLength(30)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [StringLength(30)]
    public string ModifiedBy { get; set; } = null!;
}
