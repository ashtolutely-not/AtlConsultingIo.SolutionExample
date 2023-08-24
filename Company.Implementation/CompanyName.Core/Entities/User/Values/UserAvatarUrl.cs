using CompanyName.Core.Integrations.Exigo;
namespace CompanyName.Core.Entities.User;

[DapperHandler]
[NewtonsoftConverter]
public struct UserAvatarUrl : IStringValue, IEquatable<string?>
{
    public string Value { get; set; }
    public bool IsNullOrDefault => string.IsNullOrWhiteSpace(Value);
    internal UserAvatarUrl( string input )
        => Value = input;
    public UserAvatarUrl( CustomerID customerId )
        => Value = string.Format( "/content/customer/{0}/avatar" , customerId.Value );

    public bool Equals( string? other )
        => !string.IsNullOrWhiteSpace( other ) && Value.Equals( other , StringComparison.OrdinalIgnoreCase );

    public static readonly UserAvatarUrl Default = new();
    public static implicit operator string( UserAvatarUrl _ ) => _.Value;
}
