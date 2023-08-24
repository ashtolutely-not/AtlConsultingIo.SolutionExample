// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record AppendCustomerNotesRequest : ApiRequest, ITransactionMember
{
    public string Notes { get; init; }
    public int CustomerID { get; init; }
    public string CustomerKey { get; init; }

    public AppendCustomerNotesRequest() : base()
    {
        Notes = String.Empty;
        CustomerKey = String.Empty;
    }
}
