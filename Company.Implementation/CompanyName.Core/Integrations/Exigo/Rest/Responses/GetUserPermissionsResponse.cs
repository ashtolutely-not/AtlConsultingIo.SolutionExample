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
