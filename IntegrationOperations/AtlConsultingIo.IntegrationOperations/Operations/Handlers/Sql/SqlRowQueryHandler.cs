using System.Data;

using Dapper;

using FluentValidation;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace AtlConsultingIo.IntegrationOperations;
public class SqlRowQueryHandler : IIntegrationQuery<FindSqlRow>
{
    private readonly IValidator<FindSqlRow> _validator;
    public SqlRowQueryHandler( IValidator<FindSqlRow> validator )
    {
        _validator = validator;
    }

    public async Task<QuerySuccess<TResult>> Execute<TResult>(
        FindSqlRow request ,
        IntegratedClientSettings clientConfiguration ,
        ILogger logger ,
        CancellationToken cancellationToken ) where TResult : class, new()
    {

        logger.OperationStartTrace( 
                request.Key, 
                request.ContextID, 
                typeof( SqlRowQueryHandler )
            );  

        _validator.ValidateAndThrow( request );
        SqlClientConfiguration options = clientConfiguration.AsSqlOptions;

        using var cn = new SqlConnection( options.SqlConnectionString );
        await cn.OpenAsync( cancellationToken );

        string select = request.SelectFields.HasItems() ? string.Join( ",", request.SelectFields!) : "*";
        string sql = string.Format(
                SqlTemplate,
                select,
                (string) request.TableName,
                (string) request.PrimaryKeyColumn,
                 request.RowId.SqlString
            );

        TResult? result = request.Convert is not null
                            ? await CustomExecution<TResult>( cn, sql, options.RowQueryTimeout, request.Convert, cancellationToken )
                            : await DefaultExecution<TResult>( cn, sql, options.RowQueryTimeout);

        logger.OperationEndTrace( 
                request.Key, 
                request.ContextID, 
                typeof( SqlRowQueryHandler )
            );    

        return result is not null ? result : NotFoundResult.Instance;
    }

    private static async Task<TResult?> DefaultExecution<TResult>(
        SqlConnection openConnection ,
        string sql ,
        int timeout  ) where TResult : class, new()
    {
        return await openConnection.QuerySingleAsync<TResult>(
                    sql ,
                    commandTimeout: timeout ,
                    commandType: System.Data.CommandType.Text
                );
    }
    private static async Task<TResult?> CustomExecution<TResult>( SqlConnection openConnection , string sql , int timeout , Func<IDataRecord , Task<object>> convert, CancellationToken cancellationToken ) where TResult : class, new()
    {
        SqlCommand cmd = new SqlCommand( sql, openConnection );
        cmd.CommandTimeout = timeout;
        cmd.CommandType = System.Data.CommandType.Text;

        SqlDataReader reader = await cmd.ExecuteReaderAsync(cancellationToken);
        if( !reader.HasRows ) 
            return null;

        TResult? result = null;
        while( await reader.ReadAsync(cancellationToken) )
        {
            object res = await convert( reader );
            if( res is TResult )
                result = (TResult)res;
        }

        return result;
    }

    const string SqlTemplate = @"
        SELECT {columns}
        FROM {tableName}
        WHERE {idColumn} = {rowId}
    ";
}
