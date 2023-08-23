// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.
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
