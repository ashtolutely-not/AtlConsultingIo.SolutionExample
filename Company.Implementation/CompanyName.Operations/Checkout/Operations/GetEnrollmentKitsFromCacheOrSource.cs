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
