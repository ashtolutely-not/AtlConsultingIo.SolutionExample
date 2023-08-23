namespace AtlConsultingIo.IntegrationOperations;

public interface IResourceID : IEquatable<string> 
{
    string Value { get; }
}
