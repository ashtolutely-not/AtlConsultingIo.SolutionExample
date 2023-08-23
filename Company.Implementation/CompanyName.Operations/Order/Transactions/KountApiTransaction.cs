//public record KountApiTransaction : RestClientFormTransaction
//{
//    public KountApiTransaction( RiskTransactionInquiry riskInquiry ) : this( riskInquiry.SessionId)
//    {
//        FormContent = riskInquiry;
//        Convert = async(response) =>
//        {
//            var json = JObject.Parse( await response.Content.ReadAsStringAsync());
//            return new RiskTransactionResponse( json );
//        };
//    }
//    public KountApiTransaction( RiskTransactionUpdate riskUpdate ) : this( riskUpdate.SessionId )
//    {
//        FormContent = riskUpdate;
//        Convert = async(response) =>
//        {
//            var json = JObject.Parse( await response.Content.ReadAsStringAsync());
//            return new RiskTransactionResponse( json );
//        };        
//    }
//    public KountApiTransaction( string? contextID ) : this()
//    {
//        ContextID = contextID.HasValue() 
//                    ? new OperationContextID( contextID! )
//                    : new OperationContextID(); 
//    }
//    public KountApiTransaction()
//    {
//        IntegrationName = KountAPI.Instance;
//    }
//}
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

namespace CompanyName.Operations.Order;



