namespace CompanyName.Core.Entities.Product;

public record CbdItemCode : IItemCode
{
    public string Value { get ; init; } 

    public CbdItemCode( )
    {
        Value = String.Empty;
    }

    public CbdItemCode( string value )
    {
        Value = value;
    }
}
