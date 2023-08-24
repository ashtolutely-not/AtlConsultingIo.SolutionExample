// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record IsUniLevelChildValidateRequest : ValidateRequest
{
    public int ParentID { get; init; }
    public string ParentKey { get; init; }
    public int ChildID { get; init; }
    public string ChildKey { get; init; }

    public IsUniLevelChildValidateRequest() : base()
    {
        ParentKey = String.Empty;
        ChildKey = String.Empty;
    }
}
