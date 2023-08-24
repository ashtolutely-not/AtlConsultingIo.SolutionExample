// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record VolumeFilter
{
    public int VolumeID { get; init; }
    public NumericCompareType Compare { get; init; }
    public Decimal Value { get; init; }

    public VolumeFilter() : base()
    {
    }
}
