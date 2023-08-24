using CompanyName.Core.Entities;

namespace CompanyName.Core.Integrations.Exigo;

public interface IExigoTypeMetadata
{
    ExigoTypeID TypeID { get; }
    UIDisplayString? Description { get; }
}
