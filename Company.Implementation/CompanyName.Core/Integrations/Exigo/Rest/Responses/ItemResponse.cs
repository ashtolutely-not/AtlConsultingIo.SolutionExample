// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.
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

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record ItemResponse
{
    public string ItemCode { get; init; }
    public string Description { get; init; }
    public Decimal Price { get; init; }
    public Decimal Weight { get; init; }
    public Decimal CommissionableVolume { get; init; }
    public Decimal BusinessVolume { get; init; }
    public Decimal Other1Price { get; init; }
    public Decimal Other2Price { get; init; }
    public Decimal Other3Price { get; init; }
    public Decimal Other4Price { get; init; }
    public Decimal Other5Price { get; init; }
    public Decimal Other6Price { get; init; }
    public Decimal Other7Price { get; init; }
    public Decimal Other8Price { get; init; }
    public Decimal Other9Price { get; init; }
    public Decimal Other10Price { get; init; }
    public string Category { get; init; }
    public int CategoryID { get; init; }
    public string TinyPicture { get; init; }
    public string SmallPicture { get; init; }
    public string LargePicture { get; init; }
    public string ShortDetail { get; init; }
    public string ShortDetail2 { get; init; }
    public string ShortDetail3 { get; init; }
    public string ShortDetail4 { get; init; }
    public string LongDetail { get; init; }
    public string LongDetail2 { get; init; }
    public string LongDetail3 { get; init; }
    public string LongDetail4 { get; init; }
    public InventoryStatusType InventoryStatus { get; init; }
    public int StockLevel { get; init; }
    public int AvailableStockLevel { get; init; }
    public int MaxAllowedOnOrder { get; init; }
    public string Field1 { get; init; }
    public string Field2 { get; init; }
    public string Field3 { get; init; }
    public string Field4 { get; init; }
    public string Field5 { get; init; }
    public string Field6 { get; init; }
    public string Field7 { get; init; }
    public string Field8 { get; init; }
    public string Field9 { get; init; }
    public string Field10 { get; init; }
    public bool OtherCheck1 { get; init; }
    public bool OtherCheck2 { get; init; }
    public bool OtherCheck3 { get; init; }
    public bool OtherCheck4 { get; init; }
    public bool OtherCheck5 { get; init; }
    public bool IsVirtual { get; init; }
    public bool AllowOnAutoOrder { get; init; }
    public bool IsGroupMaster { get; init; }
    public string GroupDescription { get; init; }
    public string GroupMembersDescription { get; init; }
    public ItemMemberResponse[] GroupMembers { get; init; }
    public bool IsDynamicKitMaster { get; init; }
    public bool HideFromSearch { get; init; }
    public KitMemberResponse[] KitMembers { get; init; }
    public Decimal TaxablePrice { get; init; }
    public Decimal ShippingPrice { get; init; }

    public ItemResponse() : base()
    {
        ItemCode = String.Empty;
        Description = String.Empty;
        Category = String.Empty;
        TinyPicture = String.Empty;
        SmallPicture = String.Empty;
        LargePicture = String.Empty;
        ShortDetail = String.Empty;
        ShortDetail2 = String.Empty;
        ShortDetail3 = String.Empty;
        ShortDetail4 = String.Empty;
        LongDetail = String.Empty;
        LongDetail2 = String.Empty;
        LongDetail3 = String.Empty;
        LongDetail4 = String.Empty;
        Field1 = String.Empty;
        Field2 = String.Empty;
        Field3 = String.Empty;
        Field4 = String.Empty;
        Field5 = String.Empty;
        Field6 = String.Empty;
        Field7 = String.Empty;
        Field8 = String.Empty;
        Field9 = String.Empty;
        Field10 = String.Empty;
        GroupDescription = String.Empty;
        GroupMembersDescription = String.Empty;
        GroupMembers = new ItemMemberResponse[0];
        KitMembers = new KitMemberResponse[0];
    }
}
