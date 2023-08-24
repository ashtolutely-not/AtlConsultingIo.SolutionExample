namespace CompanyName.Core.Integrations.SendGridApi;
public record SGEmailMessage 
{

    [JsonProperty( PropertyName = "mail_settings" )]
    public DeliverySetting MailSettings { get; set; } = new();

    [JsonProperty( PropertyName = "headers" , IsReference = false )]
    public Dictionary<string , string> Headers { get; set; } = new();

    [JsonProperty( PropertyName = "sections" , IsReference = false )]
    public Dictionary<string , string> Sections { get; set; } = new();

    [JsonProperty( PropertyName = "custom_args" , IsReference = false )]
    public Dictionary<string , string> CustomArgs { get; set; } = new();

    [JsonProperty( PropertyName = "from" )]
    public SGEmailAddress From { get; set; }

    [JsonProperty( PropertyName = "reply_to" )]
    public SGEmailAddress ReplyTo { get; set; }

    [JsonProperty( PropertyName = "reply_to_list" , IsReference = false )]
    public List<SGEmailAddress> ReplyTos { get; set; } = new();

    [JsonProperty( PropertyName = "attachments" , IsReference = false )]
    public List<SGMessageAttachment> Attachments { get; set; } = new();

    [JsonProperty( PropertyName = "content" , IsReference = false )]
    public List<SGMessageContent> Contents { get; set; } = new();

    [JsonProperty( PropertyName = "personalizations" , IsReference = false )]
    public List<SGMessagePersonalization> Personalizations { get; set; } = new();

    [JsonProperty( PropertyName = "categories" , IsReference = false )]
    public List<string> Categories { get; set; } = new();

    [JsonProperty( PropertyName = "send_at" )]
    public long? SendAt { get; set; }

    [JsonProperty( PropertyName = "subject" )]
    public string? Subject { get; set; }

    [JsonIgnore]
    public string? PlainTextContent { get; set; }

    [JsonIgnore]
    public string? HtmlContent { get; set; }

    [JsonProperty( PropertyName = "template_id" )]
    public string? TemplateId { get; set; }

    [JsonProperty( PropertyName = "batch_id" )]
    public string? BatchId { get; set; }

    [JsonProperty( PropertyName = "ip_pool_name" )]
    public string? IpPoolName { get; set; }

    [JsonProperty( PropertyName = "tracking_settings" )]
    public TrackingSetting TrackingSettings { get; set; } = new();

    [JsonProperty( PropertyName = "asm" )]
    public UnsubscribeSetting UnsubscribeSetting { get; set; } = new();

    private SGMessagePersonalization GetPersonalization( int personalizationIndex = 0 , SGMessagePersonalization? personalization = null )
    {
        if ( personalization != null )
        {
            Personalizations ??= new();
            Personalizations.Add( personalization );
        }
        else if ( Personalizations != null )
        {
            if ( personalizationIndex > Personalizations.Count ) throw new ArgumentException( "personalizationIndex " + personalizationIndex + " must not be greater than " + Personalizations.Count );

            if ( personalizationIndex == Personalizations.Count ) Personalizations.Add( new() );

            personalization = Personalizations[ personalizationIndex ];
        }
        else
        {
            personalization = new();
            Personalizations = new() { personalization };
        }

        return personalization;
    }

    public async Task AddAttachmentAsync( string filename , Stream contentStream , string? type = null , string? disposition = null , string? content_id = null , CancellationToken cancellationToken = default )
    {
        if ( contentStream != null && contentStream.CanRead )
        {
            var num = Convert.ToInt32(contentStream.Length);
            var streamBytes = new byte[num];
            await contentStream.ReadAsync( streamBytes , 0 , num , cancellationToken );
            var base64Content = Convert.ToBase64String(streamBytes);
            AddAttachment( filename , base64Content , type , disposition , content_id );
        }
    }

    public void AddTos( List<SGEmailAddress> emails , int personalizationIndex = 0 , SGMessagePersonalization? personalization = null )
    {
        personalization = GetPersonalization( personalizationIndex , personalization );
        personalization.Tos = personalization.Tos;
        personalization.Tos.AddRange( emails );
    }

