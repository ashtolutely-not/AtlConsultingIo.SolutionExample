// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record MergeCustomerRequest : ApiRequest
{
    public int ToCustomerID { get; init; }
    public int FromCustomerID { get; init; }
    public string ToCustomerKey { get; init; }
    public string FromCustomerKey { get; init; }

    public MergeCustomerRequest() : base()
    {
        ToCustomerKey = String.Empty;
        FromCustomerKey = String.Empty;
    }
}
