namespace CompanyName.Core.Entities;

public interface IDateTimeValue
{
	DateTime Value { get; set; }

    public static T Create<T>( DateTime input ) where T : struct, IDateTimeValue
    {
        var result = new T();
        result.Value = input;
        return result;
    }
}
