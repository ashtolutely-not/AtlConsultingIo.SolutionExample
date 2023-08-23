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
using AtlConsultingIo.IntegrationOperations;

using Microsoft.Extensions.Caching.Distributed;

using Newtonsoft.Json.Linq;


using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
