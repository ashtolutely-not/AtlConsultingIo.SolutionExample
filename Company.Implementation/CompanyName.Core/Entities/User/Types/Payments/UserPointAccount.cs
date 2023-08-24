using CompanyName.Core.Integrations.Exigo;
namespace CompanyName.Core.Entities.User;

public record UserPointAccount
{
    public PointAccountID PointAccountID { get; init; }
    public decimal AccountBalance { get; init; }

}
