using CompanyName.Core.Entities;

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
