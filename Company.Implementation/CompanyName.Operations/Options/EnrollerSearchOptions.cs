using CompanyName.Core.Integrations.Exigo;

namespace CompanyName.Operations;
public class EnrollerSearchOptions
    {
        public int PageSize { get; set; } = 100;
        public int[] CustomerTypeFilter { get; set; } = new int[]{ DistributorAccount.Instance.TypeId };
        public int[] CustomerStatusFilter { get; set; } = new int[]{ ExigoConfiguration.Instance.Checkout.TypeIDs.ActiveAccountStatusID };
        public bool IncludeEnrollerSite { get; set; } = true;   
    }
