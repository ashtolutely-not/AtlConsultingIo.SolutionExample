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

[Index("CodingTypeId", Name = "IX_CodedRanks_CodingTypeID")]
[Index("CustomerId", Name = "IX_CodedRanks_CustomerID")]
public partial class CodedRank
{
    [Key]
    [Column("CodedRankEntryID")]
    public int CodedRankEntryId { get; set; }

    [Column("CodingTypeID")]
    public int CodingTypeId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("RankID")]
    public int RankId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CodedDate { get; set; }

    [Column("CodedToCustomerID")]
    public int CodedToCustomerId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EntryDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}
