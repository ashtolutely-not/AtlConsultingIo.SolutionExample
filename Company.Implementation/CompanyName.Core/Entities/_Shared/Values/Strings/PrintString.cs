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

public struct PrintString : IStringValue, IEquatable<string?>
{
    public string Value { get; set; }
    public bool IsNullOrDefault => string.IsNullOrWhiteSpace( Value );

    private PrintString( string value ) => Value = value;
    public PrintString Create( string?  value ) => string.IsNullOrWhiteSpace ( value ) ? new PrintString() : new PrintString( value );

    public override string ToString( ) => Value;

    public bool Equals( string? other ) => !string.IsNullOrWhiteSpace ( other ) && Value.Equals ( other , StringComparison.OrdinalIgnoreCase );

    public static implicit operator string( PrintString _ ) => _.Value;

    public static readonly PrintString Null = new("NULL");
	public static readonly PrintString Default = new();
}
