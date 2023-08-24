// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record SetItemPointAccountRequest : ApiRequest, ITransactionMember
{
    public string ItemCode { get; init; }
    public int? ItemID { get; init; }
    public PointAccount[] PointAccounts { get; init; }

    public SetItemPointAccountRequest() : base()
    {
        ItemCode = String.Empty;
        PointAccounts = new PointAccount[0];
    }
}
