using AtlConsultingIo.IntegrationOperations;

using CompanyName.Core.Entities;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;
using CompanyName.Operations.Order;


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
