// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetShipMethodsRequest : ApiRequest
{
    public int WarehouseID { get; init; }
    public string CurrencyCode { get; init; }
    public Decimal OrderSubTotal { get; init; }
    public Decimal OrderWieght { get; init; }

    public GetShipMethodsRequest( ) : base ( ) => CurrencyCode = String.Empty;
}
