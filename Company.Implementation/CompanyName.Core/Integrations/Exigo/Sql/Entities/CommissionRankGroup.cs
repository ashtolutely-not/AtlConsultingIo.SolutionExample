using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("CommissionRunId", "CustomerId", "RankGroupId")]
public partial class CommissionRankGroup
{
    [Key]
    [Column("CommissionRunID")]
    public int CommissionRunId { get; set; }

    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Key]
    [Column("RankGroupID")]
    public int RankGroupId { get; set; }

    [Column("RankID")]
    public int RankId { get; set; }

    [Column("PaidRankID")]
    public int PaidRankId { get; set; }

    [Column("LegRankID")]
    public int LegRankId { get; set; }
}
