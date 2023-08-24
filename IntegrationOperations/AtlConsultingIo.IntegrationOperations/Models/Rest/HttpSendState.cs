namespace AtlConsultingIo.IntegrationOperations;

public sealed record HttpSendState
{
    private static readonly HttpRequestMessage _defaultRequest = new();
    public HttpRequestMessage HttpRequest { get; private init; }
    public HttpResponseMessage? HttpResponse { get; private init; }
    public Exception? SendException { get; private init; }
    public OperationContextID ContextID { get; private init; }
    public IntegrationKey ClientName { get; private init; }
    private HttpSendState()
    {
        HttpRequest = _defaultRequest;
        HttpResponse = null;
    }

    public HttpSendState( IntegrationKey name, OperationContextID contextID, HttpRequestMessage request )
    {
        ClientName = name;
        ContextID = contextID;
        HttpRequest = request;
        HttpResponse = null;
    }

    public HttpSendState WithHttpResponse( HttpResponseMessage response )
    {
        return this with
        {
            HttpResponse = response,
            HttpRequest = response.RequestMessage is not HttpRequestMessage _request ? HttpRequest : _request
        };
    }
    public HttpSendState WithSendException( Exception exception )
    {
        return this with { SendException = exception };
    }

    public static readonly HttpSendState Default = new();
}
