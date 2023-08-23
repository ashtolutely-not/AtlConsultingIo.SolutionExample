// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.
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

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record Property
{
    public string Name { get; init; }
    public bool IsKey { get; init; }
    public bool IsNew { get; init; }
    public bool IsAutoNumber { get; init; }
    public bool AllowDbNull { get; init; }
    public PropertyType Type { get; init; }
    public string DefaultName { get; init; }
    public string DefaultValue { get; init; }
    public int? Size { get; init; }
    public string AutoGenerate { get; init; }

    public Property() : base()
    {
        Name = String.Empty;
        DefaultName = String.Empty;
        DefaultValue = String.Empty;
        AutoGenerate = String.Empty;
    }
}
