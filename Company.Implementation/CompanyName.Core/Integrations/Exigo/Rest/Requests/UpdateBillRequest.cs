// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.
using CompanyName.Core;
using CompanyName.Core.Entities;
using CompanyName.Core.Entities.Events;
using CompanyName.Core.Entities.Messaging;
using CompanyName.Core.Entities.Order;
using CompanyName.Core.Entities.Product;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;
using CompanyName.Core.Integrations.Exigo.Sql;
using CompanyName.Core.Integrations.KountApi;
using CompanyName.Core.Integrations.SendGridApi;

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
