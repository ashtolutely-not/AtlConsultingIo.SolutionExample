// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record IsTaxIDAvailableValidateRequest : ValidateRequest
{
    public string TaxID { get; init; }
    public int TaxTypeID { get; init; }
    public int ExcludeCustomerID { get; init; }

    public IsTaxIDAvailableValidateRequest( ) : base ( ) => TaxID = String.Empty;
}
