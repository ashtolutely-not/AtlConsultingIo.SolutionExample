// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetDownlineRequest : ApiRequest
{
    public TreeType TreeType { get; init; }
    public int CustomerID { get; init; }
    public int PeriodType { get; init; }
    public int? PeriodID { get; init; }
    public int MaxLevelDepth { get; init; }
    public int[] CustomerTypes { get; init; }
    public int[] Ranks { get; init; }
    public int[] PayRanks { get; init; }
    public VolumeFilter[] VolumeFilters { get; init; }
    public int[] CustomerStatusTypes { get; init; }
    public int? BatchSize { get; init; }
    public bool SortByLevel { get; init; }
    public int BatchOffset { get; init; }
    public string CustomerKey { get; init; }

    public GetDownlineRequest() : base()
    {
        CustomerTypes = new int[0];
        Ranks = new int[0];
        PayRanks = new int[0];
        VolumeFilters = new VolumeFilter[0];
        CustomerStatusTypes = new int[0];
        CustomerKey = String.Empty;
    }
}