    public void AddCcs( List<SGEmailAddress> emails , int personalizationIndex = 0 , SGMessagePersonalization? personalization = null )
    {
        personalization = GetPersonalization( personalizationIndex , personalization );
        personalization.Ccs ??= new List<SGEmailAddress>();
        personalization.Ccs.AddRange( emails );
    }

    public void AddBcc( SGEmailAddress email , int personalizationIndex = 0 , SGMessagePersonalization? personalization = null ) => AddBccs( new() { email } , personalizationIndex , personalization );

    public void AddBccs( List<SGEmailAddress> emails , int personalizationIndex = 0 , SGMessagePersonalization? personalization = null )
    {
        personalization = GetPersonalization( personalizationIndex , personalization );
        personalization.Bccs ??= new List<SGEmailAddress>();
        personalization.Bccs.AddRange( emails );
    }

    public void SetSubject( string subject , int personalizationIndex = 0 , SGMessagePersonalization? personalization = null )
    {
        personalization = GetPersonalization( personalizationIndex , personalization );
        personalization.Subject = subject;
    }

    public void AddHeader( string headerKey , string headerValue , int personalizationIndex = 0 , SGMessagePersonalization? personalization = null ) => AddHeaders( new() { { headerKey , headerValue } } , personalizationIndex , personalization );

    public void AddHeaders( Dictionary<string , string> headers , int personalizationIndex = 0 , SGMessagePersonalization? personalization = null )
    {
        personalization = GetPersonalization( personalizationIndex , personalization );
        personalization.Headers = personalization.Headers == null ? headers : personalization.Headers.Union( headers ).ToDictionary( ( pair ) => pair.Key , ( pair ) => pair.Value );
    }

    public void AddSubstitution( string substitutionKey , string substitutionValue , int personalizationIndex = 0 , SGMessagePersonalization? personalization = null ) => AddSubstitutions( new() { { substitutionKey , substitutionValue } } , personalizationIndex , personalization );

    public void AddSubstitutions( Dictionary<string , string> substitutions , int personalizationIndex = 0 , SGMessagePersonalization? personalization = null )
    {
        personalization = GetPersonalization( personalizationIndex , personalization );
        personalization.Substitutions = personalization.Substitutions == null ? substitutions : personalization.Substitutions.Union( substitutions ).ToDictionary( ( pair ) => pair.Key , ( pair ) => pair.Value );
    }

    public void SetTemplateData( object dynamicTemplateData , int personalizationIndex = 0 , SGMessagePersonalization? personalization = null )
    {
        personalization = GetPersonalization( personalizationIndex , personalization );
        personalization.TemplateData = dynamicTemplateData;
    }

    public void AddCustomArg( string customArgKey , string customArgValue , int personalizationIndex = 0 , SGMessagePersonalization? personalization = null ) => AddCustomArgs( new() { { customArgKey , customArgValue } } , personalizationIndex , personalization );

    public void AddCustomArgs( Dictionary<string , string> customArgs , int personalizationIndex = 0 , SGMessagePersonalization? personalization = null )
    {
        personalization = GetPersonalization( personalizationIndex , personalization );
        personalization.CustomArgs = personalization.CustomArgs == null ? customArgs : personalization.CustomArgs.Union( customArgs ).ToDictionary( ( pair ) => pair.Key , ( pair ) => pair.Value );
    }

    public void SetSendAt( long sendAt , int personalizationIndex = 0 , SGMessagePersonalization? personalization = null )
    {
        personalization = GetPersonalization( personalizationIndex , personalization );
        personalization.SendAt = sendAt;
    }

    public void AddAttachment( string filename , string base64Content , string? type = null , string? disposition = null , string? content_id = null )
    {
        if ( !string.IsNullOrWhiteSpace( filename ) && !string.IsNullOrWhiteSpace( base64Content ) )
        {
            var attachment = new SGMessageAttachment
            {
                Filename = filename,
                Content = base64Content,
                Type = type ?? String.Empty,
                Disposition = disposition ?? String.Empty,
                ContentId = content_id ?? String.Empty
            };
            Attachments.Add( attachment );
        }
    }
}
