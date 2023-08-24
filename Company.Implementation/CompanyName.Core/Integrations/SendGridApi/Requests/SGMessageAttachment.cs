namespace CompanyName.Core.Integrations.SendGridApi;
public record struct SGMessageAttachment
{
    //
    // Summary:
    //     Gets or sets the Base64 encoded content of the attachment.
    [JsonProperty( PropertyName = "content" )]
    public string Content { get; set; }

    //
    // Summary:
    //     Gets or sets the mime type of the content you are attaching. For example, application/pdf
    //     or image/jpeg.
    [JsonProperty( PropertyName = "type" )]
    public string Type { get; set; }

    //
    // Summary:
    //     Gets or sets the filename of the attachment.
    [JsonProperty( PropertyName = "filename" )]
    public string Filename { get; set; }

    //
    // Summary:
    //     Gets or sets the content-disposition of the attachment specifying how you would
    //     like the attachment to be displayed. For example, "inline" results in the attached
    //     file being displayed automatically within the message while "attachment" results
    //     in the attached file requiring some action to be taken before it is displayed
    //     (e.g. opening or downloading the file). Defaults to "attachment". Can be either
    //     "attachment" or "inline".
    [JsonProperty( PropertyName = "disposition" )]
    public string Disposition { get; set; }

    //
    // Summary:
    //     Gets or sets a unique id that you specify for the attachment. This is used when
    //     the disposition is set to "inline" and the attachment is an image, allowing the
    //     file to be displayed within the body of your email. Ex: .
    [JsonProperty( PropertyName = "content_id" )]
    public string ContentId { get; set; }
}
