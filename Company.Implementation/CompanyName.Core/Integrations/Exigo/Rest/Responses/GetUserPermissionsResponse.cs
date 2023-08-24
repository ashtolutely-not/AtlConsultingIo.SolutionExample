// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetUserPermissionsResponse : ApiResponse
{
    public int[] RestrictToCustomerTypes { get; init; }
    public int[] RestrictToCustomerStatuses { get; init; }
    public int[] RestrictToWarehouses { get; init; }
    public string[] RestrictToCountries { get; init; }
    public string[] RestrictToCurrencies { get; init; }
    public bool ViewDeletedCustomers { get; init; }
    public bool AllowRemoteCheckPrint { get; init; }
    public bool AllowOverrideItemPrice { get; init; }
    public bool AllowStatementPrint { get; init; }
    public int DefaultWarehouseID { get; init; }
    public int LanguageID { get; init; }
    public string CultureCode { get; init; }

    public GetUserPermissionsResponse() : base()
    {
        RestrictToCustomerTypes = new int[0];
        RestrictToCustomerStatuses = new int[0];
        RestrictToWarehouses = new int[0];
        RestrictToCountries = new string[0];
        RestrictToCurrencies = new string[0];
        CultureCode = String.Empty;
    }
}
