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

namespace CompanyName.Core.Entities.User;

public record AccountResult 
{
    public CustomerID AccountId { get; init; }
    public string FirstName { get; init; } 
    public string MiddleName { get; init; }
    public string LastName { get; init; } 
    public string Company { get; init; }
    public IncomeTaxID? TaxId { get; init; }
    public string Email { get; init; }
    public string Phone { get; init; }
    public string Phone2 { get; init; }
    public string MobilePhone { get; init; }
    public string Username { get; init; }

    public DateOnly BirthDate { get; init; }
    public string Gender { get; init; }

    public Address MainAddress { get; init; }
    public Address MailAddress { get; init; }
    public Address OtherAddress { get; init; }

    //We might want to move this to a separate object to separate the user data from the data required by the Exigo Platform (ExigoProfile for example)
    public ExigoTypeID LanguageId { get; init; }
    public ExigoTypeID CustomerTypeId { get; init; }
    public ExigoTypeID WarehouseId { get; init; }
    public ExigoTypeID EnrollerId { get; init; }
    public ExigoTypeID RankId { get; init; }
    public ExigoTypeID AccountStatusId { get; init; }

    //Note these are what the EmailContact | Phone Contact lists on the UserEntity should handle
    //Legal regulations requires that we capture this on each phone number/email not at the account level
    public bool IsEmailOptedIn { get; init; }
    public bool IsSmsOptedIn { get; init; }

    public DateTime CreatedDate { get; init; }
    public DateTime? EnrollmentDate { get; init; }
    public UserAvatarUrl AvatarUrl { get; init; }      
    
    public EnrollerAccount? Enroller { get; init; }
    public AccountResult()
    {
        FirstName = MiddleName = LastName = Company = String.Empty;
        Email = Phone = Phone2 = MobilePhone = String.Empty;
        Username = Gender = String.Empty;
    }

    public bool HasEnroller => EnrollerId > 0;
    public static readonly AccountResult Default = new();
    public bool IsDefault => Equals( Default );

}
