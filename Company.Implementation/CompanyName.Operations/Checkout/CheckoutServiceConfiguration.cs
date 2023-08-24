using System.Text.RegularExpressions;

using CompanyName.Core.Entities;
using CompanyName.Core.Integrations.Exigo;


namespace CompanyName.Operations.Checkout;

public class CheckoutServiceConfiguration
{
    public Options? Value { get; set; }

    public  record Options
    {
        public bool SaveOnValidationError { get; set; }
        public bool SaveOnDuplicateError { get; set; } 
        public bool SaveOnInvalidCartIdError { get; set; }
        public bool SaveOnPointTransactionError { get; set; }
        public string? RedisConnection { get; set; }
        public string CheckoutBlobsContainer { get; set; } = String.Empty;
        public string[ ] CheckoutSuccessQueues { get; set; } = Array.Empty<string> ( );
        public BusinessRules Rules { get; set; } = new ( );
        public CheckoutCacheOptions CacheOptions { get; set; } = new ( );


    }
}

public record CheckoutCacheOptions
{
    public int CartProcessingLockTimeToLiveInSeconds { get; set; } = 60;
    public bool ProductQueryCacheEnabled { get; set; }
    public int ProductCacheExpirationInMinutes { get; set; } = 60;
}
public record BusinessRules
{
    public SalesOrderRules SalesOrderRules { get; set; } = new ( );
    public SmartshipScheduleRules SmartshipRules { get; set; } = new();
    public AccountRegistrationRules RegistrationRules { get; set; } = new ( );
}
public record SalesOrderRules
{
    public decimal HighRiskTotalThreshold { get; set; }
    public string[ ] GiftCardItemsFilter { get; set; }

    public SalesOrderRules( )
    {
        HighRiskTotalThreshold = 2000;
        GiftCardItemsFilter = new string[ ] { "ADMIN-GC-0001" };  
    }
}
public record SmartshipScheduleRules
{
    public int MaxDayOfMonth { get; set; }
    public TimeOnly SmartshipProcessingTime { get; set; }

    public SmartshipScheduleRules( )
    {
        SmartshipProcessingTime = new TimeOnly ( 4 , 0 , 0 );
        MaxDayOfMonth = 27;
    }

    public DayOfMonth MaxDay => new DayOfMonth( MaxDayOfMonth );
}
public record AccountRegistrationRules
{
    public string? AccountUsernameRegexValidator { get; set; }
    public string? AccountPasswordRegexValidator { get; set; }
    public string? AccountWebAliasRegexValidator { get; set; }

    public int[ ] EnrollmentAccountTypeFilter { get; set; }
    public int EnrollmentVolumeMinimum { get; set; }
    public int EnrollmentKitLimitMinimum { get; set; }
    public int EnrollmentKitLimitMaximum { get; set; }
    public string[ ] DailyPayCountriesFilter { get; set; }
    public List<TaxIdRegExOption> TaxIDValidations { get; set; }

    public AccountRegistrationRules( )
    {
        AccountUsernameRegexValidator = @"^[^\\~`\[\]\s(){}!#\$&%^=+|:',;""\/]{6,20}$";
        AccountPasswordRegexValidator = @"^.{1,50}$";
        AccountWebAliasRegexValidator = @"^[^\\~`\[\]\s(){}!*#\$%^=+|:&'<>,;""\/]{3,20}$";
        EnrollmentVolumeMinimum = 40;
        EnrollmentKitLimitMinimum = 1;
        EnrollmentKitLimitMaximum = 1;
        EnrollmentAccountTypeFilter = defaultEnrollmentAccounts;
        DailyPayCountriesFilter = defaultDailyPayCountries;
        TaxIDValidations = defaultTaxValidators;
    }
    public static readonly AccountRegistrationRules Default = new();

    private static readonly string[] defaultDailyPayCountries = new string[] { "US" };
    private static readonly int[] defaultEnrollmentAccounts = new int[]{ DistributorAccount.Instance.TypeId , AffiliateAccount.Instance.TypeId };
    private static readonly List<TaxIdRegExOption> defaultTaxValidators = new List < TaxIdRegExOption >
    {
        new () { TaxCountryCode = "US", RegexPattern = @"^\d{9}$" },
        new () { TaxCountryCode = "CA", RegexPattern = @"^\d{9}$" },
        new () { TaxCountryCode = "EC", RegexPattern = @"^\d{10}$" },
        new () { TaxCountryCode = "KR", RegexPattern = @"^[a-zA-Z0-9]{9,16}$" },
        new () { TaxCountryCode = "HK", RegexPattern = @"^[A-MP-Z]{1,2}[0-9]{6}[0-9A]$" },
        new () { TaxCountryCode = "CN", RegexPattern = @"^[0-9]{17}[0-9X]$" },
        new () { TaxCountryCode = "IS", RegexPattern = @"^\d{6}?([- ]?)\d{4}$" },
    };
}
public record TaxIdRegExOption
{
    public string TaxCountryCode { get; init; } = string.Empty;
    public string RegexPattern { get; init; } = string.Empty;

    public bool Validate( string taxId )
    {
        if ( string.IsNullOrWhiteSpace ( taxId ) )
            return false;

        var regex = new Regex( RegexPattern );
        return regex.IsMatch ( taxId );
    }

}
