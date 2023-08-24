using AtlConsultingIo.IntegrationOperations;

using CompanyName.Core.Entities.Product;
using CompanyName.Operations.Product;

using Microsoft.Extensions.Caching.Distributed;

namespace CompanyName.Operations.Checkout;

public record GetEnrollmentKitsFromCacheOrSource : ICheckoutOperation<GetEnrollmentKitsFromCacheOrSource,List<EnrollmentKitItemCode>>
{
    private const string CacheKey = $"{nameof(EnrollmentKitItemCode)}_CheckoutCache";
    private readonly IIntegrationsService _integrations;
    private readonly IDistributedCache  _cache;
    private readonly CheckoutCacheOptions _cacheOptions;

    public string? OperationError { get; init; }
    public List<EnrollmentKitItemCode>? Result { get; init; }

    public GetEnrollmentKitsFromCacheOrSource( IIntegrationsService integrations, IDistributedCache cache,  CheckoutCacheOptions cacheOptions )
    {
        _cacheOptions = cacheOptions ?? new();
        _integrations = integrations;
        _cache = cache;
    }


    public async Task<GetEnrollmentKitsFromCacheOrSource> ExecuteAsync( CancellationToken cancellationToken )
    {
        if ( _cacheOptions.ProductQueryCacheEnabled )
        {
            var cacheEntry = _cache!.Get( CacheKey );
            if ( cacheEntry is not null && cacheEntry.GetCachedJson<List<EnrollmentKitItemCode>> ( ) is List<EnrollmentKitItemCode> _items )
                return this with { Result = _items };
        }
        var sourceQuery = new EnrollmentKitItemSearch();
        var items = await EnrollmentKitItemSearch.Execute( sourceQuery, _integrations, cancellationToken );

        if( sourceQuery.OperationError.HasValue() )
            return this with { OperationError = sourceQuery.OperationError };

        if ( items.Count > 0 && _cacheOptions.ProductQueryCacheEnabled )
            _cache!.Set (
                    CacheKey ,
                    items.CreateJsonCache ( ).ToArray ( ) ,
             new DistributedCacheEntryOptions  {AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes ( _cacheOptions.ProductCacheExpirationInMinutes )}
                );

        return this with { Result = items };
    }
}
