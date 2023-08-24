namespace CompanyName.Core.Entities;

public readonly record struct TransactionKey
{
    public string Value { get; }
    public bool IsNullOrDefault => string.IsNullOrWhiteSpace( Value );

    public TransactionKey( string input ) => Value = input;

    public static readonly TransactionKey Default;

    public static implicit operator string( TransactionKey _ ) => _.Value;

}
