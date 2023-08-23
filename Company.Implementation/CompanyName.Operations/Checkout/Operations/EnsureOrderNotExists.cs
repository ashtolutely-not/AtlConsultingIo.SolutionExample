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

using AtlConsultingIo.IntegrationOperations;


namespace CompanyName.Operations.Checkout;

public record EnsureOrderNotExists : SalesOrderRestQuery, ICheckoutOperation<EnsureOrderNotExists,OrderID?>
{
    private readonly IIntegrationsService _integrations;
    public EnsureOrderNotExists( OperationContextID contextID, CartID cartId , IIntegrationsService integrationService ) 
        : base( contextID, cartId, false, null )
    {
        _integrations = integrationService;
    }

    public OrderID? Result { get; init; }

    public async Task<EnsureOrderNotExists> ExecuteAsync( CancellationToken cancellationToken )
    {
        OrderResponse? order = await SalesOrderRestQuery.Find( this, _integrations, cancellationToken ).ConfigureAwait( false );
        return order is null ? this : this with { Result = new OrderID( order.OrderID ) };
    }
}
