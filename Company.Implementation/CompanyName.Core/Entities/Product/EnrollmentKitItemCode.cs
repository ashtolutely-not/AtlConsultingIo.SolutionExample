namespace CompanyName.Core.Entities.Product;

public record EnrollmentKitItemCode : IItemCode
{
    public string Value { get; init; }

    public EnrollmentKitItemCode( )
    {
        Value = String.Empty;
    }

    public EnrollmentKitItemCode( string value )
    {
        Value = value;
    }
}
