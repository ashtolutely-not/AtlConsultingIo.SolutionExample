// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record DebitBankAccountOnFileRequest : BaseDebitBankAccountRequest, ITransactionMember
{
    public int OrderID { get; init; }
    public Decimal? MaxAmount { get; init; }
    public string OrderKey { get; init; }

    public DebitBankAccountOnFileRequest( ) : base ( ) => OrderKey = String.Empty;
}
