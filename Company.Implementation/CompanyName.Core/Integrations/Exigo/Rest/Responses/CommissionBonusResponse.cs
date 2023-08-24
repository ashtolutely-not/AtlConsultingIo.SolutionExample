// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CommissionBonusResponse
{
    public string Description { get; init; }
    public Decimal Amount { get; init; }
    public int BonusID { get; init; }

    public CommissionBonusResponse( ) : base ( ) => Description = String.Empty;
}
