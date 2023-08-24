// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record ShipMethodResponse
{
    public int ShipMethodID { get; init; }
    public string Description { get; init; }
    public Decimal ShippingAmount { get; init; }

    public ShipMethodResponse( ) : base ( ) => Description = String.Empty;
}
