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

public readonly record struct PointAcccountPaymentAmount : IEquatable<decimal> , IEquatable<decimal?>
{
    public readonly decimal Value;
    public bool IsDefault => Value.Equals( 0 );
    public PointAcccountPaymentAmount( decimal? value ) 
        => Value = value.GetValueOrDefault();

    public PointAcccountPaymentAmount( decimal value )
        => Value = value;

    public PointAcccountPaymentAmount( int? value )
        => Value = value.GetValueOrDefault();

    public static implicit operator decimal ( PointAcccountPaymentAmount _ )
        => _.Value;

    public static readonly PointAcccountPaymentAmount Default = new(  );
	public bool Equals( decimal other ) => Value.Equals( other );
	public bool Equals( decimal? other ) => other.GetValueOrDefault().Equals( Value );
}
