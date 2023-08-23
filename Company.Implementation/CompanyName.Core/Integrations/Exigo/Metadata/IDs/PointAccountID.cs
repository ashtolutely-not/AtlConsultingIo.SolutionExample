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

public struct PointAccountID :  IEquatable<int>, IEquatable<ExigoTypeID>, IEquatable<int?>, IIntegerValue
{
    public int Value { get; set; }  
    public bool IsDefault => Value.Equals(0);

    public PointAccountID( ) => Value = ExigoTypeID.Default;
    public PointAccountID( int value ) 
        => Value = value >= 0 ? new ExigoTypeID( value ) : ExigoTypeID.Default;

    public bool Equals( int other ) => Value.Equals( other );
    public bool Equals( ExigoTypeID other )  => Value.Equals( other.Value );
	public bool Equals( int? other ) => Value.Equals( other.GetValueOrDefault() );

    public static readonly PointAccountID Default = new();
    public static implicit operator int( PointAccountID _ ) => _.Value;
    public static explicit operator ExigoTypeID( PointAccountID _ ) => new( _.Value );

}
