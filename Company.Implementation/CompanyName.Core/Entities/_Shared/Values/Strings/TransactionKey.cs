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

public readonly record struct TransactionKey
{
    public string Value { get; }
    public bool IsNullOrDefault => string.IsNullOrWhiteSpace( Value );

    public TransactionKey( string input ) => Value = input;

    public static readonly TransactionKey Default;

    public static implicit operator string( TransactionKey _ ) => _.Value;

}