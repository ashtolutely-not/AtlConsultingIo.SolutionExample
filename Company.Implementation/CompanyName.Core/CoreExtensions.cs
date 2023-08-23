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
using System.Reflection;
using System.Runtime.Serialization;

using Microsoft.Extensions.DependencyInjection;


public static class TotalLifeCoreExtensions
{
    public static async Task<T> ConvertAndThrow<T>( this HttpResponseMessage response )
        where T : class
    {
        var result = JsonConvert.DeserializeObject<T>( await response.Content.ReadAsStringAsync() );
        if ( result is null )
            throw new JsonSerializationException( $"Could not convert HttpResponseMessage to instance of {typeof( T ).Name}" );
        return result;
    }
    public static bool CaseInsensitiveEquals( this string value , string? other )
        => other is not null && value.Equals( other , StringComparison.OrdinalIgnoreCase );
    public static string EmptyIfNull( this string? value )
        => value.HasValue() ? value! : String.Empty;
    public static string? DisplayName<T>( this T instance ) where T : Enum
    {
        var type = instance.GetType();
        var name = Enum.GetName(typeof(T), instance);
        if ( string.IsNullOrWhiteSpace(name) )
            return null;

        var attr = type.GetField(name!)?.GetCustomAttribute<EnumMemberAttribute>();
        return attr?.Value;
    }

    public static bool HasValue(this string? input ) => !string.IsNullOrWhiteSpace(input?.Trim());
    public static AccountCreditCardType AsCreditCardAccountType( this PaymentProfileType profileType )
        => (AccountCreditCardType) ( (int) profileType );
    public static AccountWalletType AsWalletType( this PaymentProfileType profileType )
        => (AccountWalletType) ( (int) profileType );

    public static bool Has2xxStatus( this HttpResponseMessage responseMessage )
    {
        int status = (int)responseMessage.StatusCode;
        return status >= 200 && status < 300;
    }



    public static IServiceCollection AddDomainMappings( this IServiceCollection services )
        => services.AddAutoMapper ( typeof ( ExigoEntityMapper ) );
}
