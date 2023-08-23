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
namespace CompanyName.Core.Entities;

public struct CstDateTime : IEquatable<DateOnly>, IEquatable<string?>
{
    public DateTime Value { get; }
    public CstDateTime( DateTime dateTime )
    {
        if( dateTime.Kind != DateTimeKind.Utc )
        {
            DateTime utc = TimeZoneInfo.ConvertTimeToUtc(dateTime);
            Value = TimeZoneInfo.ConvertTimeFromUtc( utc, TimeZone );
        }
        else Value = TimeZoneInfo.ConvertTimeFromUtc(dateTime, TimeZone);
    }

    public CstDateTime( ) => Value = Now;

    public static implicit operator DateTime( CstDateTime _ ) => _.Value;
    public static implicit operator string( CstDateTime _ ) => _.Value.ToString();

    public static readonly TimeZoneInfo TimeZone 
        = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");

    public static DateTime Now 
        => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZone);

	public bool Equals( DateOnly other ) => DateOnly.FromDateTime( Value ).Equals( other );
	public bool Equals( string? other ) 
        => !string.IsNullOrWhiteSpace(other) && Value.ToString().Equals(other);
}
