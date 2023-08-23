using Dapper;

using FluentValidation;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
namespace AtlConsultingIo.IntegrationOperations;
internal class SqlRowDeleteHandler : IIntegrationCommand<DeleteSqlRow>
{
    private readonly IValidator<DeleteSqlRow> _validator;
    public SqlRowDeleteHandler( IValidator<DeleteSqlRow> validator )
    {

        _validator = validator;
    }

    public async Task Execute(
        DeleteSqlRow request ,
        IntegratedClientSettings clientConfiguration ,
        ILogger logger ,
        CancellationToken cancellationToken )
    {
        logger.OperationStartTrace(
                request.Key ,
                request.ContextID ,
                typeof( SqlRowDeleteHandler )
            );

        _validator.ValidateAndThrow( request );
        SqlClientConfiguration options = clientConfiguration.AsSqlOptions;

        var sql = $@"
            DELETE { request.TableName.Value }
            WHERE { request.PrimaryKeyColumn.Value } = { request.RowId.SqlString }
        ";

        using var cn = new SqlConnection( options.SqlConnectionString );
        await cn.OpenAsync( cancellationToken );

        _ = await cn.ExecuteAsync(
                sql ,
                commandTimeout: options.CommandTimeout ,
                commandType: System.Data.CommandType.Text
            ).ConfigureAwait( false );

        logger.OperationEndTrace(
                request.Key ,
                request.ContextID ,
                typeof( SqlRowDeleteHandler )
            );
    }

}
