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

[Index("DistributorId", Name = "IX_Parties_DistributorID")]
[Index("HostId", Name = "IX_Parties_HostID")]
public partial class Party
{
    [Key]
    [Column("PartyID")]
    public int PartyId { get; set; }

    [Column("HostID")]
    public int HostId { get; set; }

    [Column("DistributorID")]
    public int DistributorId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CloseDate { get; set; }

    [StringLength(100)]
    public string Description { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? EventStartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EventEndDate { get; set; }

    [Column("PartyTypeID")]
    public int PartyTypeId { get; set; }

    [Column("PartyStatusID")]
    public int PartyStatusId { get; set; }

    [Column("LanguageID")]
    public int LanguageId { get; set; }

    [StringLength(500)]
    public string Information { get; set; } = null!;

    [StringLength(100)]
    public string Address1 { get; set; } = null!;

    [StringLength(100)]
    public string Address2 { get; set; } = null!;

    [StringLength(100)]
    public string City { get; set; } = null!;

    [StringLength(50)]
    public string State { get; set; } = null!;

    [StringLength(50)]
    public string Zip { get; set; } = null!;

    [StringLength(50)]
    public string Country { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [Column("BookingPartyID")]
    public int? BookingPartyId { get; set; }

    [StringLength(250)]
    public string? Field1 { get; set; }

    [StringLength(250)]
    public string? Field2 { get; set; }

    [StringLength(250)]
    public string? Field3 { get; set; }

    [StringLength(250)]
    public string? Field4 { get; set; }

    [StringLength(250)]
    public string? Field5 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column("PartyExternalID")]
    public Guid? PartyExternalId { get; set; }

    [StringLength(4000)]
    public string? PartyShoppingUrl { get; set; }

    [Column("TimezoneID")]
    [StringLength(510)]
    public string? TimezoneId { get; set; }

    [StringLength(1000)]
    public string? VirtualMeetingLink { get; set; }
}
