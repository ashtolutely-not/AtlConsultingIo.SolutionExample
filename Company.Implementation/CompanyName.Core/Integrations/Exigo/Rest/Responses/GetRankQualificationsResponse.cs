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

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetRankQualificationsResponse : ApiResponse
{
    public int CustomerID { get; init; }
    public int RankID { get; init; }
    public string RankDescription { get; init; }
    public bool Qualifies { get; init; }
    public bool? QualifiesOverride { get; init; }
    public QualificationResponse[][] PayeeQualificationLegs { get; init; }
    public int? BackRankID { get; init; }
    public string BackRankDescription { get; init; }
    public int? NextRankID { get; init; }
    public string NextRankDescription { get; init; }
    public Decimal Score { get; init; }
    public string CustomerKey { get; init; }

    public GetRankQualificationsResponse() : base()
    {
        RankDescription = String.Empty;
        PayeeQualificationLegs = new QualificationResponse[0][];
        BackRankDescription = String.Empty;
        NextRankDescription = String.Empty;
        CustomerKey = String.Empty;
    }
}
