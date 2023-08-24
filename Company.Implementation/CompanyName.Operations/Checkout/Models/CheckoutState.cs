using System.Text.Json.Serialization;

using AtlConsultingIo.IntegrationOperations;

using CompanyName.Core.Entities;

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
