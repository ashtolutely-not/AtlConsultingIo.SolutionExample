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

public record GuestAccountSqlSearch : SearchSqlEntities, IIntegrationOperation
{
    public string? OperationError { get; set; }
    public GuestAccountSqlSearch( GuestAccountSearchParams searchRequest , OperationContextID contextID )
    {
        Key = ExigoReplicatedDbKey.Instance;
        ContextID = contextID;

        SearchProcedure = new("API_SearchGuestAccounts");
        Params = new( new
        {
            PhoneNumber = searchRequest.PhoneNumber.CleanValue.Value,
            EmailAddress = searchRequest.EmailAddress.Value,
            WebAlias = searchRequest.CheckoutSiteAlias.Value
        } );

        Convert = async( record ) =>
        {
            int? customerId = record.IsDBNull(0) ? null : record.GetInt32( 0 );
            int? ownerId = record.IsDBNull(1) ? null : record.GetInt32( 1 );

            return await Task.FromResult( new GuestAccountMatch
            {
                GuestCustomerID = customerId.HasValue && customerId.Value > 0 ? new CustomerID ( customerId.Value ) : null ,
                SiteOwnerID = ownerId.HasValue && ownerId.Value > 0 ? new CustomerID ( ownerId.Value ) : null ,
            } );
        };
    }

    public static Func<GuestAccountSqlSearch, IIntegrationsService, CancellationToken, Task<GuestAccountMatch?>> Execute =
        async( searchRequest, integrations, token ) =>
        {
            var operationResult = await integrations.ExecuteIntegrationQuery<SearchSqlEntities, GuestAccountMatch>( searchRequest, token );

            GuestAccountMatch? result = null;
            operationResult.Switch(
                    success => success.Switch(
                            single => result = single,
                            list => result = list[0],
                            notfound => { }
                        ),
                    err => searchRequest.OperationError = err.Error.Message
                );
            
            return result;
        };
}
