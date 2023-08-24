// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record ApiResult
{
    public ResultStatus Status { get; init; }
    public string[] Errors { get; init; }
    public string TransactionKey { get; init; }

    public ApiResult() : base()
    {
        Errors = new string[0];
        TransactionKey = String.Empty;
    }
}
