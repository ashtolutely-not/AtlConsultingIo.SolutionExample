// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CreateCustomerFileRequest : ApiRequest
{
    public int CustomerID { get; init; }
    public string FileName { get; init; }
    public byte[] FileData { get; init; }
    public bool OverwriteExistingFile { get; init; }
    public string CustomerKey { get; init; }
    public string FolderName { get; init; }
    public int? ParentFolderID { get; init; }

    public CreateCustomerFileRequest() : base()
    {
        FileName = String.Empty;
        FileData = new byte[0];
        CustomerKey = String.Empty;
        FolderName = String.Empty;
    }
}
