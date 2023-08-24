// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CommissionResponse
{
    public int CustomerID { get; init; }
    public int PeriodType { get; init; }
    public int PeriodID { get; init; }
    public string PeriodDescription { get; init; }
    public string CurrencyCode { get; init; }
    public Decimal CommissionTotal { get; init; }
    public CommissionBonusResponse[] Bonuses { get; init; }
    public string CustomerKey { get; init; }

    public CommissionResponse() : base()
    {
        PeriodDescription = String.Empty;
        CurrencyCode = String.Empty;
        Bonuses = new CommissionBonusResponse[0];
        CustomerKey = String.Empty;
    }
}
