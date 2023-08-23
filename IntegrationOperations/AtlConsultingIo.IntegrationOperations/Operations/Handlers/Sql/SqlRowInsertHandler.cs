
using Dapper;
using FluentValidation;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Data;


namespace AtlConsultingIo.IntegrationOperations;
internal class SqlRowInsertHandler : IIntegrationCommand<InsertSqlRow>
{
    private readonly IValidator<InsertSqlRow> _validator;
    public SqlRowInsertHandler( IValidator<InsertSqlRow> validator )
    {
        _validator = validator;
    }

    public async Task Execute(
        InsertSqlRow request ,
        IntegratedClientSettings clientConfiguration ,
        ILogger logger ,
        CancellationToken cancellationToken )
    {
        logger.OperationStartTrace( 
                request.Key, 
                request.ContextID, 
                typeof(SqlRowInsertHandler)
            );    

        _validator.ValidateAndThrow( request );
        SqlClientConfiguration options = clientConfiguration.AsSqlOptions;

        var @params = SqlRowDataMapper.ToCommandParams( request.RowData, request.PrimaryKeyColumn );
        var columns = string.Join(',', @params.Select( x => x.Key));
        var values =  string.Join( ',' , @params.Select( x => $"@{x.Key}" ) ) ;

        string sql = $@"
            INSERT {request.TableName.Value} ( { columns } )
            VALUES ( { values } )
        ";

        using var cn = new SqlConnection( options.SqlConnectionString );
        await cn.OpenAsync( cancellationToken );

        CommandDefinition cmd = new (
                commandText: sql ,
                parameters: @params ,
                commandTimeout: options.CommandTimeout ,
                commandType: CommandType.Text ,
                cancellationToken: cancellationToken
            );

        _ = await cn.ExecuteAsync( cmd ).ConfigureAwait( false );

        logger.OperationEndTrace( 
                request.Key, 
                request.ContextID, 
                typeof(SqlRowInsertHandler)
            );        
    }

}
