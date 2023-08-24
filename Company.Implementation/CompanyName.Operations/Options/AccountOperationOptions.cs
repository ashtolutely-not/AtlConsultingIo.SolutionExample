namespace CompanyName.Operations;

public class AccountOperationOptions
{
    public AccountValidationOptions ValidationResultOptions { get; set; } = new();
    public EnrollerSearchOptions EnrollerSearchOptions { get; set; } = new();
}
