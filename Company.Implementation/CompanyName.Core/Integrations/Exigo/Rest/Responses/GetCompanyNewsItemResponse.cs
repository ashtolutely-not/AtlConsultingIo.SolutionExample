// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetCompanyNewsItemResponse : ApiResponse
{
    public string Description { get; init; }
    public int NewsID { get; init; }
    public DateTime CreatedDate { get; init; }
    public NewsWebSettings WebSettings { get; init; }
    public NewsCompanySettings CompanySettings { get; init; }
    public string Content { get; init; }
    public DepartmentInfo[] Departments { get; init; }

    public GetCompanyNewsItemResponse() : base()
    {
        Description = String.Empty;
        Content = String.Empty;
        Departments = new DepartmentInfo[0];
    }
}
