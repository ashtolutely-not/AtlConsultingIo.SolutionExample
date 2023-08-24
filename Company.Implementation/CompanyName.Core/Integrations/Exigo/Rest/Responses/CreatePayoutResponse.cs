// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CreatePayoutResponse : ApiResponse
{
    public int PayoutID { get; init; }
    public Decimal TotalDollarAmount { get; init; }

    public CreatePayoutResponse() : base()
    {
    }
}
