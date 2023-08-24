namespace CompanyName.Core.Integrations.SendGridApi;
public record SGMessagePersonalization
{
    //
    // Summary:
    //     Gets or sets the object allowing you to specify specific handling instructions
    //     for your email.
    [JsonProperty( PropertyName = "headers" , IsReference = false )]
    public Dictionary<string , string> Headers { get; set; } = new();

    //
    // Summary:
    //     Gets or sets an object following the pattern "substitution_tag":"value to substitute".
    //     All are assumed to be strings. These substitutions will apply to the content
    //     of your email, in addition to the subject and reply-to parameters. You may not
    //     include more than 100 substitutions per personalization object, and the total
    //     collective size of your substitutions may not exceed 10,000 bytes per personalization
    //     object.
    [JsonProperty( PropertyName = "substitutions" , IsReference = false )]
    public Dictionary<string , string> Substitutions { get; set; } = new();

    //
    // Summary:
    //     Gets or sets the values that are specific to this personalization that will be
    //     carried along with the email, activity data, and links. Substitutions will not
    //     be made on custom arguments. personalizations[x].custom_args will be merged with
    //     message level custom_args, overriding any conflicting keys. The combined total
    //     size of the resulting custom arguments, after merging, for each personalization
    //     may not exceed 10,000 bytes.
    [JsonProperty( PropertyName = "custom_args" , IsReference = false )]
    public Dictionary<string , string> CustomArgs { get; set; } = new();

    //
    // Summary:
    //     Gets or sets the from email address. The domain must match the domain of the
    //     from email property specified at root level of the request body.
    [JsonProperty( PropertyName = "from" )]
    public SGEmailAddress From { get; set; }

    //
    // Summary:
    //     Gets or sets an array of recipients. Each email object within this array may
    //     contain the recipient’s name, but must always contain the recipient’s email.
    [JsonProperty( PropertyName = "to" , IsReference = false )]
    [JsonConverter( typeof( EmailListConverter ) )]
    public List<SGEmailAddress> Tos { get; set; } = new();

    //
    // Summary:
    //     Gets or sets an array of recipients who will receive a copy of your email. Each
    //     email object within this array may contain the recipient’s name, but must always
    //     contain the recipient’s email.
    [JsonProperty( PropertyName = "cc" , IsReference = false )]
    [JsonConverter( typeof( EmailListConverter ) )]
    public List<SGEmailAddress> Ccs { get; set; } = new();

    //
    // Summary:
    //     Gets or sets an array of recipients who will receive a blind carbon copy of your
    //     email. Each email object within this array may contain the recipient’s name,
    //     but must always contain the recipient’s email.
    [JsonProperty( PropertyName = "bcc" , IsReference = false )]
    [JsonConverter( typeof( EmailListConverter ) )]
    public List<SGEmailAddress> Bccs { get; set; } = new();

    //
    // Summary:
    //     Gets or sets a unix timestamp allowing you to specify when you want your email
    //     to be sent from Twilio SendGrid. This is not necessary if you want the email
    //     to be sent at the time of your API request.
    [JsonProperty( PropertyName = "send_at" )]
    public long? SendAt { get; set; }

    //
    // Summary:
    //     Gets or sets the template data object following the pattern "template data key":"template
    //     data value". All are assumed to be strings. These key value pairs will apply
    //     to the content of your template email, in addition to the subject and reply-to
    //     parameters.
    [JsonProperty( PropertyName = "dynamic_template_data" , IsReference = false , ItemIsReference = false )]
    public object? TemplateData { get; set; }

    //
    // Summary:
    //     Gets or sets the subject line of your email.
    [JsonProperty( PropertyName = "subject" )]
    public string Subject { get; set; } = string.Empty;
}
