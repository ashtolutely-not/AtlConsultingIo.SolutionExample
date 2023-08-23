

namespace AtlConsultingIo.IntegrationOperations;
public struct IntegrationKey 
{
    public string Value { get; set; }
    public string SafeName => Value.AlphaNumericCharactersOnly();
    public bool IsEmpty => string.IsNullOrWhiteSpace(Value.Trim());

    public IntegrationKey()
    {
        Value = String.Empty;
    }
    public IntegrationKey( string name ) => Value = name;

    public static readonly IntegrationKey Default = new();
    public static implicit operator string(IntegrationKey _) => _.Value;
}
