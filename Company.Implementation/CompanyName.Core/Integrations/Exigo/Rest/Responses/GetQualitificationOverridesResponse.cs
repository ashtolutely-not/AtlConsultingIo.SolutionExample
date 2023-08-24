// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetQualitificationOverridesResponse : ApiResponse
{
    public GetQualificationOverrideResponse[] QualificationOverrides { get; init; }

    public GetQualitificationOverridesResponse( ) : base ( ) => QualificationOverrides = new GetQualificationOverrideResponse[ 0 ];
}
