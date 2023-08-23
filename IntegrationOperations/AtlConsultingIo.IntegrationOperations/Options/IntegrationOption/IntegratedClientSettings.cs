using Azure.Storage.Blobs;

using OneOf;

namespace AtlConsultingIo.IntegrationOperations;

public class IntegratedClientSettings : OneOfBase<SqlClientConfiguration , StorageClientConfiguration , RestClientConfiguration>
{
    protected IntegratedClientSettings( OneOf<SqlClientConfiguration , StorageClientConfiguration , RestClientConfiguration> _ ) : base( _ )
    {
    }

    public IntegratedClientSettings()
        : base( OneOf<SqlClientConfiguration , StorageClientConfiguration , RestClientConfiguration>.FromT0( SqlClientConfiguration.Default ) )
    {
        
    }

    public IntegrationType IntegratedClientType => Match(
            sql => IntegrationType.SqlDatabase,
            az => IntegrationType.AzureStorage,
            rest => IntegrationType.RestClient
        );


    public static implicit operator IntegratedClientSettings( SqlClientConfiguration _ ) => new( _ );
    public static implicit operator IntegratedClientSettings( StorageClientConfiguration _ ) => new( _ );
    public static implicit operator IntegratedClientSettings( RestClientConfiguration _ ) => new( _ );

    public static explicit operator SqlClientConfiguration?( IntegratedClientSettings _ ) => _.IsSqlConfiguration ? _.AsSqlOptions : null;
    public static explicit operator StorageClientConfiguration?( IntegratedClientSettings _ ) => _.IsStorageConfiguration ? _.AsStorageOptions : null;
    public static explicit operator RestClientConfiguration?( IntegratedClientSettings _ ) => _.IsRestConfiguration ? _.AsRestOptions : null;

    public bool IsSqlConfiguration => IsT0;
    public bool IsStorageConfiguration => IsT1;
    public bool IsRestConfiguration => IsT2;
    public SqlClientConfiguration AsSqlOptions => IsSqlConfiguration ? AsT0 : new SqlClientConfiguration();
    public StorageClientConfiguration AsStorageOptions => IsStorageConfiguration ? AsT1 : new StorageClientConfiguration();
    public RestClientConfiguration AsRestOptions => IsRestConfiguration ? AsT2 : new RestClientConfiguration();

    public static InvalidCastException InvalidCastException<TClientOptions>()
        => new ( $"The underlying type held in the {nameof( IntegratedClientSettings )} instance does not match the expected type of {typeof( TClientOptions ).Name} " );

    public static readonly IntegratedClientSettings Default = new( OneOf<SqlClientConfiguration , StorageClientConfiguration , RestClientConfiguration>.FromT1( StorageClientConfiguration.Default ) );
}
