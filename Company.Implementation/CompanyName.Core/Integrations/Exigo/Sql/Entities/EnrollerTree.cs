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

[Table("EnrollerTree")]
[Index("EnrollerId", Name = "IX_EnrollerTree_EnrollerID")]
[Index("Lft", Name = "IX_EnrollerTree_Lft")]
[Index("Lft", "Rgt", Name = "IX_LftRgt")]
public partial class EnrollerTree
{
    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("EnrollerID")]
    public int EnrollerId { get; set; }

    public int NestedLevel { get; set; }

    public int Lft { get; set; }

    public int Rgt { get; set; }
}
