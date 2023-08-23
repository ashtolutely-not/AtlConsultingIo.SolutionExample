using Azure;
using Azure.Data.Tables;

using FluentValidation;

using Microsoft.Extensions.Logging;

namespace AtlConsultingIo.IntegrationOperations;
public class TableDocumentSearchHandler : IIntegrationQuery<SearchTableDocuments>
{
    private readonly IStorageClientFactory _factory;
    private IValidator<SearchTableDocuments> _validator;
    public TableDocumentSearchHandler( IStorageClientFactory clientFactory , IValidator<SearchTableDocuments> validator )
    {
        _factory = clientFactory;
        _validator = validator;
    }

    public async Task<QuerySuccess<TResult>> Execute<TResult>(
        SearchTableDocuments request ,
        IntegratedClientSettings clientConfiguration ,
        ILogger logger ,
        CancellationToken cancellationToken ) where TResult : class, new()
    {
        logger.OperationStartTrace(
                request.Key ,
                request.ContextID ,
                typeof( TableDocumentSearchHandler )
            );

        _validator.ValidateAndThrow( request );
        StorageClientConfiguration options = clientConfiguration.AsStorageOptions;
        StorageClientRequest clientReq = new(
                request.Key,
                StorageServiceType.StorageTable,
                request.TableName,
                options.ServiceConnectionString
            );

        StorageResourceClient resourceClient = await _factory.CreateResourceClientAsync( clientReq, cancellationToken ).ConfigureAwait(false);
        if( (TableClient?)resourceClient is not TableClient _table )
            throw StorageResourceClient.InvalidCastException<TableClient>();


        AsyncPageable<TableEntity> res = _table.QueryAsync<TableEntity>(
                    BuildODataFilter( request.FilterConditions ),
                    null,
                    request.SelectFields.HasItems() ? request.SelectFields : null,
                    cancellationToken
                );
        
        QuerySuccess < TResult > result 
            = !await res.AnyAsync() 
                ? NotFoundResult.Instance 
                : GetResults<TResult>( request, await res.ToListAsync());

        logger.OperationEndTrace(
                request.Key ,
                request.ContextID ,
                typeof( TableDocumentSearchHandler )
            );

        return result;
    }



    private static  List<TResult> GetResults<TResult>( SearchTableDocuments request, List<TableEntity> entities ) where TResult : class,new()
        => request.Convert is null ? TableEntityMapper.MapResults<TResult>( entities ) : TableEntityMapper.MapResults<TResult>( entities, request.Convert );

    static string BuildODataFilter( Dictionary<string , object> filters )
    {
        if ( !filters.HasItems() )
            return String.Empty;

        List<string> expressions = new(filters.Count);
        foreach ( var (key, value) in filters )
            expressions.Add( FilterString( key , GetValueString( value ) ) );

        return string.Join( " and " , expressions );
    }
    static string GetValueString( object value )
        => value switch
        {
            null => "null",
            bool _bool => _bool.ToString().ToLower(),
            string _str => _str.WithSingleQuotes(),
            _ => value.ToString().EmptyIfNull()
        };
    static string FilterString( string queryStringKey , string queryStringValue )
        => string.Format( "{key} eq {value}" , queryStringKey , queryStringValue );


}
