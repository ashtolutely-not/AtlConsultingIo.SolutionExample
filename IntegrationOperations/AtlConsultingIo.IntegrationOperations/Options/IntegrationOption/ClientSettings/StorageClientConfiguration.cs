namespace AtlConsultingIo.IntegrationOperations;

public sealed record StorageClientConfiguration 
{
    public StorageAccountConnection ServiceConnectionString { get; set; } 
    public static readonly StorageClientConfiguration Default = new ();

    public StorageClientConfiguration()
    {
        
    }

    public StorageClientConfiguration( StorageAccountConnection connection )
    {
        ServiceConnectionString = connection;
    }
}
