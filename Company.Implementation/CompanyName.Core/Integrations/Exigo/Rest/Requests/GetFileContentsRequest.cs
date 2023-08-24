// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetFileContentsRequest : ApiRequest
{
    public string FileName { get; init; }
    public int? FileID { get; init; }
    public int? ParentFolderID { get; init; }
    public int CustomerID { get; init; }
    public string CustomerKey { get; init; }

    public GetFileContentsRequest() : base()
    {
        FileName = String.Empty;
        CustomerKey = String.Empty;
    }
}
