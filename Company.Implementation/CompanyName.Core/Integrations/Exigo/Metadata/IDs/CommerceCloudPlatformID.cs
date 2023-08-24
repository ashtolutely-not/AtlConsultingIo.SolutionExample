namespace CompanyName.Core.Integrations.Exigo;

public struct CommerceCloudPlatformID
{
    public string Value;
    public CommerceCloudPlatformID( string input ) => Value = input;

    public static implicit operator string( CommerceCloudPlatformID _ ) => _.Value;
}
