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
namespace CompanyName.Core.Integrations.SendGridApi;

public struct SGEnabled 
{
    [JsonProperty( "enable" )] 
    public bool Value { get; init; }
    public SGEnabled( bool value ) => Value = value;
    public bool IsTrue => Equals( True );
    public bool IsFalse => Equals( False );

    public static readonly SGEnabled True = new( true );
    public static readonly SGEnabled False = new( false );

    public static implicit operator SGEnabled( bool value ) => new( value );
    public static explicit operator bool( SGEnabled value ) => value.Value;
}
