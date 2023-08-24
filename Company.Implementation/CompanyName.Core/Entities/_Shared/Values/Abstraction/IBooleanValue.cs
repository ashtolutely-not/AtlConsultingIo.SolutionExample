namespace CompanyName.Core.Entities;
public interface IBooleanValue
{
	bool Value { get;  set;}

    public static T Create<T>( bool value ) where T : struct, IBooleanValue
    {
        var result = new T();
        result.Value = value;
        return result;
    }
}
