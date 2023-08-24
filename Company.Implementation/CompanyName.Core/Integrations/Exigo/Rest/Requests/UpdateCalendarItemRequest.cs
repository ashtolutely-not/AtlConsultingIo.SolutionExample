// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record UpdateCalendarItemRequest : ApiRequest, ITransactionMember
{
    public int UserID { get; init; }
    public int CalendarID { get; init; }
    public int CalendarItemID { get; init; }
    public CalendarItemType CalendarItemType { get; init; }
    public CalendarItemStatusType? CalendarItemStatusType { get; init; }
    public CalendarItemPriorityType? CalendarItemPriorityType { get; init; }
    public string Subject { get; init; }
    public string Location { get; init; }
    public string Notes { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public int TimeZone { get; init; }
    public string Address1 { get; init; }
    public string Address2 { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string Country { get; init; }
    public string PostalCode { get; init; }
    public string ContactInfo { get; init; }
    public string ContactPhone { get; init; }
    public ContactPhoneType ContactPhoneType { get; init; }
    public string ContactEmail { get; init; }
    public string EventHost { get; init; }
    public string SpecialGuests { get; init; }
    public string EventFlyer { get; init; }
    public string EventCostInfo { get; init; }
    public string EventConferenceCallOrWebinar { get; init; }
    public string EventRegistrationInfo { get; init; }
    public string EventTags { get; init; }
    public bool IsShared { get; init; }

    public UpdateCalendarItemRequest() : base()
    {
        Subject = String.Empty;
        Location = String.Empty;
        Notes = String.Empty;
        Address1 = String.Empty;
        Address2 = String.Empty;
        City = String.Empty;
        State = String.Empty;
        Country = String.Empty;
        PostalCode = String.Empty;
        ContactInfo = String.Empty;
        ContactPhone = String.Empty;
        ContactEmail = String.Empty;
        EventHost = String.Empty;
        SpecialGuests = String.Empty;
        EventFlyer = String.Empty;
        EventCostInfo = String.Empty;
        EventConferenceCallOrWebinar = String.Empty;
        EventRegistrationInfo = String.Empty;
        EventTags = String.Empty;
    }
}
