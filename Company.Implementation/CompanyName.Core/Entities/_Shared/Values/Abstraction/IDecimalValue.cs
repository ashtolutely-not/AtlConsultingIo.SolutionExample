namespace CompanyName.Core.Entities;

public interface IDecimalValue
{
	decimal Value { get; set; }
	bool IsDefault { get; }

    public static T Create<T>( decimal input ) where T : struct, IDecimalValue
    {
        var result = new T();
        result.Value = input;
        return result;
    }
}
