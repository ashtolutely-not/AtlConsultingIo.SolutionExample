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

public struct DayOfMonth : IEquatable<int>, IEquatable<int?>
{
	public readonly int Value;
    public bool IsDefault => Value.Equals( 0 );
	public DayOfMonth( int input ) => Value = input >=1 && input <= 31 ? input : Today;

	public DateTime GetSmartshipStartDate( DayOfMonth maxDayOfMonth )
    {
        var now = CstDateTime.Now;
        var isValidDay = this <= maxDayOfMonth;

        DateTime monthDate = isValidDay ? now.AddMonths( 1 ) : now.AddMonths( 2 );
        int dayDate = isValidDay ? this : DayOne;

        return new( monthDate.Year , monthDate.Month , dayDate , 3 , 0 , 0 );
    }

	public bool Equals( int other ) => Value.Equals( other );
	public bool Equals( int? other )
	=> Value.Equals( other.GetValueOrDefault() );

	public static implicit operator int( DayOfMonth _ )
		=> _.Value;

	public static readonly DayOfMonth Default = new();
	public static readonly DayOfMonth DayOne = new(1);
	public static DayOfMonth Today => new( DateTime.UtcNow.Day );
}
