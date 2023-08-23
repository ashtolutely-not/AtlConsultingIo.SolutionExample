
using OneOf;
namespace AtlConsultingIo.IntegrationOperations;
public struct StringOrInteger
{
    public OneOf.OneOf<string , int> Value { get; }

    public StringOrInteger( int? value )
    {
        Value = value ?? 0;
    }
    public StringOrInteger( string? value )
        => Value = value.EmptyIfNull();

    public bool IsEmpty => Value.Match(
            _str => string.IsNullOrWhiteSpace( _str ),
            _int => _int == 0
        );


    public static explicit operator string( StringOrInteger _ )
        => _.Value.Match( 
                _str => _str ,
                _int => _int.ToString()
                );

    public static explicit operator int( StringOrInteger _ )
        => _.Value.Match(
                _str => -1,
                _int => _int
            );
}


