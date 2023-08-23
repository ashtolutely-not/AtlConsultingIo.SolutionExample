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
namespace CompanyName.Core.Entities;

public struct ShoppingCartTotal : IDecimalValue, IEquatable<decimal?>, IEquatable<decimal>
{
    public decimal Value { get; set; }
    public bool IsDefault => Value.Equals( 0 );
    public ShoppingCartTotal( decimal? input )
        => Value = input.GetValueOrDefault();

    public static implicit operator decimal( ShoppingCartTotal _ ) => _.Value;

    public static readonly ShoppingCartTotal Default = new();
	public bool Equals( decimal other ) => Value.Equals( other );
	public bool Equals( decimal? other ) => Value.Equals( other.GetValueOrDefault() );
}
