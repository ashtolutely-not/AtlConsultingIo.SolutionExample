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
namespace CompanyName.Core.Integrations.Exigo;

public record struct ExigoReplicatedDbKey : IEquatable<IntegrationKey>, IEquatable<string>
{
    private readonly string Key;

    public ExigoReplicatedDbKey( )
    {
        Key = "CompanyOnPremSqlDatabase";
    }
    public bool Equals( string? other ) => !string.IsNullOrEmpty ( other ) && Key.ToLower ( ).Equals ( other.ToLower ( ) );

    public bool Equals( IntegrationKey other ) => !string.IsNullOrEmpty ( other.Value ) && Key.ToLower ( ).Equals ( other.Value.ToLower ( ) );

    public static implicit operator IntegrationKey( ExigoReplicatedDbKey _ ) => new ( _.Key );
    public static implicit operator string( ExigoReplicatedDbKey _ ) => _.Key;
    public static readonly ExigoReplicatedDbKey Instance = new();
}
