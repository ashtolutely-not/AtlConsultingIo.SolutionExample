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

public struct AutoOrderID : IIntegerValue, IEquatable<int>, IEquatable<ExigoEntityID>, IEquatable<int?>
{
    public int Value { get; set; }
    public bool IsDefault => Equals( Default );

    public AutoOrderID( int value ) 
        => Value = value <= 0 ? Default : value;

    public AutoOrderID( ExigoEntityID input )
        => Value = input <= 0 ? Default : input;
    
    public static readonly AutoOrderID Default = new();

    #region Operators

    public static implicit operator int( AutoOrderID _ ) => _.Value;
    public static explicit operator string( AutoOrderID _ ) => _.Value.ToString();
    public static explicit operator ExigoEntityID( AutoOrderID _ ) => new( _ );

    #endregion

    #region Equality

    public bool Equals( int other )
        => Value.Equals( other );

    public bool Equals( ExigoEntityID other )
        => Value.Equals( (int)other );
	public bool Equals( int? other ) 
        => Value.Equals( other.GetValueOrDefault() );

	#endregion

}
