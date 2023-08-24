using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Index("AvailableAllCountryRegions", "OtherCheck3", "OtherCheck5", Name = "IX_AvAllCtyReg_OtherCk3_OtherCk3_INC")]
[Index("OtherCheck5", Name = "IX_OthCk5_Inc")]
[Index("OtherCheck5", "OtherCheck3", Name = "IX_OthCks_Inc")]
public partial class Item
{
    [Key]
    [Column("ItemID")]
    public int ItemId { get; set; }

    [StringLength(20)]
    public string ItemCode { get; set; } = null!;

    [StringLength(500)]
    public string ItemDescription { get; set; } = null!;

    [Column("ItemTypeID")]
    public int ItemTypeId { get; set; }

    [StringLength(2048)]
    public string ShortDetail { get; set; } = null!;

    [StringLength(2048)]
    public string ShortDetail2 { get; set; } = null!;

    [StringLength(2048)]
    public string ShortDetail3 { get; set; } = null!;

    [StringLength(2048)]
    public string ShortDetail4 { get; set; } = null!;

    public string LongDetail { get; set; } = null!;

    public string LongDetail2 { get; set; } = null!;

    public string LongDetail3 { get; set; } = null!;

    public string LongDetail4 { get; set; } = null!;

    [StringLength(2048)]
    public string Notes { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Weight { get; set; }

    public bool IsVirtual { get; set; }

    public bool IsGroupMaster { get; set; }

    public bool SuppressGroupMaster { get; set; }

    [StringLength(500)]
    public string GroupDescription { get; set; } = null!;

    [StringLength(500)]
    public string GroupMembersDescription { get; set; } = null!;

    public bool AllowOnAutoOrder { get; set; }

    public bool HideFromSearch { get; set; }

    public bool AvailableAllCountryRegions { get; set; }

    [StringLength(255)]
    public string TinyImageName { get; set; } = null!;

    [StringLength(255)]
    public string SmallImageName { get; set; } = null!;

    [StringLength(255)]
    public string LargeImageName { get; set; } = null!;

    [StringLength(100)]
    public string Field1 { get; set; } = null!;

    [StringLength(100)]
    public string Field2 { get; set; } = null!;

    [StringLength(100)]
    public string Field3 { get; set; } = null!;

    [StringLength(100)]
    public string Field4 { get; set; } = null!;

    [StringLength(100)]
    public string Field5 { get; set; } = null!;

    [StringLength(100)]
    public string Field6 { get; set; } = null!;

    [StringLength(100)]
    public string Field7 { get; set; } = null!;

    [StringLength(100)]
    public string Field8 { get; set; } = null!;

    [StringLength(100)]
    public string Field9 { get; set; } = null!;

    [StringLength(100)]
    public string? Field10 { get; set; }

    public bool OtherCheck1 { get; set; }

    public bool OtherCheck2 { get; set; }

    public bool OtherCheck3 { get; set; }

    public bool OtherCheck4 { get; set; }

    public bool OtherCheck5 { get; set; }

    [StringLength(100)]
    public string Auto1 { get; set; } = null!;

    [StringLength(100)]
    public string Auto2 { get; set; } = null!;

    [StringLength(100)]
    public string Auto3 { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    public bool CalculateTaxOnKitDetail { get; set; }

    public bool CalculateShipOnKitDetail { get; set; }

    public int? ItemStatus { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EntryDate { get; set; }

    public bool? AvailableInAllWarehouses { get; set; }

    public bool? TaxedInAllCountryRegions { get; set; }

    public bool? IsSubscriptionUpdate { get; set; }

    public bool? IsPointIncrement { get; set; }
}
