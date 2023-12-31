namespace CompanyName.Core.Entities.Order;

public record WalletAccount 
{
    public int WalletTypeId { get; init; }
    public string AccountNumber { get; init; } = String.Empty;
    public string Field1 { get; init; } = String.Empty;
    public string Field2 { get; init; } = String.Empty;
    public string Field3 { get; init; } = String.Empty;

    public static readonly WalletAccount None = new();
    public bool IsDefault => Equals( None );

    public WalletAccount()
    {

    }

    public WalletAccount( 
        int walletType, 
        string? account = null,
        string? field1 = null,
        string? field2 = null,
        string? field3 = null)
    {
        WalletTypeId = walletType;
        AccountNumber = account ?? String.Empty;
        Field1 = field1 ?? String.Empty;
        Field2 = field2 ?? String.Empty;
        Field3 = field3 ?? String.Empty;
    }

}

