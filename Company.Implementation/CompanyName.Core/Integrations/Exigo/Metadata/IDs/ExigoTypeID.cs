using CompanyName.Core.Entities;
namespace CompanyName.Core.Integrations.Exigo;

public struct ExigoTypeID : IEquatable<int>, IEquatable<int?>, IIntegerValue
{
    public int Value { get; set; }
    public bool IsDefault => Equals( Default );

    public ExigoTypeID( int input ) => Value = input >= 0 ? input : 0;

    public static readonly ExigoTypeID Default = new();
    public static implicit operator int( ExigoTypeID _ )
        => _.Value;

    public bool Equals( int other ) => Value == other;
    public bool Equals( int? other )
    => Value == other.GetValueOrDefault();

}

