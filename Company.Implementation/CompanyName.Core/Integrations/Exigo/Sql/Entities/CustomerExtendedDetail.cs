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

[Index("CustomerId", Name = "IX_CustomerExtendedDetails_CustomerID")]
public partial class CustomerExtendedDetail
{
    [Key]
    [Column("CustomerExtendedDetailID")]
    public int CustomerExtendedDetailId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("CustomerExtendedGroupID")]
    public int CustomerExtendedGroupId { get; set; }

    [StringLength(200)]
    public string Field1 { get; set; } = null!;

    [StringLength(200)]
    public string Field2 { get; set; } = null!;

    [StringLength(200)]
    public string Field3 { get; set; } = null!;

    [StringLength(200)]
    public string Field4 { get; set; } = null!;

    [StringLength(200)]
    public string Field5 { get; set; } = null!;

    [StringLength(200)]
    public string Field6 { get; set; } = null!;

    [StringLength(200)]
    public string Field7 { get; set; } = null!;

    [StringLength(200)]
    public string Field8 { get; set; } = null!;

    [StringLength(200)]
    public string Field9 { get; set; } = null!;

    [StringLength(200)]
    public string Field10 { get; set; } = null!;

    [StringLength(200)]
    public string Field11 { get; set; } = null!;

    [StringLength(200)]
    public string Field12 { get; set; } = null!;

    [StringLength(200)]
    public string Field13 { get; set; } = null!;

    [StringLength(200)]
    public string Field14 { get; set; } = null!;

    [StringLength(200)]
    public string Field15 { get; set; } = null!;

    [StringLength(200)]
    public string Field16 { get; set; } = null!;

    [StringLength(200)]
    public string Field17 { get; set; } = null!;

    [StringLength(200)]
    public string Field18 { get; set; } = null!;

    [StringLength(200)]
    public string Field19 { get; set; } = null!;

    [StringLength(200)]
    public string Field20 { get; set; } = null!;

    [StringLength(200)]
    public string Field21 { get; set; } = null!;

    [StringLength(200)]
    public string Field22 { get; set; } = null!;

    [StringLength(200)]
    public string Field23 { get; set; } = null!;

    [StringLength(200)]
    public string Field24 { get; set; } = null!;

    [StringLength(200)]
    public string Field25 { get; set; } = null!;

    [StringLength(200)]
    public string Field26 { get; set; } = null!;

    [StringLength(200)]
    public string Field27 { get; set; } = null!;

    [StringLength(200)]
    public string Field28 { get; set; } = null!;

    [StringLength(200)]
    public string Field29 { get; set; } = null!;

    [StringLength(200)]
    public string Field30 { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}
