using AtlConsultingIo.IntegrationOperations;

using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations.Exigo;



namespace CompanyName.Operations.Account;

public record UserPointAccountAggregateQuery
{
    public List<UserPointAccountRestQuery> ApiQueries;
    public UserPointAccountAggregateQuery( CustomerID customerID , IEnumerable<PointAccountID> pointAccountIDs )
    {
        ApiQueries = new( pointAccountIDs.Count() );
        foreach ( var pointAccountID in pointAccountIDs )
            ApiQueries.Add( new UserPointAccountRestQuery(  customerID , pointAccountID  ) );

    }

    public static Func<UserPointAccountAggregateQuery, IIntegrationsService, CancellationToken, Task<List<UserPointAccount>>> Execute = async ( aggregateQuery, service, token ) =>
    {
        Task<UserPointAccount?>[] tasks = new Task<UserPointAccount?>[ aggregateQuery.ApiQueries.Count ];
        for ( int i = 0 ; i < aggregateQuery.ApiQueries.Count ; i++ )
            tasks[i] = UserPointAccountRestQuery.Execute( aggregateQuery.ApiQueries[i], service, token );

        var results = await Task.WhenAll( tasks.ToList() );
        List<UserPointAccount> accounts = new();
        foreach (var acct in results)
            if( acct is not null )
                accounts.Add( acct );

        return accounts;
    };


}
