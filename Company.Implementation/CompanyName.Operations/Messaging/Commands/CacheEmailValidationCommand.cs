using CompanyName.Core.Integrations.SendGridApi;

using Microsoft.Extensions.Caching.Distributed;


namespace CompanyName.Operations.Messaging;

public record CacheEmailValidationCommand 
{
    private readonly SGEmailValidationResult ValidationResult;
    private readonly TimeSpan RelativeExpiration;
    public CacheEmailValidationCommand( SGEmailValidationResult result , AccountOperationOptions options )
    {
        ValidationResult = result;
        RelativeExpiration = options.ValidationResultOptions?.SendGridResultCacheExpirationInSeconds is int _seconds
                ? TimeSpan.FromSeconds ( _seconds )
                    : options.ValidationResultOptions?.SendGridResultCacheExpirationInMinutes is int _minutes
                        ? TimeSpan.FromMinutes ( _minutes )
                        : TimeSpan.FromHours ( 24 );
    }

    public static Action<CacheEmailValidationCommand,IDistributedCache> Execute = ( operation, cache ) =>
    {
        string cacheKey = operation.ValidationResult.GetHashCode().ToString();
        cache.Set(
                key: cacheKey, 
                value: new BinaryData( operation.ValidationResult).ToArray() , 
                options: new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = operation.RelativeExpiration }
            );
    };

}
