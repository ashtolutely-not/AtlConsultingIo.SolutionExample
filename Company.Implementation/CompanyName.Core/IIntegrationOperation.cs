
using AtlConsultingIo.IntegrationOperations;
namespace CompanyName.Core;
public interface IIntegrationOperation
{
    IntegrationKey Key { get; }
    string? OperationError { get; set; }
}
