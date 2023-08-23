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

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class CustomerExtendedGroup
{
    [Key]
    [Column("CustomerExtendedGroupID")]
    public int CustomerExtendedGroupId { get; set; }

    [StringLength(100)]
    public string CustomerExtendedGroupDescription { get; set; } = null!;

    [StringLength(100)]
    public string Field1Name { get; set; } = null!;

    [StringLength(100)]
    public string Field2Name { get; set; } = null!;

    [StringLength(100)]
    public string Field3Name { get; set; } = null!;

    [StringLength(100)]
    public string Field4Name { get; set; } = null!;

    [StringLength(100)]
    public string Field5Name { get; set; } = null!;

    [StringLength(100)]
    public string Field6Name { get; set; } = null!;

    [StringLength(100)]
    public string Field7Name { get; set; } = null!;

    [StringLength(100)]
    public string Field8Name { get; set; } = null!;

    [StringLength(100)]
    public string Field9Name { get; set; } = null!;

    [StringLength(100)]
    public string Field10Name { get; set; } = null!;

    [StringLength(100)]
    public string Field11Name { get; set; } = null!;

    [StringLength(100)]
    public string Field12Name { get; set; } = null!;

    [StringLength(100)]
    public string Field13Name { get; set; } = null!;

    [StringLength(100)]
    public string Field14Name { get; set; } = null!;

    [StringLength(100)]
    public string Field15Name { get; set; } = null!;

    [StringLength(100)]
    public string Field16Name { get; set; } = null!;

    [StringLength(100)]
    public string Field17Name { get; set; } = null!;

    [StringLength(100)]
    public string Field18Name { get; set; } = null!;

    [StringLength(100)]
    public string Field19Name { get; set; } = null!;

    [StringLength(100)]
    public string Field20Name { get; set; } = null!;

    [StringLength(100)]
    public string Field21Name { get; set; } = null!;

    [StringLength(100)]
    public string Field22Name { get; set; } = null!;

    [StringLength(100)]
    public string Field23Name { get; set; } = null!;

    [StringLength(100)]
    public string Field24Name { get; set; } = null!;

    [StringLength(100)]
    public string Field25Name { get; set; } = null!;

    [StringLength(100)]
    public string Field26Name { get; set; } = null!;

    [StringLength(100)]
    public string Field27Name { get; set; } = null!;

    [StringLength(100)]
    public string Field28Name { get; set; } = null!;

    [StringLength(100)]
    public string Field29Name { get; set; } = null!;

    [StringLength(100)]
    public string Field30Name { get; set; } = null!;
}
