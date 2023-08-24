namespace CompanyName.Core.Entities.User;
[DapperHandler]
[NewtonsoftConverter]
public struct WebAlias : IStringValue, IEquatable<string?>
{
    public string Value { get; set; }
    public bool IsNullOrDefault => string.IsNullOrWhiteSpace( Value );
    public WebAlias( string? input )
        => Value = !string.IsNullOrWhiteSpace(input) ? input : String.Empty;

    public static implicit operator string( WebAlias _ ) => _.Value;
    public static readonly WebAlias Default = new();

    public bool Equals( string? other ) => !string.IsNullOrWhiteSpace ( other ) && Value.Equals ( other , StringComparison.OrdinalIgnoreCase );
}
