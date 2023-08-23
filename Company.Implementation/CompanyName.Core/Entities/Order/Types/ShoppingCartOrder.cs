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



namespace CompanyName.Core.Entities.Order;
public record ShoppingCartOrder : CreateOrderRequest
{
    public CustomerID UserId
    {
        get => new CustomerID ( base.CustomerID );
        set => base.CustomerID = value;
    }
    public CustomerID? VolumeOwnerId
    {
        get => int.TryParse ( base.Other11 , out var res ) ? new CustomerID ( res ) : null;
        set => base.Other11 = value.HasValue ? ( string ) value : String.Empty;
    }
    public CartID CartId
    {
        get => new CartID ( base.Other18 );
        set => base.Other18 = value;
    }
    public OrderPaymentIsHighRisk IsHighRisk
    {
        get => new OrderPaymentIsHighRisk ( base.Other17 );
        set => base.Other17 = value;
    }
    public ShoppingCartTotal CartTotal { get; init; }
    public CheckoutIP ClientIp { get; init; }
    public UserSiteUrl? CheckoutSite { get; init; }
    public DayOfMonth? SelectedSmartshipDay { get; init; }
    public SmartshipItem[ ] SmartshipItems { get; init; } = Array.Empty<SmartshipItem> ( );
}
