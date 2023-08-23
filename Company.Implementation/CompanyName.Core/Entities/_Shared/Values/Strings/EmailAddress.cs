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
namespace CompanyName.Core.Entities;


public struct EmailAddress : IStringValue, IEquatable<string?>
{
    public bool IsNullOrDefault => string.IsNullOrEmpty(Value);
    public string Value { get; set; }

    public EmailAddress( string address ) => Value = address;
    public static EmailAddress Create( string?  value )
        => new EmailAddress( value ?? String.Empty );

    public static implicit operator string(EmailAddress _) => _.Value;
    public static readonly EmailAddress Default = new();

    public bool Equals( string? other )
        => !string.IsNullOrWhiteSpace( other ) && Value.Equals( other , StringComparison.OrdinalIgnoreCase );
}
