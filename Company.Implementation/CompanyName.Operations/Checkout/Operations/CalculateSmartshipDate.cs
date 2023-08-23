using CompanyName.Operations;
using CompanyName.Operations.Account;
using CompanyName.Operations.Checkout;
using CompanyName.Operations.Messaging;
using CompanyName.Operations.Order;
using CompanyName.Operations.Product;
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

namespace CompanyName.Operations.Checkout;

public record CalculateSmartshipDate 
{
    public DayOfMonth DayOfMonth { get; init; }
    public SmartshipScheduleRules Options { get; init; }
    public CalculateSmartshipDate( int? userSelectedDayOfMonth , SmartshipScheduleRules options )
    {
        DayOfMonth = userSelectedDayOfMonth is int _value ? new DayOfMonth ( _value ) : DayOfMonth.Today;
        Options = options;
    }

    public static Func<CalculateSmartshipDate, DateTime> Execute = ( commandParams ) =>
    {
        var dayOfMonth = commandParams.Options.MaxDayOfMonth > commandParams.DayOfMonth 
                         ? commandParams.DayOfMonth : DayOfMonth.DayOne;

        var startMonth = commandParams.Options.MaxDayOfMonth > commandParams.DayOfMonth 
                            ? CurrentMonth + 1 : CurrentMonth + 2;

        var startYear = CurrentYear;

        //did adding the months move us into a new year
        if( startMonth > 12 )
            ( startMonth, startYear) = ( 1, startYear + 1 );

        DateOnly startDate = new DateOnly( startYear, startMonth, dayOfMonth );
        DateTime processingDate = startDate.ToDateTime( commandParams.Options.SmartshipProcessingTime );

        return processingDate;
    };

    private static int CurrentMonth => DateTime.UtcNow.Month;
    private static int CurrentYear => DateTime.UtcNow.Year;
}
