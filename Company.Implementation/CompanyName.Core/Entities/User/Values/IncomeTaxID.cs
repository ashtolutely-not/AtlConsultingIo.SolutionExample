/// <summary>
/// Accounts created for Influencers, LifeChangers, or any account type that receives
/// commission payouts must have a TaxId on file for the purpose of income tax reporting.
/// Note: The Exigo API / database naming is not consistent:
/// - Exigo.Api.CreateCustomerRequest.TaxID maps to Customer.TaxCode in the database (this is the value we want)
/// - Exigo.Api.CustomerResponse.TaxID maps to Customer.SalesTaxID in the database
/// - So, to check for duplicate Ids, we HAVE to query the database
/// </summary>
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
namespace CompanyName.Core.Entities.User;


public  struct IncomeTaxID : IStringValue, IEquatable<string?>
{
    public string Value { get; set; }
    public bool IsNullOrDefault => string.IsNullOrWhiteSpace( Value );
    public IncomeTaxID( string? input )
        => Value = input ?? String.Empty;

    public bool Equals( string? other ) => !string.IsNullOrWhiteSpace ( other ) && Value.Equals ( other , StringComparison.OrdinalIgnoreCase );

    public static implicit operator string( IncomeTaxID _ ) => _.Value;
    public static readonly IncomeTaxID Default = new( );

}
