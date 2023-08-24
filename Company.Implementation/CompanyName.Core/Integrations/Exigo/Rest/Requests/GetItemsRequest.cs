// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetItemsRequest : ApiRequest
{
    public string CurrencyCode { get; init; }
    public int PriceType { get; init; }
    public int WarehouseID { get; init; }
    public string[] ItemCodes { get; init; }
    public int? WebID { get; init; }
    public int? WebCategoryID { get; init; }
    public bool ReturnLongDetail { get; init; }
    public bool? RestrictToWarehouse { get; init; }
    public int? LanguageID { get; init; }
    public bool? ExcludeHideFromSearch { get; init; }

    public GetItemsRequest() : base()
    {
        CurrencyCode = String.Empty;
        ItemCodes = new string[0];
    }
}
