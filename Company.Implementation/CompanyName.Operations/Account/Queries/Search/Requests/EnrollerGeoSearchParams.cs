namespace CompanyName.Operations.Account;
public record EnrollerGeoSearchParams 
{
    public string LanguageFilter { get; init; } = String.Empty;
    public string Country { get; init; } = String.Empty;
    public string Region { get; init; } = String.Empty;
    public string FirstNameFilter { get; init; } = String.Empty;
    public string LastNameFilter { get; init; } = String.Empty;

    public object QueryParams()
        => new
        {
            firstName = FirstNameFilter,
            lastName = LastNameFilter,
            region = Region,
            country = Country,
            language = LanguageFilter
        };

    public bool IsEmpty =>
        !LanguageFilter.HasValue() &&
        !Country.HasValue() &&
        !Region.HasValue() &&
        !FirstNameFilter.HasValue() &&
        !LastNameFilter.HasValue();
    public static readonly EnrollerGeoSearchParams Empty = new();
}
