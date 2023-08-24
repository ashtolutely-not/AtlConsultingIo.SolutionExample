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

namespace CompanyName.Operations.Order;



