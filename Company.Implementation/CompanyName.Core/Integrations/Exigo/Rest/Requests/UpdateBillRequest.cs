// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record UpdateBillRequest
{
    public int? VendorBillID { get; init; }
    public int CustomerID { get; init; }
    public string CustomerKey { get; init; }
    public int? WarehouseID { get; init; }
    public string CurrencyCode { get; init; }
    public DateTime? DatePaymentDue { get; init; }
    public string Reference { get; init; }
    public DateTime? DateReceived { get; init; }
    public Decimal? Amount { get; init; }
    public bool? IsOtherIncome { get; init; }
    public string Notes { get; init; }
    public int? StatusType { get; init; }
    public int? PayableType { get; init; }
    public int? TaxablePeriodTy { get; init; }
    public int? TaxablePeriodID { get; init; }

    public UpdateBillRequest() : base()
    {
        CustomerKey = String.Empty;
        CurrencyCode = String.Empty;
        Reference = String.Empty;
        Notes = String.Empty;
    }
}
