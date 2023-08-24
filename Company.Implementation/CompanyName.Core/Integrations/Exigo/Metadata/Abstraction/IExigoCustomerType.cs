using CompanyName.Core.Entities;

namespace CompanyName.Core.Integrations.Exigo;

public interface IExigoCustomerType
{
    public ExigoTypeID TypeId { get; }
    public UIDisplayString? Description { get; }
}
