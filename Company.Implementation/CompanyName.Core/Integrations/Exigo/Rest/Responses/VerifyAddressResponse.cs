// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record VerifyAddressResponse : ApiResponse
{
    public string Address { get; init; }
    public string City { get; init; }
    public string County { get; init; }
    public string State { get; init; }
    public string Zip { get; init; }
    public string Country { get; init; }

    public VerifyAddressResponse() : base()
    {
        Address = String.Empty;
        City = String.Empty;
        County = String.Empty;
        State = String.Empty;
        Zip = String.Empty;
        Country = String.Empty;
    }
}
