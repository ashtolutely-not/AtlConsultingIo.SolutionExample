namespace CompanyName.Core.Entities;

public interface IIntegerValue
{
	int Value { get; set; }
	bool IsDefault { get; }

    public static T Create<T>( int value ) where T : struct, IIntegerValue
    {
        var result = new T();
        if( value > 0)
            result.Value = value;
        return result;
    }
}
