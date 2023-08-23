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
