using System.Data;

namespace AtlConsultingIo.IntegrationOperations;

public record FindSqlRow: IntegrationRequest<FindSqlRow>

{
    public FindSqlRow()
    {
    }

    public FindSqlRow( IntegrationRequest<FindSqlRow> original ) : base( original )
    {
    }

    public SqlTableName TableName { get; init; }
    public SqlRowID RowId { get; init; } = SqlRowID.Default;
    public SqlPrimaryKeyColumn PrimaryKeyColumn { get; init; }
    public List<string>? SelectFields { get; init; }
    public Func<IDataRecord,Task<object>>? Convert { get; init; }
}
