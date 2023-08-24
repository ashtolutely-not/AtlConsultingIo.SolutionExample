// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record OrderTotalByCurrency
{
    public string CurrencyCode { get; init; }
    public Decimal Amount { get; init; }
    public int Count { get; init; }

    public OrderTotalByCurrency( ) : base ( ) => CurrencyCode = String.Empty;
}
