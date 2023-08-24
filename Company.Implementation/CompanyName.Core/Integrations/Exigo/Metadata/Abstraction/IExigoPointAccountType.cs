using CompanyName.Core.Entities;
namespace CompanyName.Core.Integrations.Exigo;

public interface IExigoPointAccountType : IExigoTypeMetadata
{
    Enabled EnabledForOrderPayment { get; set; }

}
