using CompanyName.Core.Integrations.Exigo.Rest;



namespace CompanyName.Core.Entities.User;
public record AccountRegistration : CreateCustomerRequest
{
    public bool HasEmailOptIn { get => base.SubscribeToBroadcasts; init => base.SubscribeToBroadcasts = value; }
    public bool HasSmsOptIn { get; init; }    
    public DateTime? UpgradeDate { get => base.Date5; set => base.Date5 = value; }
}
