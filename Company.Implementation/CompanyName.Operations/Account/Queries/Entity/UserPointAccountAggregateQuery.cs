using CompanyName.Operations;
using CompanyName.Operations.Account;
using CompanyName.Operations.Checkout;
using CompanyName.Operations.Messaging;
using CompanyName.Operations.Order;
using CompanyName.Operations.Product;
using CompanyName.Core;
using CompanyName.Core.Entities;
using CompanyName.Core.Entities.Events;
using CompanyName.Core.Entities.Messaging;
using CompanyName.Core.Entities.Order;
using CompanyName.Core.Entities.Product;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;
using CompanyName.Core.Integrations.Exigo.Sql;
using CompanyName.Core.Integrations.KountApi;
using CompanyName.Core.Integrations.SendGridApi;
using AtlConsultingIo.IntegrationOperations;



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
