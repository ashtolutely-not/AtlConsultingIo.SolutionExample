using CompanyName.Core.Entities;

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
