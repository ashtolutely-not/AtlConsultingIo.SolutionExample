namespace CompanyName.Core.Entities.User;

public record EnrollerAccount : AccountResult
{
    public UserSite Site { get; init; } = UserSite.Default;

}
