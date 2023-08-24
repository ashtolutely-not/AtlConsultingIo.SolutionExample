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
