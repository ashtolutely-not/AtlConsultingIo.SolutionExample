// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record ApiWhitelistResponse
{
    public int IpRangeID { get; init; }
    public string Description { get; init; }
    public string MinIP { get; init; }
    public string MaxIP { get; init; }

    public ApiWhitelistResponse() : base()
    {
        Description = String.Empty;
        MinIP = String.Empty;
        MaxIP = String.Empty;
    }
}
