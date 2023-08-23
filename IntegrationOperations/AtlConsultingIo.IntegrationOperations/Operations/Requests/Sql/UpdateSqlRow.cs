namespace AtlConsultingIo.IntegrationOperations;

public record UpdateSqlRow : IntegrationRequest<UpdateSqlRow>
{
    public UpdateSqlRow()
    {
    }

    public UpdateSqlRow( IntegrationRequest<UpdateSqlRow> original ) : base( original )
    {
    }

    public SqlTableName TableName { get; init; }
    public SqlRowID RowId { get; init; } = SqlRowID.Default;
    public SqlPrimaryKeyColumn PrimaryKeyColumn { get; init; }
    public object RowData { get; init; } = null!;

}
