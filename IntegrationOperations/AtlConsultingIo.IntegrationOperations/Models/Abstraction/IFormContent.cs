
using Microsoft.AspNetCore.Mvc.Formatters;

namespace AtlConsultingIo.IntegrationOperations;
public interface IFormContent
{
    FormUrlEncodedContent GetEncodedForm();
}
