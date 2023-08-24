using CompanyName.Core.Entities;
namespace CompanyName.Core.Integrations.Exigo;

public struct CustomerID : IIntegerValue, IEquatable<int>, IEquatable<ExigoEntityID>, IEquatable<int?>
{
	public int Value { get; set; }
	public bool IsDefault => Value.Equals( 0 );

	public CustomerID( int value ) 
        => Value = value <= 0 ? Default : value;
    
    public static readonly CustomerID Default = new();

    
    #region Operators

    public static implicit operator int( CustomerID _ ) => _.Value;
    public static explicit operator string( CustomerID _ ) => _.Value.ToString();
    public static explicit operator ExigoEntityID( CustomerID _ ) => new( _ );

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
