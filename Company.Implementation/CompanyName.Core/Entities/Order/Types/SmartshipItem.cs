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
public  record SmartshipItem
{
    public string ItemCode { get; private init; }
    public int Quantity { get; private init; }
    internal SmartshipItem()
    {
        ItemCode = string.Empty;
        Quantity = 0;
    }
    public SmartshipItem( string itemCode, int quantity )
    {
        ItemCode = itemCode;
        Quantity = quantity;
    }
    public bool IsEmpty => Equals( Empty );
    public static readonly SmartshipItem Empty = new();

}
