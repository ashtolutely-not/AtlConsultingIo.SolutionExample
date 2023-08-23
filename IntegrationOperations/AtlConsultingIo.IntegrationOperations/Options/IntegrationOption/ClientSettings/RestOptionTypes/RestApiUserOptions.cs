
namespace AtlConsultingIo.IntegrationOperations;

public record ApiUserOptions
{
    public bool IsEmpty => Equals(Empty);
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;


    public static readonly ApiUserOptions Empty = new();
}
