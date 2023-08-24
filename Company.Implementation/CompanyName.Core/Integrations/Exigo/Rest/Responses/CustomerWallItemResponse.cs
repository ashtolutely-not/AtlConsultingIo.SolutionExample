// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CustomerWallItemResponse
{
    public int CustomerID { get; init; }
    public int WallItemID { get; init; }
    public string Text { get; init; }
    public DateTime EntryDate { get; init; }
    public string Field1 { get; init; }
    public string Field2 { get; init; }
    public string Field3 { get; init; }
    public string CustomerKey { get; init; }

    public CustomerWallItemResponse() : base()
    {
        Text = String.Empty;
        Field1 = String.Empty;
        Field2 = String.Empty;
        Field3 = String.Empty;
        CustomerKey = String.Empty;
    }
}
