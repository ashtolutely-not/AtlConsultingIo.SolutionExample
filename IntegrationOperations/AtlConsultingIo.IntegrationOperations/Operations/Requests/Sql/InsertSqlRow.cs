namespace AtlConsultingIo.IntegrationOperations;

public record InsertSqlRow : IntegrationRequest<InsertSqlRow>
{
    public InsertSqlRow()
    {
    }

    public InsertSqlRow( IntegrationRequest<InsertSqlRow> original ) : base( original )
    {
    }

    public SqlTableName TableName { get; init; }
    public SqlPrimaryKeyColumn PrimaryKeyColumn { get; init; }
    public object RowData { get; init; } = null!;


}
