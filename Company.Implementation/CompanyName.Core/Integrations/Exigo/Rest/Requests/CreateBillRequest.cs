// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CreateBillRequest : ApiRequest
{
    public int CustomerID { get; init; }
    public string CurrencyCode { get; init; }
    public bool IsOtherIncome { get; init; }
    public DateTime DueDate { get; init; }
    public Decimal Amount { get; init; }
    public string Reference { get; init; }
    public string Notes { get; init; }
    public int? BillStatusTypeID { get; init; }
    public int? PayableTypeIDOverride { get; init; }
    public string CustomerKey { get; init; }
    public int? TaxablePeriodTy { get; init; }
    public int? TaxablePeriodID { get; init; }

    public CreateBillRequest() : base()
    {
        CurrencyCode = String.Empty;
        Reference = String.Empty;
        Notes = String.Empty;
        CustomerKey = String.Empty;
    }
}
