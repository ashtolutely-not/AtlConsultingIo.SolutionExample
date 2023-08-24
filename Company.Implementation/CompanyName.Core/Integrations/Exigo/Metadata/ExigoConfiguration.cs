namespace CompanyName.Core.Integrations.Exigo;

/*
    The struct implementation can generated from table values if the rate of change is higher 
    But since this is super low level data, I don't anticipate there being a need
 */
public record ExigoConfiguration
{
    public CheckoutSettings Checkout { get; set; } = new();

    //Since this is for a company specific implementation, I'm using structs and exposing an instance staticly
    //But if there's a use case for the options pattern it could be converted or a generator to write contextual code
    public struct CheckoutSettings
    {
        public readonly ExigoTypeIDs TypeIDs = new();
        public readonly List<PointAccountID> PointPaymentAccounts = new()
        {
            new PointAccountID(2),
            new PointAccountID(3),
            new PointAccountID(7),
        };
        public readonly CheckoutDefaults Defaults = new();
        public CheckoutSettings( )
        {

        }
        public struct CheckoutDefaults
        {
            public readonly ExigoTypeID WarehouseID = new ( 2 );
            public readonly ExigoTypeID PlacementTypeID = new ( 4 );
            public readonly ExigoTypeID ShipMethodID = new ( 32 );
            public readonly ExigoTypeID PriceTypeID = new ( 7 );
            public readonly ExigoTypeID PayableTypeID = new ( 1 );
            public readonly ExigoTypeID LanguageID = new ( 0 );
            public readonly ExigoTypeID AccountStatus = new ( 1 );
            public readonly CustomerID EnrollerID = new ( 106 );
            public CheckoutDefaults( )
            {

            }
        }
        public struct ExigoTypeIDs
        {
            //Fixed | Playform Controlled
            public readonly ExigoTypeID PaypalWalletType = new ( 100 );
            public readonly ExigoTypeID PointRedemptionTransactionType = new ( 2 );
            public readonly ExigoTypeID PointAdjustmentTransactionType = new ( 3 );
            public readonly ExigoTypeID PointAccountPaymentType = new ( 10 );

            //Platform Controlled but existing business processes | reports means that
            //legacy code sets values based on business defined criteria
            public readonly ExigoTypeID HasHighRiskTotalOrderStatus = new ( 10 );
            public readonly ExigoTypeID HasHighRiskPaymentOrderStatus = new ( 1 );

            //Custom | Company Constrolled
            public readonly ExigoTypeID CommerceCloudOrderType = new ( 14 );
            public readonly ExigoTypeID GiftCardPaymentType = new ( 15 );
            public readonly ExigoTypeID ActiveAccountStatusID = new ( 1 );
            public readonly ExigoTypeID PendingAccountStatusID = new ( 3 );

            //Platform hack due to original relational database design
            public readonly ExigoTypeID CbdMerchantWarehouse = new( 21 );
            public ExigoTypeIDs( )
            {

            }
        }

        public static readonly CheckoutSettings Instance = new();
    }

    public static readonly ExigoConfiguration Instance = new();

}
