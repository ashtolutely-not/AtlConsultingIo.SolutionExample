// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.
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

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CreateCustomerExtendedRequest : ApiRequest, ITransactionMember
{
    public int CustomerID { get; init; }
    public int ExtendedGroupID { get; init; }
    public string Field1 { get; init; }
    public string Field2 { get; init; }
    public string Field3 { get; init; }
    public string Field4 { get; init; }
    public string Field5 { get; init; }
    public string Field6 { get; init; }
    public string Field7 { get; init; }
    public string Field8 { get; init; }
    public string Field9 { get; init; }
    public string Field10 { get; init; }
    public string Field11 { get; init; }
    public string Field12 { get; init; }
    public string Field13 { get; init; }
    public string Field14 { get; init; }
    public string Field15 { get; init; }
    public string Field16 { get; init; }
    public string Field17 { get; init; }
    public string Field18 { get; init; }
    public string Field19 { get; init; }
    public string Field20 { get; init; }
    public string Field21 { get; init; }
    public string Field22 { get; init; }
    public string Field23 { get; init; }
    public string Field24 { get; init; }
    public string Field25 { get; init; }
    public string Field26 { get; init; }
    public string Field27 { get; init; }
    public string Field28 { get; init; }
    public string Field29 { get; init; }
    public string Field30 { get; init; }
    public string CustomerKey { get; init; }

    public CreateCustomerExtendedRequest() : base()
    {
        Field1 = String.Empty;
        Field2 = String.Empty;
        Field3 = String.Empty;
        Field4 = String.Empty;
        Field5 = String.Empty;
        Field6 = String.Empty;
        Field7 = String.Empty;
        Field8 = String.Empty;
        Field9 = String.Empty;
        Field10 = String.Empty;
        Field11 = String.Empty;
        Field12 = String.Empty;
        Field13 = String.Empty;
        Field14 = String.Empty;
        Field15 = String.Empty;
        Field16 = String.Empty;
        Field17 = String.Empty;
        Field18 = String.Empty;
        Field19 = String.Empty;
        Field20 = String.Empty;
        Field21 = String.Empty;
        Field22 = String.Empty;
        Field23 = String.Empty;
        Field24 = String.Empty;
        Field25 = String.Empty;
        Field26 = String.Empty;
        Field27 = String.Empty;
        Field28 = String.Empty;
        Field29 = String.Empty;
        Field30 = String.Empty;
        CustomerKey = String.Empty;
    }
}
