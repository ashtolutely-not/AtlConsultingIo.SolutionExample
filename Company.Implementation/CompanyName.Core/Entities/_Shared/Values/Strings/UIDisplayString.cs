namespace CompanyName.Core.Entities;

public struct UIDisplayString
{
    public string Value { get; }
    public UIDisplayString( string input ) => Value = input;

    public static implicit operator string ( UIDisplayString _ ) => _.Value;
}
