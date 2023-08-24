using System.Data;

using Dapper;

namespace AtlConsultingIo.IntegrationOperations;

public record SearchSqlEntities : IntegrationRequest<SearchSqlEntities>

{
    public SearchSqlEntities()
    {
    }

    public SearchSqlEntities( IntegrationRequest<SearchSqlEntities> original ) : base( original )
    {
    }

    public SqlStoredProcedure SearchProcedure { get; init; }
    public DynamicParameters Params { get; init; } = new();
    public Func<IDataRecord,Task<object>>? Convert { get; init; }

}
