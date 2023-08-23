namespace AtlConsultingIo.IntegrationOperations;

public interface IHttpSendHandler
{
    Task<HttpSendState> SendAsync( HttpSendState sendState , CancellationToken cancellationToken );
}
