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



namespace CompanyName.Core.Integrations.Exigo;

public readonly record struct ExigoApiError
{
    public readonly string Value;

    public ExigoApiError( HttpResponseMessage HttpResponse )
    {
       Value = $"Exigo Api Failed.  Response Status: { HttpResponse.StatusCode.ToString() }({(int)HttpResponse.StatusCode}) | ReasonPhrase: { HttpResponse.ReasonPhrase ?? PrintString.Null }";     
    }

    public static implicit operator string (  ExigoApiError _ ) => _.Value ;
}
public readonly record struct JsonSerializationError<T>
{
    public readonly string Value;

    public JsonSerializationError( IntegrationKey Integration )
    {
        Value = $"Could not deserialize HTTP Response Content to response type of { typeof(T).Name }. ( Integration Key: { Integration.Value } )";
    }

    public static implicit operator string( JsonSerializationError<T> _ ) => _.Value;
}
public readonly record struct NotFoundError<T>
{
    public readonly string Value;

    public NotFoundError( )
    {
        Value = $"{ typeof(T).Name } returned no results.";    
    }
    public static implicit operator string( NotFoundError<T> _ ) => _.Value;
}

public readonly record struct OperationErrorString<TIntegrationRequest> where TIntegrationRequest : IIntegrationOperation
{
    public readonly PrintString Integration;
    public readonly PrintString Operation;
    public readonly PrintString Error;
    public OperationErrorString( TIntegrationRequest operation )
    {
        Integration = IStringValue.Create<PrintString>( operation.Key.Value );
        Operation = IStringValue.Create<PrintString>( operation.GetType ( ).Name );
        Error = IStringValue.Create<PrintString>( operation.OperationError.EmptyIfNull() );
    }

    public static implicit operator string(  OperationErrorString<TIntegrationRequest> _ )
        => $"Integration: { _.Integration } | Operation: { _.Operation } | Error: { _.Error }";
}

