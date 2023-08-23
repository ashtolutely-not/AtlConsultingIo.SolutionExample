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

public struct PaymentAccountChargeAmount : IDecimalValue, IEquatable<decimal>, IEquatable<decimal?>
{
    public decimal Value { get; set; }
    public bool IsDefault => Value.Equals( 0 );

    private PaymentAccountChargeAmount( decimal value ) => Value = value;
    public static PaymentAccountChargeAmount Create( decimal? nullableValue )
        => new PaymentAccountChargeAmount( nullableValue ?? 0 );

    public static implicit operator decimal ( PaymentAccountChargeAmount _ )
        => _.Value;

    public static readonly PaymentAccountChargeAmount None = new( 0 );

	public bool Equals( decimal other ) => Value.Equals( other );
    public bool Equals( decimal? other ) => other.GetValueOrDefault().Equals( Value );
}
