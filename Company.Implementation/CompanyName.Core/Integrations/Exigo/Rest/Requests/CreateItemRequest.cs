// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CreateItemRequest : ApiRequest, ITransactionMember
{
    public string ItemCode { get; init; }
    public string Description { get; init; }
    public Decimal Weight { get; init; }
    public string Notes { get; init; }
    public bool AvailableInAllCountryRegions { get; init; }
    public bool TaxedInAllCountryRegions { get; init; }
    public bool AvailableInAllWarehouses { get; init; }
    public bool IsVirtual { get; init; }
    public int ItemTypeID { get; init; }
    public bool OtherCheck1 { get; init; }
    public bool OtherCheck2 { get; init; }
    public bool OtherCheck3 { get; init; }
    public bool OtherCheck4 { get; init; }
    public bool OtherCheck5 { get; init; }
    public string Field1 { get; init; }
    public string Field2 { get; init; }
    public string Field3 { get; init; }
    public string Field4 { get; init; }
    public string Field5 { get; init; }
    public string Field6 { get; init; }
    public string Field7 { get; init; }
    public string Field8 { get; init; }
    public string Field9 { get; init; }
    public string Field10 { get; init; }
    public bool HideFromSearch { get; init; }
    public bool IsSubscriptionUpdate { get; init; }
    public bool IsPointIncrement { get; init; }

    public CreateItemRequest() : base()
    {
        ItemCode = String.Empty;
        Description = String.Empty;
        Notes = String.Empty;
        Field1 = String.Empty;
        Field2 = String.Empty;
        Field3 = String.Empty;
        Field4 = String.Empty;
        Field5 = String.Empty;
        Field6 = String.Empty;
        Field7 = String.Empty;
        Field8 = String.Empty;
        Field9 = String.Empty;
        Field10 = String.Empty;
    }
}
