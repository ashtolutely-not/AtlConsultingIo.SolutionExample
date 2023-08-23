using CompanyName.Operations;
using CompanyName.Operations.Account;
using CompanyName.Operations.Checkout;
using CompanyName.Operations.Messaging;
using CompanyName.Operations.Order;
using CompanyName.Operations.Product;
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

using Newtonsoft.Json;

using FluentValidation;

internal static class CheckoutExtensions
{
    public static TResult? GetRootContextValue<TContext,TResult>( this ValidationContext<TContext> validationContext , string key ) where TResult : class
    {
        if( validationContext.RootContextData.TryGetValue( key, out var obj ))
            if( obj is TResult )
                return (TResult)obj;
        return null;
    }
    public static T? GetCachedJson<T>( this byte[] cacheEntry )
    {
        var binary = new BinaryData( cacheEntry );
        var jsonString = binary.ToString();
        return JsonConvert.DeserializeObject<T>( jsonString );
    }
    public static BinaryData CreateJsonCache<T>( this T instance ) where T : class
    {
        var data = JsonConvert.SerializeObject( instance );
        return new BinaryData( data );
    }
    public static string ToUSD( this decimal? value )
    {
        value = Math.Round ( value ?? 0, 2 , MidpointRounding.AwayFromZero );
        return String.Format ( "en-US" , "{0:C}" , value );
    }
    public static string ToUSD( this decimal value )
    {
        value = Math.Round ( value  , 2 , MidpointRounding.AwayFromZero );
        return String.Format ( "en-US" , "{0:C}" , value );
    }
    public static CheckoutRequest WithGuestCustomer( this CheckoutRequest request , GuestAccountSearchParams searchParams , GuestAccountMatch searchResult )
    {
        if ( !searchResult.GuestCustomerID.HasValue )
            return WithGuestRegistration ( request , searchParams , searchResult.SiteOwnerID );

        return request with
        {
            CartOrder = request.CartOrder with
            {
                CustomerID = searchResult.GuestCustomerID.Value ,
                VolumeOwnerId = searchResult.SiteOwnerID.HasValue ? searchResult.SiteOwnerID : ExigoConfiguration.CheckoutSettings.Instance.Defaults.EnrollerID ,
            }
        };
    }
    public static CheckoutRequest WithGuestRegistration( this CheckoutRequest request , GuestAccountSearchParams searchParams , CustomerID? enrollerId )
    {
        return request with
        {
            AccountRegistration = new AccountRegistration
            {
                FirstName = "Guest" ,
                LastName = "Customer" ,
                Email = searchParams.EmailAddress ,
                Phone = searchParams.PhoneNumber.CleanValue ,
                EnrollerID = enrollerId?.Value ?? ExigoConfiguration.CheckoutSettings.Instance.Defaults.EnrollerID ,
                CustomerType = GuestAccount.Instance.TypeId ,
                CustomerStatus = ExigoConfiguration.CheckoutSettings.Instance.Defaults.AccountStatus ,
                DefaultWarehouseID = ExigoConfiguration.CheckoutSettings.Instance.Defaults.WarehouseID ,
                LanguageID = ExigoConfiguration.CheckoutSettings.Instance.Defaults.LanguageID ,
                EntryDate = CstDateTime.Now
            } ,
            CartOrder = request.CartOrder with
            {
                VolumeOwnerId = enrollerId ?? ExigoConfiguration.CheckoutSettings.Instance.Defaults.EnrollerID
            }
        };
    }
}
