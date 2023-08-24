// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetOrderInvoiceRequest : ApiRequest
{
    public int OrderID { get; init; }
    public string OrderKey { get; init; }
    public int ReportlayoutID { get; init; }
    public InvoiceRenderFormat Format { get; init; }

    public GetOrderInvoiceRequest( ) : base ( ) => OrderKey = String.Empty;
}
