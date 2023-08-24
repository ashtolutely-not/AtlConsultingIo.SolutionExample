// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record DeleteCalendarItemRequest : ApiRequest, ITransactionMember
{
    public int UserID { get; init; }
    public int CalendarID { get; init; }
    public int CalendarItemID { get; init; }

    public DeleteCalendarItemRequest() : base()
    {
    }
}
