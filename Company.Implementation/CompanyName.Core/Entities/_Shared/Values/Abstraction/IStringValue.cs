namespace CompanyName.Core.Entities;

public interface IStringValue
{
	string Value { get; set; }
	bool IsNullOrDefault { get; }

    public static T Create<T>( string value ) where T : struct, IStringValue
    {
        var result = new T();
        result.Value = value;
        return result;
    }
}
