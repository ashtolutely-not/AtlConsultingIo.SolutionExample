// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record DepartmentInfo
{
    public string Description { get; init; }
    public int DepartmentType { get; init; }

    public DepartmentInfo( ) : base ( ) => Description = String.Empty;
}
