namespace CompanyName.Core.Entities;


public struct EmailAddress : IStringValue, IEquatable<string?>
{
    public bool IsNullOrDefault => string.IsNullOrEmpty(Value);
    public string Value { get; set; }

    public EmailAddress( string address ) => Value = address;
    public static EmailAddress Create( string?  value )
        => new EmailAddress( value ?? String.Empty );

    public static implicit operator string(EmailAddress _) => _.Value;
    public static readonly EmailAddress Default = new();

    public bool Equals( string? other )
        => !string.IsNullOrWhiteSpace( other ) && Value.Equals( other , StringComparison.OrdinalIgnoreCase );
}
