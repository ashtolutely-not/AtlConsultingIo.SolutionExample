using CompanyName.Operations;
using CompanyName.Operations.Account;
using CompanyName.Operations.Checkout;
using CompanyName.Operations.Messaging;
using CompanyName.Operations.Order;
using CompanyName.Operations.Product;
using CompanyName.Core;
using CompanyName.Core.Entities;
using CompanyName.Core.Entities.Events;
using CompanyName.Core.Entities.Messaging;
using CompanyName.Core.Entities.Order;
using CompanyName.Core.Entities.Product;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;
using CompanyName.Core.Integrations.Exigo.Sql;
using CompanyName.Core.Integrations.KountApi;
using CompanyName.Core.Integrations.SendGridApi;

namespace CompanyName.Operations;
public class EnrollerSearchOptions
    {
        public int PageSize { get; set; } = 100;
        public int[] CustomerTypeFilter { get; set; } = new int[]{ DistributorAccount.Instance.TypeId };
        public int[] CustomerStatusFilter { get; set; } = new int[]{ ExigoConfiguration.Instance.Checkout.TypeIDs.ActiveAccountStatusID };
        public bool IncludeEnrollerSite { get; set; } = true;   
    }
