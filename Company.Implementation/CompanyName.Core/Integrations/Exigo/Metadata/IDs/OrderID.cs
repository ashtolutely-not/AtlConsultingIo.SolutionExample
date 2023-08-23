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

public struct OrderID : IIntegerValue, IEquatable<ExigoEntityID>, IEquatable<int>, IEquatable<int?>
{
    public int Value { get; set; }
    public bool IsDefault => Value.Equals(0);
    public OrderID( int value ) 
        => Value = value <= 0 ? 0 : value;
    public OrderID( int? input )
        => Value = input.HasValue && input.Value >= 0 ? input.Value : 0;

    public static readonly OrderID Default = new();

    #region Operators

    public static implicit operator int( OrderID _ ) => _.Value;
    public static explicit operator string( OrderID _ ) => _.Value.ToString();
    public static explicit operator ExigoEntityID( OrderID _ ) => new( _.Value );

    #endregion

    #region Equality
    public bool Equals( int other )
        => Value.Equals( other );

    public bool Equals( ExigoEntityID other )
        => Value.Equals( other.Value );
	public bool Equals( int? other )
	=> Value.Equals( other.GetValueOrDefault() );
	#endregion
}
