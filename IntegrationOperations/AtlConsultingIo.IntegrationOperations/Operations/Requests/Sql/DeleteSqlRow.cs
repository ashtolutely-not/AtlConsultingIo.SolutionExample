namespace AtlConsultingIo.IntegrationOperations;

public record DeleteSqlRow : IntegrationRequest<DeleteSqlRow>
{
    public DeleteSqlRow()
    {
    }

    public DeleteSqlRow( IntegrationRequest<DeleteSqlRow> original ) : base( original )
    {
    }

    public SqlTableName TableName { get; init; }
    public SqlRowID RowId { get; init; } = SqlRowID.Default;
    public SqlPrimaryKeyColumn PrimaryKeyColumn { get; init; }


}
