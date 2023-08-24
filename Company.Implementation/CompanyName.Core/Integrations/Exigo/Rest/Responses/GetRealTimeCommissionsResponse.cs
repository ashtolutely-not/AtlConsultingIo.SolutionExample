// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetRealTimeCommissionsResponse : ApiResponse
{
    public CommissionResponse[] Commissions { get; init; }

    public GetRealTimeCommissionsResponse( ) : base ( ) => Commissions = new CommissionResponse[ 0 ];
}
