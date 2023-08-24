namespace CompanyName.Core.Entities.Order;
public  record SmartshipItem
{
    public string ItemCode { get; private init; }
    public int Quantity { get; private init; }
    internal SmartshipItem()
    {
        ItemCode = string.Empty;
        Quantity = 0;
    }
    public SmartshipItem( string itemCode, int quantity )
    {
        ItemCode = itemCode;
        Quantity = quantity;
    }
    public bool IsEmpty => Equals( Empty );
    public static readonly SmartshipItem Empty = new();

}
