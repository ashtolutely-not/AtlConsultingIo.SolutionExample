// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record BaseChargeWalletAccountRequest : BaseCreatePaymentRequest
{
    public string OtherData1 { get; init; }
    public string OtherData2 { get; init; }
    public string OtherData3 { get; init; }
    public string OtherData4 { get; init; }
    public string OtherData5 { get; init; }
    public string OtherData6 { get; init; }
    public string OtherData7 { get; init; }
    public string OtherData8 { get; init; }
    public string OtherData9 { get; init; }
    public string OtherData10 { get; init; }

    public BaseChargeWalletAccountRequest() : base()
    {
        OtherData1 = String.Empty;
        OtherData2 = String.Empty;
        OtherData3 = String.Empty;
        OtherData4 = String.Empty;
        OtherData5 = String.Empty;
        OtherData6 = String.Empty;
        OtherData7 = String.Empty;
        OtherData8 = String.Empty;
        OtherData9 = String.Empty;
        OtherData10 = String.Empty;
    }
}
