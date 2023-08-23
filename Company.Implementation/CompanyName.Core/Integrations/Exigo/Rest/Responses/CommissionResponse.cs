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
public record CommissionResponse
{
    public int CustomerID { get; init; }
    public int PeriodType { get; init; }
    public int PeriodID { get; init; }
    public string PeriodDescription { get; init; }
    public string CurrencyCode { get; init; }
    public Decimal CommissionTotal { get; init; }
    public CommissionBonusResponse[] Bonuses { get; init; }
    public string CustomerKey { get; init; }

    public CommissionResponse() : base()
    {
        PeriodDescription = String.Empty;
        CurrencyCode = String.Empty;
        Bonuses = new CommissionBonusResponse[0];
        CustomerKey = String.Empty;
    }
}
