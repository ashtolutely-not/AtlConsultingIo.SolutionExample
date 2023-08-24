namespace CompanyName.Core.Integrations.SendGridApi;
public record DeliverySetting
{
    [JsonProperty( PropertyName = "bcc" )]
    public BCCSetting BccSettings { get; init; }

    [JsonProperty( PropertyName = "bypass_list_management" )]
    public SGEnabled BypassListManagement { get; init; }

    [JsonProperty( PropertyName = "bypass_spam_management" )]
    public SGEnabled BypassSpamManagement { get; init; }

    [JsonProperty( PropertyName = "bypass_bounce_management" )]
    public SGEnabled BypassBounceManagement { get; init; }

    [JsonProperty( PropertyName = "bypass_unsubscribe_management" )]
    public SGEnabled BypassUnsubscribeManagement { get; init; }

    [JsonProperty( PropertyName = "sandbox_mode" )]
    public SGEnabled SandboxMode { get; init; }

    [JsonProperty( PropertyName = "footer" )]
    public FooterSetting FooterSettings { get; init; }

    [JsonProperty( PropertyName = "spam_check" )]
    public SpamCheckSetting SpamCheckSetting { get; init; }
}

public record TrackingSetting
{
    [JsonProperty( PropertyName = "click_tracking" )]
    public ClickTrackingSetting ClickTracking { get; set; }

    [JsonProperty( PropertyName = "ganalytics" )]
    public GoogleAnalyticsSetting GoogleAnalytics { get; set; }

    [JsonProperty( PropertyName = "open_tracking" )]
    public OpenTrackingSetting OpenTracking { get; set; }

    [JsonProperty( PropertyName = "subscription_tracking" )]
    public SubscriptionTrackingSetting SubscriptionTracking { get; set; }
}

public record struct BCCSetting(
        [JsonProperty( PropertyName = "enable" )] bool? Enable ,
        [JsonProperty( PropertyName = "email" )] string Email
    );

public record struct FooterSetting(
        [JsonProperty( PropertyName = "enable" )] bool Enable ,
        [JsonProperty( PropertyName = "text" )] string? Text ,
        [JsonProperty( PropertyName = "html" )] string? Html
    );

public record struct SpamCheckSetting(
        [JsonProperty( PropertyName = "enable" )] bool Enable ,
        [JsonProperty( PropertyName = "threshold" )] int? Threshold ,
        [JsonProperty( PropertyName = "post_to_url" )] string PostToUrl
    );

public record struct ClickTrackingSetting(
        [JsonProperty( PropertyName = "enable" )] bool Enable ,
        [JsonProperty( PropertyName = "enable_text" )] bool? EnableText
    );

public record struct OpenTrackingSetting(
        [JsonProperty( PropertyName = "enable" )] bool Enable ,
        [JsonProperty( PropertyName = "substitution_tag" )] string SubstitutionTag
    );

public record struct SubscriptionTrackingSetting(
        [JsonProperty( PropertyName = "enable" )] bool Enable ,
        [JsonProperty( PropertyName = "text" )] string? Text ,
        [JsonProperty( PropertyName = "html" )] string? Html ,
        [JsonProperty( PropertyName = "substitution_tag" )] string SubstitutionTag
    );

public record struct GoogleAnalyticsSetting(
        [JsonProperty( PropertyName = "enable" )] bool Enable ,
        [JsonProperty( PropertyName = "utm_source" )] string UtmSource ,
        [JsonProperty( PropertyName = "utm_medium" )] string UtmMedium ,
        [JsonProperty( PropertyName = "utm_term" )] string UtmTerm ,
        [JsonProperty( PropertyName = "utm_content" )] string UtmContent ,
        [JsonProperty( PropertyName = "utm_campaign" )] string UtmCampaign
    );

public record struct UnsubscribeSetting(
        [JsonProperty( PropertyName = "group_id" )] int GroupId ,
        [JsonProperty( PropertyName = "groups_to_display" , IsReference = false )] List<int>? GroupsToDisplay
    );
