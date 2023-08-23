using CompanyName.Operations;
using CompanyName.Operations.Account;
using CompanyName.Operations.Checkout;
using CompanyName.Operations.Messaging;
using CompanyName.Operations.Order;
using CompanyName.Operations.Product;
using CompanyName.Core;
using CompanyName.Core.Entities;
using CompanyName.Core.Entities.Events;
using CompanyName.Core.Entities.Messaging;
using CompanyName.Core.Entities.Order;
using CompanyName.Core.Entities.Product;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;
using CompanyName.Core.Integrations.Exigo.Sql;
using CompanyName.Core.Integrations.KountApi;
using CompanyName.Core.Integrations.SendGridApi;
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
