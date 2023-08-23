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
using AtlConsultingIo.IntegrationOperations;
using System.Text.Json.Serialization;

namespace CompanyName.Operations.Checkout;

public record CheckoutState 
{
    public CartID CartID { get; init; }  
    public CheckoutContext Context { get; init; } = CheckoutContext.Default;
    public CheckoutResult? Result { get; init; } 

    public UIDisplayString? ProcessingError { get; init;  } 

    public StorageBlobName GetBlobName( )
    {
        var virtualDirectory = Result is not null ?  "complete" : "incomplete" ;
        string fullPath = Path.Combine( virtualDirectory, OperationContextID );

        return new StorageBlobName( fullPath + ".json" );
    }

    private OperationContextID? _contextID;
    public OperationContextID OperationContextID 
    {   
        get 
        {
            if(!_contextID.HasValue)
                _contextID = new ( string.Join ( "-" , CartID.Value , Result?.OrderId?.Value.ToString ( ) , UniqueSuffix ) );
            return _contextID.Value;
        } 
    }
    private static string UniqueSuffix => Guid.NewGuid().ToString("N");

    [JsonConstructor]
    private CheckoutState( )
    {
            
    }

    public CheckoutState( CartID cartId )
    {
            CartID = cartId;
    }

    public static readonly CheckoutState Default = new();
}
