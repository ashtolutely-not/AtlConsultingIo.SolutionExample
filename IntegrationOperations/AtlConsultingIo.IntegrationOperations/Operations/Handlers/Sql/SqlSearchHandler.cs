using Azure.Core;

using Dapper;

using FluentValidation;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

using System.Data;
using System.Threading;

namespace AtlConsultingIo.IntegrationOperations;
public class SqlSearchHandler: IIntegrationQuery<SearchSqlEntities>
{
    private readonly IValidator<SearchSqlEntities> _validator;
    public SqlSearchHandler( IValidator<SearchSqlEntities> validator )
    {
        _validator = validator;
    }
    public async Task<QuerySuccess<TResult>> Execute<TResult>(
        SearchSqlEntities request ,
        IntegratedClientSettings clientConfiguration ,
        ILogger logger ,
        CancellationToken cancellationToken ) where TResult : class, new()
    {
        logger.OperationStartTrace(
                request.Key ,
                request.ContextID ,
                typeof( SqlSearchHandler )
            );

        _validator.ValidateAndThrow( request );
        SqlClientConfiguration options = clientConfiguration.AsSqlOptions;

        return request.Convert is null 
            ? await DefaultExecution<TResult>( request, options, cancellationToken )
            : await CustomExecution<TResult>( request, options, request.Convert, cancellationToken );
    }
     
    private static async Task<QuerySuccess<TResult>> DefaultExecution<TResult>(
        SearchSqlEntities searchReq ,
        SqlClientConfiguration clientConfig ,
        CancellationToken cancellationToken ) where TResult : class, new()
    {
        using var cn = new SqlConnection( clientConfig.SqlConnectionString );
        await cn.OpenAsync( cancellationToken );

        IEnumerable<TResult> results = await cn.QueryAsync<TResult>(
                searchReq.SearchProcedure, 
                searchReq.Params, 
                null, 
                clientConfig.SearchQueryTimeout, 
                CommandType.StoredProcedure
            );

        return results.HasItems() ? results.ToList() : NotFoundResult.Instance;
    }
    private static async Task<QuerySuccess<TResult>> CustomExecution<TResult>(
        SearchSqlEntities searchReq ,
        SqlClientConfiguration clientConfig ,
        Func<IDataRecord , Task<object>> convert ,
        CancellationToken cancellationToken ) where TResult : class, new()
    {
        using var cn = new SqlConnection( clientConfig.SqlConnectionString );
        await cn.OpenAsync( cancellationToken );

        SqlCommand cmd = new SqlCommand( searchReq.SearchProcedure , cn );
        foreach( var param in searchReq.Params.ParameterNames )
            cmd.Parameters.Add( new SqlParameter( param, searchReq.Params.Get<object>( param )));

        cmd.CommandTimeout = clientConfig.SearchQueryTimeout;
        cmd.CommandType = System.Data.CommandType.StoredProcedure;

        SqlDataReader reader = await cmd.ExecuteReaderAsync( cancellationToken );
        if( !reader.HasRows )
            return NotFoundResult.Instance;

        var results = new List<TResult>();
        while( await reader.ReadAsync(cancellationToken) )
        {
            object result = await convert( reader );
            if( result is TResult )
                results.Add( (TResult)result );
        }

        return results;
    }
}
