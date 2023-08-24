// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetOrderInvoiceResponse : ApiResponse
{
    public byte[] InvoiceData { get; init; }

    public GetOrderInvoiceResponse( ) : base ( ) => InvoiceData = new byte[ 0 ];
}
