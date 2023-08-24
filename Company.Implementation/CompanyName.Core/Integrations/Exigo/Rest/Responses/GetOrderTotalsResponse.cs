// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetOrderTotalsResponse : ApiResponse
{
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public OrderTotalByCurrency[] AcceptedByCurrency { get; init; }

    public GetOrderTotalsResponse( ) : base ( ) => AcceptedByCurrency = new OrderTotalByCurrency[ 0 ];
}
