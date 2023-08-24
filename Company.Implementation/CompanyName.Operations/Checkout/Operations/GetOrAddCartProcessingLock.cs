using Microsoft.Extensions.Caching.Distributed;


namespace CompanyName.Operations.Checkout;
internal record GetOrAddCartProcessingLock : ICheckoutOperation<GetOrAddCartProcessingLock , CartProcessingLock>
{

    public string? OperationError { get; private init; }
    public CartProcessingLock? Result { get; private init; }
    public CartProcessingLock? ExistingLock => Result;

    private readonly IDistributedCache _cache;
    private readonly CheckoutRequest _request;
    private readonly CheckoutCacheOptions _options;
    public GetOrAddCartProcessingLock( CheckoutRequest request , IDistributedCache appCache , CheckoutCacheOptions cacheOptions )
    {
        _cache = appCache;
        _request = request;
        _options = cacheOptions;
    }
    public async Task<GetOrAddCartProcessingLock> ExecuteAsync( CancellationToken cancellationToken )
    {
        var cacheValue = await _cache.GetAsync( CacheKey, cancellationToken );

        if( cacheValue is null )
        {
            await CreateLock();
            return this;
        }

        var existingLock = cacheValue.GetCachedJson<CartProcessingLock>();
        if( existingLock is null )
        {
            await _cache.RemoveAsync( CacheKey );
            await CreateLock();
            return this;
        }

        //maybe it hasn't been evicted yet but it's still stale
        var actualExpiration = existingLock.CreatedOnUtc.AddSeconds( _options.CartProcessingLockTimeToLiveInSeconds );
        if( actualExpiration <= DateTime.UtcNow )
        {
            await _cache.RemoveAsync ( CacheKey );
            await CreateLock ( );
            return this;
        }

        return this with { Result = existingLock };
    }

    async Task CreateLock( )
    {
        CartProcessingLock @lock = CartProcessingLock.Create( _request );
        await _cache.SetAsync ( CacheKey , @lock.CreateJsonCache().ToArray() , EntryOptions );
    }
    DistributedCacheEntryOptions EntryOptions 
        => new DistributedCacheEntryOptions{ AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds( _options.CartProcessingLockTimeToLiveInSeconds ) };
    string CacheKey => _request.CartId.GetHashCode().ToString();
}
