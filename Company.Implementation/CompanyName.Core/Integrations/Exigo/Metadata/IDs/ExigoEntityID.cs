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
namespace CompanyName.Core.Integrations.Exigo;

public struct ExigoEntityID : IIntegerValue, IEquatable<ExigoEntityID>,IEquatable<int>,IEquatable<int?>
{
    public int Value { get; set; }
    public bool IsDefault => Equals ( Default );

    public ExigoEntityID( int input ) => Value = input >= 0 ? input : 0;

    public static readonly ExigoEntityID Default = new();
    public static implicit operator int( ExigoEntityID _ )
        => _.Value;

    public bool Equals( int other ) => Value == other;
    public bool Equals( int? other )
    => Value == other.GetValueOrDefault ( );
    public bool Equals( ExigoEntityID other ) => other.Value.Equals( Value );
}
