// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CustomerFoldersResponse
{
    public int FolderID { get; init; }
    public string FolderName { get; init; }
    public int SubFoldersCount { get; init; }
    public int SubFilesCount { get; init; }

    public CustomerFoldersResponse( ) : base ( ) => FolderName = String.Empty;
}
