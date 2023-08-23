using CompanyName.Core;
using CompanyName.Core.Entities;
using CompanyName.Core.Entities.Events;
using CompanyName.Core.Entities.Messaging;
using CompanyName.Core.Entities.Order;
using CompanyName.Core.Entities.Product;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;
using CompanyName.Core.Integrations.Exigo.Sql;
using CompanyName.Core.Integrations.KountApi;
using CompanyName.Core.Integrations.SendGridApi;
namespace CompanyName.Core.Entities.User;

[DapperHandler]
[NewtonsoftConverter]
public struct DailyPaySettingIsEnabled : IBooleanValue, IEquatable<bool>, IEquatable<string>
{
    private const string _enabled = "1";
    private const string _disabled = "0";

    public bool Value { get; set; }

    public DailyPaySettingIsEnabled( string input )
        => Value = input.Trim().Equals( _enabled );

    public DailyPaySettingIsEnabled( bool input )
        => Value = input;

    public bool True => Value.Equals( true );
    public bool False => Value.Equals( false );

    public static implicit operator bool( DailyPaySettingIsEnabled _ )
        => _.Value;

    public static implicit operator string( DailyPaySettingIsEnabled _ )
        => _.Value.Equals(true) ? _enabled : _disabled;

	public bool Equals( bool other ) => Value.Equals( other );
	public bool Equals( string? other ) 
        => !string.IsNullOrWhiteSpace(other) && _enabled.Equals( other );
}
