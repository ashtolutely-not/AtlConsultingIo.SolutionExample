// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetCustomerFoldersResponse : ApiResponse
{
    public int FolderCount { get; init; }
    public int ParentFolderID { get; init; }
    public string ParentFolderName { get; init; }
    public CustomerFoldersResponse[] CustomerFolderList { get; init; }

    public GetCustomerFoldersResponse() : base()
    {
        ParentFolderName = String.Empty;
        CustomerFolderList = new CustomerFoldersResponse[0];
    }
}
