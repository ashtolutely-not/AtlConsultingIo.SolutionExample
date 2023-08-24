// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.
using System.Data;
namespace CompanyName.Core.Integrations.Exigo.Rest;
public record QualificationResponse
{
    public string QualificationDescription { get; init; }
    public string Required { get; init; }
    public string Actual { get; init; }
    public bool Qualifies { get; init; }
    public bool? QualifiesOverride { get; init; }
    public DataTable? SupportingTable { get; init; }
    public Decimal Completed { get; init; }
    public Decimal Weight { get; init; }
    public Decimal Score { get; init; }

    public QualificationResponse() : base()
    {
        QualificationDescription = String.Empty;
        Required = String.Empty;
        Actual = String.Empty;
    }
}
