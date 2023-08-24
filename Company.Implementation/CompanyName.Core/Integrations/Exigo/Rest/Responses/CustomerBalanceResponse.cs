// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CustomerBalanceResponse
{
    public string CurrencyCode { get; init; }
    public string CurrencyDescription { get; init; }
    public Decimal Balance { get; init; }

    public CustomerBalanceResponse() : base()
    {
        CurrencyCode = String.Empty;
        CurrencyDescription = String.Empty;
    }
}
