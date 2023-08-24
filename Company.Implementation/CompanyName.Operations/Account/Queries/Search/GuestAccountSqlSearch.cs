using AtlConsultingIo.IntegrationOperations;

using CompanyName.Core;
using CompanyName.Core.Integrations.Exigo;


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
