using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("ItemId", "SubscriptionId")]
public partial class ItemSubscription
{
    [Key]
    [Column("ItemID")]
    public int ItemId { get; set; }

    [Key]
    [Column("SubscriptionID")]
    public int SubscriptionId { get; set; }

    public int DaysEach { get; set; }
}
