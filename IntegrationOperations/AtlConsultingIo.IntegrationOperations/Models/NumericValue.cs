
using OneOf;

namespace AtlConsultingIo.IntegrationOperations;

public readonly record struct NumericValue
{
    public OneOf<int,decimal,double> Value { get; }

    public NumericValue( int? value )
    {
        Value = value ?? 0;
    }

    public NumericValue( decimal? value )
        => Value = value ?? 0;

    public NumericValue( double? value )
        => Value = value ?? 0;

    public override string ToString()
    {
        return Value.Match(
                    _int => _int.ToString(),
                    _dec => _dec.ToString(),
                    _dbl => _dbl.ToString()
                );
    }
}
