using Dapper;
using FluentValidation;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Data;

namespace AtlConsultingIo.IntegrationOperations;
internal class SqlRowUpdateHandler : IIntegrationCommand<UpdateSqlRow>
{
    private readonly IValidator<UpdateSqlRow> _validator;
    public SqlRowUpdateHandler( IValidator<UpdateSqlRow> validator )
    {
        _validator = validator;
    }

    public async Task Execute(
        UpdateSqlRow request ,
        IntegratedClientSettings clientConfiguration ,
        ILogger logger ,
        CancellationToken cancellationToken )
    {
        logger.OperationStartTrace(
                request.Key ,
                request.ContextID ,
                typeof( SqlRowUpdateHandler )
            );

        _validator.ValidateAndThrow( request );
        SqlClientConfiguration options = clientConfiguration.AsSqlOptions;

        using var cn = new SqlConnection( options.SqlConnectionString );
        await cn.OpenAsync( cancellationToken );

        var sqlParams = SqlRowDataMapper.ToCommandParams( request.RowData, request.PrimaryKeyColumn );
        string sql = $@"
                UPDATE { request.TableName.Value } 
                SET { string.Join(',',sqlParams.Select( x => EqualsStatement(x.Key))) }
                WHERE { request.PrimaryKeyColumn.Value } = { request.RowId.SqlString }
            ";

        CommandDefinition cmd = new (
                commandText: sql ,
                parameters: sqlParams ,
                commandTimeout: options.CommandTimeout ,
                commandType: CommandType.Text ,
                cancellationToken: cancellationToken
            );

        _ = await cn.ExecuteAsync( cmd ).ConfigureAwait( false );

        logger.OperationEndTrace(
                request.Key ,
                request.ContextID ,
                typeof( SqlRowUpdateHandler )
            );
    }
    static string EqualsStatement( string paramName ) => $"{paramName} = @{paramName}";
}
