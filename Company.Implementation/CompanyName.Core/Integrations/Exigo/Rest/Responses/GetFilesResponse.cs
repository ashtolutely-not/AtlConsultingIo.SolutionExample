// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetFilesResponse : ApiResponse
{
    public int FileCount { get; init; }
    public int ParentFolderID { get; init; }
    public string ParentFolderName { get; init; }
    public CustomerFilesResponse[] CustomerFileList { get; init; }

    public GetFilesResponse() : base()
    {
        ParentFolderName = String.Empty;
        CustomerFileList = new CustomerFilesResponse[0];
    }
}
