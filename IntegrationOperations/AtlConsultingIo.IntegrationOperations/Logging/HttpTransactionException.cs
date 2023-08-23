
using FluentValidation;

namespace AtlConsultingIo.IntegrationOperations;
public class HttpSendException : Exception
{
    public IntegrationKey ApiClientName { get; set; }
    public string RequestMethod { get; set; } = string.Empty;
    public string RequestUrl { get; set; } = string.Empty;
    public int StatusCode { get; set; }
    public string Reason { get; set; } = string.Empty;
    public object? RequestData { get; set; }



    internal HttpSendException(  HttpSendState sendState ) 
        : base( $"{sendState.ClientName.Value}_Exception: { sendState.SendException?.Message ?? StringValue.NullPrintString }", sendState.SendException )
    {
        ApiClientName = sendState.ClientName;
        RequestMethod = sendState.HttpRequest.Method.Method;

        RequestUrl = sendState.HttpRequest.RequestUri?.ToString() ?? String.Empty;

        StatusCode = sendState.HttpResponse is not null ? (int)sendState.HttpResponse.StatusCode : 0;
        Reason = sendState.HttpResponse is HttpResponseMessage _resp && _resp.ReasonPhrase.HasValue() ? _resp.ReasonPhrase! : String.Empty;
    }


}
