namespace CompanyName.Operations;

public class AccountValidationOptions
{
    public bool IsEmailValidOnSendGridError { get; set; } = true;
    public bool IsEmailValidOnDatabaseError { get; set; }
    public bool IsTaxIdValidOnDatabaseError { get; set; }
    public bool IsPhoneNumberValidOnDatabaseError { get; set; }
    public bool IsUsernameValidOnDatabaseError { get; set; }

    public string SendGridResultsTable { get; set; } = String.Empty;
    public int? SendGridResultCacheExpirationInMinutes { get; set; }
    public int? SendGridResultCacheExpirationInSeconds{ get; set; }
}
