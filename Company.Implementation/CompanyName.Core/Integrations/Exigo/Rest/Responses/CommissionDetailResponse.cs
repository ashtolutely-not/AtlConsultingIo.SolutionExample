// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CommissionDetailResponse
{
    public int FromCustomerID { get; init; }
    public string FromCustomerName { get; init; }
    public int OrderID { get; init; }
    public int Level { get; init; }
    public int PaidLevel { get; init; }
    public Decimal SourceAmount { get; init; }
    public Decimal Percentage { get; init; }
    public Decimal CommissionAmount { get; init; }
    public string FromCustomerKey { get; init; }
    public string OrderKey { get; init; }

    public CommissionDetailResponse() : base()
    {
        FromCustomerName = String.Empty;
        FromCustomerKey = String.Empty;
        OrderKey = String.Empty;
    }
}
