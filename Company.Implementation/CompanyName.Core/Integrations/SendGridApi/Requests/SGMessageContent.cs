using AtlConsultingIo.IntegrationOperations;
namespace CompanyName.Core.Integrations.SendGridApi;
public record SGMessageContent
{
    [JsonProperty( PropertyName = "type" )]
    public string MimeType { get; init; } = String.Empty;
    [JsonProperty( PropertyName = "value" )]
    public string Value { get; init; } = String.Empty;

    public SGMessageContent()
    {
        
    }

    public SGMessageContent( string contentType, string content )
    {
        MimeType = contentType;
        Value = content;
    }
}

    public record PlainTextContent : SGMessageContent
    {
        public PlainTextContent() : base( HttpContentType.Text , string.Empty ) { }

        public PlainTextContent( string value ) : base( HttpContentType.Text , value ) { }
    }

    public record HtmlContent : SGMessageContent
    {
        public HtmlContent() : base( HttpContentType.Html , string.Empty ) { }

        public HtmlContent( string value ) : base( HttpContentType.Html , value ) { }
    }
