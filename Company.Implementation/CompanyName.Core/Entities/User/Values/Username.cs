namespace CompanyName.Core.Entities.User;
[DapperHandler]
[NewtonsoftConverter]
public  struct Username : IStringValue, IEquatable<string?>    
{
    public string Value { get; set; }
    public bool IsNullOrDefault => string.IsNullOrWhiteSpace(Value);
    public Username( string? input )
        => Value = input ?? String.Empty;

    public static implicit operator string( Username _ ) => _.Value;
    public static readonly Username Default = new( );

    public bool Equals( string? other ) => !string.IsNullOrWhiteSpace ( other ) && Value.Equals ( other , StringComparison.OrdinalIgnoreCase );
}
