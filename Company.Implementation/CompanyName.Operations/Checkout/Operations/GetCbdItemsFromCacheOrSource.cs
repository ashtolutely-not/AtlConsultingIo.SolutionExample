using AtlConsultingIo.IntegrationOperations;

using CompanyName.Core.Entities.Product;
using CompanyName.Operations.Product;

using Microsoft.Extensions.Caching.Distributed;

namespace CompanyName.Operations.Checkout;

public record GetCbdItemsFromCacheOrSource : ICheckoutOperation<GetCbdItemsFromCacheOrSource,List<CbdItemCode>>
{
    public const string CacheKey = $"CheckoutCache_{nameof(CbdItemCode)}s";

    private readonly CheckoutCacheOptions _cacheOptions;
    private readonly IIntegrationsService _integrations;
    private readonly IDistributedCache _cache;

    public string? OperationError { get; init; }
    public List<CbdItemCode>? Result { get; init; }

    public GetCbdItemsFromCacheOrSource( IIntegrationsService integrations , IDistributedCache cache , CheckoutCacheOptions cacheOptions )
    {
        _cacheOptions = cacheOptions;
        _integrations = integrations;
        _cache = cache;
    }

    public async Task<GetCbdItemsFromCacheOrSource> ExecuteAsync(CancellationToken cancellationToken )
    {
        if ( _cacheOptions.ProductQueryCacheEnabled )
        {
            var cacheEntry = _cache.Get( CacheKey );
            if ( cacheEntry is not null && cacheEntry.GetCachedJson<List<CbdItemCode>> ( ) is List<CbdItemCode> _items )
                return this with { Result = _items };
        }

        var sourceQuery = new CbdItemSearch();
        List<CbdItemCode> items = await CbdItemSearch.Execute( sourceQuery, _integrations, cancellationToken );
        if( sourceQuery.OperationError.HasValue() )
            return this with { OperationError = sourceQuery.OperationError };

        if ( items.Count > 0 && _cacheOptions.ProductQueryCacheEnabled )
            _cache.Set (
                    CacheKey ,
                    items.CreateJsonCache ( ).ToArray ( ) ,
            new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes ( _cacheOptions.ProductCacheExpirationInMinutes )
                    }
                );

        return this with { Result =  items };
    }


}
