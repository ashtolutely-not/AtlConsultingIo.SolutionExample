using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("CommissionRunId", "CustomerId")]
[Index("CustomerId", Name = "IX_CommCustomers_PaidRank")]
public partial class CommissionCustomer
{
    [Key]
    [Column("CommissionRunID")]
    public int CommissionRunId { get; set; }

    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("CustomerTypeID")]
    public int CustomerTypeId { get; set; }

    [Column("CustomerStatusID")]
    public int CustomerStatusId { get; set; }

    [Column("RankID")]
    public int? RankId { get; set; }

    [Column("NewRankID")]
    public int? NewRankId { get; set; }

    [Column("PaidRankID")]
    public int? PaidRankId { get; set; }

    [StringLength(50)]
    public string? Country { get; set; }
}
