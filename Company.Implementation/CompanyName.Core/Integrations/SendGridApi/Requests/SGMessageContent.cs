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
