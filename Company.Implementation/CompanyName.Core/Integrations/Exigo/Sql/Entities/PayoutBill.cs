using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Index("BillId", "PayoutId", Name = "IX_BillID_PayoutID")]
[Index("ModifiedDate", Name = "IX_MoDt_PayOId_Inc")]
[Index("BillId", "ModifiedDate", Name = "IX_PayoutBills")]
public partial class PayoutBill
{
    [Key]
    [Column("TransactionID")]
    public int TransactionId { get; set; }

    [Column("PayoutID")]
    public int? PayoutId { get; set; }

    [Column("BillID")]
    public int? BillId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}
