// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record SetItemKitMembersRequest : ApiRequest, ITransactionMember
{
    public string ParentItemCode { get; init; }
    public KitMember[] ItemKitMembers { get; init; }

    public SetItemKitMembersRequest() : base()
    {
        ParentItemCode = String.Empty;
        ItemKitMembers = new KitMember[0];
    }
}
