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

public sealed record CheckoutRequest
{
    private static readonly ShoppingCartOrder _defaultOrder = new();
    public CustomerID UserId => AccountRegistration is not null ?
                            CustomerID.Default : new CustomerID ( CartOrder.CustomerID );
    public CartID CartId => CartOrder.CartId;
    public CheckoutIP ClientIP { get; init; }
    public TotalLifePriceType PriceType { get; init; } = null!;
    public PointAcccountPaymentAmount PointPaymentAmount { get; init; }
    public GiftCardPaymentAmount GiftCardPaymentAmount { get; init; }
    public ShoppingCartPayment? MerchantPayment { get; init; }
    public ShoppingCartOrder CartOrder { get; init; } = _defaultOrder;
    public AccountRegistration? AccountRegistration { get; init; }
    public Dictionary<string , object> ContextData { get; init; } = new ( );

    public static OperationContextID CreateOperationID( CheckoutRequest request )
    => new OperationContextID ( string.Join ( "-" , request.CartId , Guid.NewGuid ( ).ToString ( "N" ) ) );

    public TData? TryGetContextValue<TData>( string contextKey )
    {
        var dictValue = ContextData.TryGetValue(contextKey, out var obj ) ? obj : null;
        if ( dictValue is null || dictValue is not TData )
            return default;

        return ( TData ) dictValue;
    }
}
