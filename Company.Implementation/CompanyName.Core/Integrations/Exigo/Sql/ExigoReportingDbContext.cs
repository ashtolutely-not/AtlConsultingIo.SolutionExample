using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class ExigoReportingDbContext : DbContext
{
    public ExigoReportingDbContext(DbContextOptions<ExigoReportingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AutoOrder> AutoOrders { get; set; }

    public virtual DbSet<AutoOrderChangeLog> AutoOrderChangeLogs { get; set; }

    public virtual DbSet<AutoOrderChargeLog> AutoOrderChargeLogs { get; set; }

    public virtual DbSet<AutoOrderDetail> AutoOrderDetails { get; set; }

    public virtual DbSet<AutoOrderPaymentType> AutoOrderPaymentTypes { get; set; }

    public virtual DbSet<AutoOrderProcessType> AutoOrderProcessTypes { get; set; }

    public virtual DbSet<AutoOrderSchedule> AutoOrderSchedules { get; set; }

    public virtual DbSet<AutoOrderStatus> AutoOrderStatuses { get; set; }

    public virtual DbSet<AutoOrderStatusChangeLog> AutoOrderStatusChangeLogs { get; set; }

    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<BillStatus> BillStatuses { get; set; }

    public virtual DbSet<BillType> BillTypes { get; set; }

    public virtual DbSet<BinaryPlacementType> BinaryPlacementTypes { get; set; }

    public virtual DbSet<BinaryTree> BinaryTrees { get; set; }

    public virtual DbSet<Bonus> Bonuses { get; set; }

    public virtual DbSet<Broadcast> Broadcasts { get; set; }

    public virtual DbSet<BroadcastType> BroadcastTypes { get; set; }

    public virtual DbSet<CodedRank> CodedRanks { get; set; }

    public virtual DbSet<CodingType> CodingTypes { get; set; }

    public virtual DbSet<Commission> Commissions { get; set; }

    public virtual DbSet<CommissionBinaryTree> CommissionBinaryTrees { get; set; }

    public virtual DbSet<CommissionBonus> CommissionBonuses { get; set; }

    public virtual DbSet<CommissionCurrentExchangeRate> CommissionCurrentExchangeRates { get; set; }

    public virtual DbSet<CommissionCustomer> CommissionCustomers { get; set; }

    public virtual DbSet<CommissionDetail> CommissionDetails { get; set; }

    public virtual DbSet<CommissionEnrollerTree> CommissionEnrollerTrees { get; set; }

    public virtual DbSet<CommissionExchangeRate> CommissionExchangeRates { get; set; }

    public virtual DbSet<CommissionOverride> CommissionOverrides { get; set; }

    public virtual DbSet<CommissionRankGroup> CommissionRankGroups { get; set; }

    public virtual DbSet<CommissionRun> CommissionRuns { get; set; }

    public virtual DbSet<CommissionRunStatus> CommissionRunStatuses { get; set; }

    public virtual DbSet<CommissionUniLevelTree> CommissionUniLevelTrees { get; set; }

    public virtual DbSet<CommissionVolume> CommissionVolumes { get; set; }

    public virtual DbSet<CommissionVolumeType> CommissionVolumeTypes { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CompanyNews> CompanyNews { get; set; }

    public virtual DbSet<CompanyNewsDepartment> CompanyNewsDepartments { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<CountryRegion> CountryRegions { get; set; }

    public virtual DbSet<CreditCardType> CreditCardTypes { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAccount> CustomerAccounts { get; set; }

    public virtual DbSet<CustomerAccountChangeLog> CustomerAccountChangeLogs { get; set; }

    public virtual DbSet<CustomerAdjustment> CustomerAdjustments { get; set; }

    public virtual DbSet<CustomerChangeLog> CustomerChangeLogs { get; set; }

    public virtual DbSet<CustomerContact> CustomerContacts { get; set; }

    public virtual DbSet<CustomerEvent> CustomerEvents { get; set; }

    public virtual DbSet<CustomerEventHistory> CustomerEventHistories { get; set; }

    public virtual DbSet<CustomerExtendedChangeLog> CustomerExtendedChangeLogs { get; set; }

    public virtual DbSet<CustomerExtendedDetail> CustomerExtendedDetails { get; set; }

    public virtual DbSet<CustomerExtendedGroup> CustomerExtendedGroups { get; set; }

    public virtual DbSet<CustomerInquiry> CustomerInquiries { get; set; }

    public virtual DbSet<CustomerInquiryCategory> CustomerInquiryCategories { get; set; }

    public virtual DbSet<CustomerInquiryStatus> CustomerInquiryStatuses { get; set; }

    public virtual DbSet<CustomerInquiryType> CustomerInquiryTypes { get; set; }

    public virtual DbSet<CustomerLead> CustomerLeads { get; set; }

    public virtual DbSet<CustomerOverride> CustomerOverrides { get; set; }

    public virtual DbSet<CustomerPayoutSetting> CustomerPayoutSettings { get; set; }

    public virtual DbSet<CustomerPointAccount> CustomerPointAccounts { get; set; }

    public virtual DbSet<CustomerRankChangeLog> CustomerRankChangeLogs { get; set; }

    public virtual DbSet<CustomerSite> CustomerSites { get; set; }

    public virtual DbSet<CustomerSiteChangeLog> CustomerSiteChangeLogs { get; set; }

    public virtual DbSet<CustomerSocialNetwork> CustomerSocialNetworks { get; set; }

    public virtual DbSet<CustomerStatus> CustomerStatuses { get; set; }

    public virtual DbSet<CustomerStatusChangeLog> CustomerStatusChangeLogs { get; set; }

    public virtual DbSet<CustomerSubscription> CustomerSubscriptions { get; set; }

    public virtual DbSet<CustomerTempAuthRequest> CustomerTempAuthRequests { get; set; }

    public virtual DbSet<CustomerTerminationReason> CustomerTerminationReasons { get; set; }

    public virtual DbSet<CustomerTransactionType> CustomerTransactionTypes { get; set; }

    public virtual DbSet<CustomerType> CustomerTypes { get; set; }

    public virtual DbSet<CustomerTypeChangeLog> CustomerTypeChangeLogs { get; set; }

    public virtual DbSet<CustomerWall> CustomerWalls { get; set; }

    public virtual DbSet<EmailOutLog> EmailOutLogs { get; set; }

    public virtual DbSet<EnrollerTree> EnrollerTrees { get; set; }

    public virtual DbSet<EnrollerTreeHistory> EnrollerTreeHistories { get; set; }

    public virtual DbSet<ExpectedPayment> ExpectedPayments { get; set; }

    public virtual DbSet<ExpectedPaymentStatusType> ExpectedPaymentStatusTypes { get; set; }

    public virtual DbSet<ExpectedRetailPayment> ExpectedRetailPayments { get; set; }

    public virtual DbSet<FrequencyType> FrequencyTypes { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<GuestStatusType> GuestStatusTypes { get; set; }

    public virtual DbSet<ImageFile> ImageFiles { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemChangeLog> ItemChangeLogs { get; set; }

    public virtual DbSet<ItemCountryRegion> ItemCountryRegions { get; set; }

    public virtual DbSet<ItemDynamicKitCategory> ItemDynamicKitCategories { get; set; }

    public virtual DbSet<ItemDynamicKitCategoryItemMember> ItemDynamicKitCategoryItemMembers { get; set; }

    public virtual DbSet<ItemDynamicKitCategoryMember> ItemDynamicKitCategoryMembers { get; set; }

    public virtual DbSet<ItemGroupMember> ItemGroupMembers { get; set; }

    public virtual DbSet<ItemImage> ItemImages { get; set; }

    public virtual DbSet<ItemLanguage> ItemLanguages { get; set; }

    public virtual DbSet<ItemPointAccount> ItemPointAccounts { get; set; }

    public virtual DbSet<ItemPrice> ItemPrices { get; set; }

    public virtual DbSet<ItemStaticKitMember> ItemStaticKitMembers { get; set; }

    public virtual DbSet<ItemSubscription> ItemSubscriptions { get; set; }

    public virtual DbSet<ItemType> ItemTypes { get; set; }

    public virtual DbSet<ItemWarehouse> ItemWarehouses { get; set; }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<MerchantDeclineLog> MerchantDeclineLogs { get; set; }

    public virtual DbSet<MerchantDeclineReason> MerchantDeclineReasons { get; set; }

    public virtual DbSet<MerchantType> MerchantTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderBatch> OrderBatches { get; set; }

    public virtual DbSet<OrderChangeLog> OrderChangeLogs { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<OrderStatusChangeLog> OrderStatusChangeLogs { get; set; }

    public virtual DbSet<OrderSubStatusType> OrderSubStatusTypes { get; set; }

    public virtual DbSet<OrderType> OrderTypes { get; set; }

    public virtual DbSet<Override> Overrides { get; set; }

    public virtual DbSet<Party> Parties { get; set; }

    public virtual DbSet<PartyGuest> PartyGuests { get; set; }

    public virtual DbSet<PartyStatus> PartyStatuses { get; set; }

    public virtual DbSet<PartyType> PartyTypes { get; set; }

    public virtual DbSet<PayableType> PayableTypes { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentCard> PaymentCards { get; set; }

    public virtual DbSet<PaymentCardType> PaymentCardTypes { get; set; }

    public virtual DbSet<PaymentType> PaymentTypes { get; set; }

    public virtual DbSet<Payout> Payouts { get; set; }

    public virtual DbSet<PayoutBill> PayoutBills { get; set; }

    public virtual DbSet<PayoutType> PayoutTypes { get; set; }

    public virtual DbSet<Period> Periods { get; set; }

    public virtual DbSet<PeriodRankScore> PeriodRankScores { get; set; }

    public virtual DbSet<PeriodType> PeriodTypes { get; set; }

    public virtual DbSet<PeriodVolume> PeriodVolumes { get; set; }

    public virtual DbSet<PointAccount> PointAccounts { get; set; }

    public virtual DbSet<PointTransaction> PointTransactions { get; set; }

    public virtual DbSet<PointTransactionType> PointTransactionTypes { get; set; }

    public virtual DbSet<PriceType> PriceTypes { get; set; }

    public virtual DbSet<Rank> Ranks { get; set; }

    public virtual DbSet<ReplacementCategory> ReplacementCategories { get; set; }

    public virtual DbSet<ReturnCategory> ReturnCategories { get; set; }

    public virtual DbSet<ShipCarrier> ShipCarriers { get; set; }

    public virtual DbSet<ShipMethod> ShipMethods { get; set; }

    public virtual DbSet<SmsMessage> SmsMessages { get; set; }

    public virtual DbSet<SmsStatus> SmsStatuses { get; set; }

    public virtual DbSet<SocialNetwork> SocialNetworks { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<TaxAddressType> TaxAddressTypes { get; set; }

    public virtual DbSet<TaxCodeType> TaxCodeTypes { get; set; }

    public virtual DbSet<TaxNameType> TaxNameTypes { get; set; }

    public virtual DbSet<UniLevelTree> UniLevelTrees { get; set; }

    public virtual DbSet<UnilevelTreeHistory> UnilevelTreeHistories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VolumePushCycleLog> VolumePushCycleLogs { get; set; }

    public virtual DbSet<WalletType> WalletTypes { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    public virtual DbSet<WarehouseCurrency> WarehouseCurrencies { get; set; }

    public virtual DbSet<WebCategory> WebCategories { get; set; }

    public virtual DbSet<WebCategoryItem> WebCategoryItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AutoOrder>(entity =>
        {
            entity.HasIndex(e => e.AutoOrderStatusId, "IX_AutoOrderStatusID").HasFillFactor(80);

            entity.HasIndex(e => new { e.CustomerId, e.AutoOrderStatusId }, "IX_CustIDAutoOrderStatusID").HasFillFactor(90);

            entity.Property(e => e.AutoOrderId).ValueGeneratedNever();
        });

        modelBuilder.Entity<AutoOrderChangeLog>(entity =>
        {
            entity.Property(e => e.AutoOrderChangeLogId).ValueGeneratedNever();
        });

        modelBuilder.Entity<AutoOrderChargeLog>(entity =>
        {
            entity.Property(e => e.AutoOrderChargeLogId).ValueGeneratedNever();
        });

        modelBuilder.Entity<AutoOrderPaymentType>(entity =>
        {
            entity.Property(e => e.AutoOrderPaymentTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<AutoOrderProcessType>(entity =>
        {
            entity.Property(e => e.AutoOrderProcessTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<AutoOrderStatus>(entity =>
        {
            entity.Property(e => e.AutoOrderStatusId).ValueGeneratedNever();
        });

        modelBuilder.Entity<AutoOrderStatusChangeLog>(entity =>
        {
            entity.Property(e => e.AutoOrderStatusChangeLogId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.Property(e => e.BillId).ValueGeneratedNever();
        });

        modelBuilder.Entity<BillStatus>(entity =>
        {
            entity.Property(e => e.BillStatusId).ValueGeneratedNever();
        });

        modelBuilder.Entity<BillType>(entity =>
        {
            entity.Property(e => e.BillTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<BinaryPlacementType>(entity =>
        {
            entity.Property(e => e.BinaryPlacementTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<BinaryTree>(entity =>
        {
            entity.HasKey(e => e.CustomerId).IsClustered(false);
            entity.ToTable( t => t.IsMemoryOptimized() );
            entity.Property(e => e.CustomerId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Bonus>(entity =>
        {
            entity.Property(e => e.BonusId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Broadcast>(entity =>
        {
            entity.Property(e => e.BroadCastId).ValueGeneratedNever();
        });

        modelBuilder.Entity<BroadcastType>(entity =>
        {
            entity.Property(e => e.BroadcastTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CodedRank>(entity =>
        {
            entity.Property(e => e.CodedRankEntryId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CodingType>(entity =>
        {
            entity.Property(e => e.CodingTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CommissionRun>(entity =>
        {
            entity.Property(e => e.CommissionRunId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CommissionRunStatus>(entity =>
        {
            entity.Property(e => e.CommissionRunStatusId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CompanyNews>(entity =>
        {
            entity.Property(e => e.CompanyNewsId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CreditCardType>(entity =>
        {
            entity.Property(e => e.CreditCardTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasIndex(e => new { e.CustomerId, e.CreatedDate }, "IX_CustIDCreatedDt").HasFillFactor(90);

            entity.HasIndex(e => e.CustomerId, "IX_CustomerID").HasFillFactor(90);

            entity.HasIndex(e => new { e.CustomerStatusId, e.CustomerId }, "IX_StatusID_ID_Inc_Phones").HasFillFactor(100);

            entity.HasIndex(e => new { e.CustomerStatusId, e.MobilePhone }, "IX_StatusID_MobilePhone_Inc_ID").HasFillFactor(100);

            entity.HasIndex(e => new { e.CustomerStatusId, e.Phone2 }, "IX_StatusID_Phone2_Inc_ID").HasFillFactor(100);

            entity.HasIndex(e => new { e.CustomerStatusId, e.Phone }, "IX_StatusID_Phone_Inc_ID").HasFillFactor(100);

            entity.HasIndex(e => new { e.CustomerStatusId, e.CustomerTypeId }, "IX_StatusID_TypeID_Inc_Subcription").HasFillFactor(100);

            entity.Property(e => e.CustomerId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerAccount>(entity =>
        {
            entity.HasIndex(e => e.ModifiedDate, "IX_ModifiedDate").HasFillFactor(100);

            entity.Property(e => e.CustomerId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerAccountChangeLog>(entity =>
        {
            entity.Property(e => e.CustomerAccountChangeLogId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerAdjustment>(entity =>
        {
            entity.Property(e => e.TransactionId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerChangeLog>(entity =>
        {
            entity.Property(e => e.CustomerChangeLogId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerContact>(entity =>
        {
            entity.Property(e => e.CustomerContactId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerEvent>(entity =>
        {
            entity.Property(e => e.CustomerEventId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerExtendedChangeLog>(entity =>
        {
            entity.Property(e => e.CustomerExtendedChangeLogId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerExtendedDetail>(entity =>
        {
            entity.Property(e => e.CustomerExtendedDetailId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerExtendedGroup>(entity =>
        {
            entity.Property(e => e.CustomerExtendedGroupId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerInquiry>(entity =>
        {
            entity.Property(e => e.CustomerInquiryId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerInquiryCategory>(entity =>
        {
            entity.Property(e => e.CustomerInquiryCategoryId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerInquiryStatus>(entity =>
        {
            entity.Property(e => e.CustomerInquiryStatusId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerInquiryType>(entity =>
        {
            entity.Property(e => e.CustomerInquiryTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerLead>(entity =>
        {
            entity.Property(e => e.CustomerLeadId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerPayoutSetting>(entity =>
        {
            entity.Property(e => e.CustomerId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerRankChangeLog>(entity =>
        {
            entity.Property(e => e.CustomerRankChangeLogId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerSite>(entity =>
        {
            entity.Property(e => e.CustomerId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerSiteChangeLog>(entity =>
        {
            entity.Property(e => e.CustomerSiteChangeLogId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerStatus>(entity =>
        {
            entity.Property(e => e.CustomerStatusId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerStatusChangeLog>(entity =>
        {
            entity.HasIndex(e => new { e.CustomerStatusId, e.ModifiedDate }, "IX_StID_MdDt").HasFillFactor(100);

            entity.Property(e => e.CustomerStatusChangeLogId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerTempAuthRequest>(entity =>
        {
            entity.Property(e => e.CustomerTempAuthRequestId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerTerminationReason>(entity =>
        {
            entity.Property(e => e.ReasonId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerTransactionType>(entity =>
        {
            entity.Property(e => e.CustomerTransactionTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerType>(entity =>
        {
            entity.Property(e => e.CustomerTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerTypeChangeLog>(entity =>
        {
            entity.Property(e => e.CustomerTypeChangeLogId).ValueGeneratedNever();
        });

        modelBuilder.Entity<CustomerWall>(entity =>
        {
            entity.Property(e => e.CustomerWallItemId).ValueGeneratedNever();
        });

        modelBuilder.Entity<EmailOutLog>(entity =>
        {
            entity.Property(e => e.OutMailId).ValueGeneratedNever();
        });

        modelBuilder.Entity<EnrollerTree>(entity =>
        {
            entity.HasKey(e => e.CustomerId).IsClustered(false);

            entity.ToTable( t => t.IsMemoryOptimized() );

            entity.Property(e => e.CustomerId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ExpectedPayment>(entity =>
        {
            entity.Property(e => e.ExpectedPaymentId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ExpectedPaymentStatusType>(entity =>
        {
            entity.Property(e => e.ExpectedPaymentStatusTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ExpectedRetailPayment>(entity =>
        {
            entity.Property(e => e.RetailOrderId).ValueGeneratedNever();
        });

        modelBuilder.Entity<FrequencyType>(entity =>
        {
            entity.Property(e => e.FrequencyTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.Property(e => e.GuestId).ValueGeneratedNever();
        });

        modelBuilder.Entity<GuestStatusType>(entity =>
        {
            entity.Property(e => e.GuestStatusTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasIndex(e => e.ItemCode, "IX_Items_ItemCode").HasFillFactor(90);

            entity.Property(e => e.ItemId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ItemChangeLog>(entity =>
        {
            entity.Property(e => e.ItemChangeLogId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ItemDynamicKitCategory>(entity =>
        {
            entity.Property(e => e.DynamicKitCategoryId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ItemImage>(entity =>
        {
            entity.Property(e => e.ItemImageId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ItemPrice>(entity =>
        {
            entity.HasIndex(e => new { e.CurrencyCode, e.PriceTypeId }, "IX_CurrCdPriceTypeID").HasFillFactor(90);
        });

        modelBuilder.Entity<ItemType>(entity =>
        {
            entity.Property(e => e.ItemTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Language>(entity =>
        {
            entity.Property(e => e.LanguageId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MerchantDeclineLog>(entity =>
        {
            entity.Property(e => e.MerchantDeclineLogId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MerchantDeclineReason>(entity =>
        {
            entity.Property(e => e.MerchantDeclineReasonId).ValueGeneratedNever();
        });

        modelBuilder.Entity<MerchantType>(entity =>
        {
            entity.Property(e => e.MerchantTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).ValueGeneratedNever();
        });

        modelBuilder.Entity<OrderChangeLog>(entity =>
        {
            entity.Property(e => e.OrderChangeLogId).ValueGeneratedNever();
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasIndex(e => new { e.ItemCode, e.ItemDescription }, "IX_ItemCode_ItemDesc").HasFillFactor(100);
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.Property(e => e.OrderStatusId).ValueGeneratedNever();
        });

        modelBuilder.Entity<OrderStatusChangeLog>(entity =>
        {
            entity.Property(e => e.OrderStatusChangeLogId).ValueGeneratedNever();
        });

        modelBuilder.Entity<OrderSubStatusType>(entity =>
        {
            entity.Property(e => e.OrderSubStatusId).ValueGeneratedNever();
        });

        modelBuilder.Entity<OrderType>(entity =>
        {
            entity.Property(e => e.OrderTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Party>(entity =>
        {
            entity.Property(e => e.PartyId).ValueGeneratedNever();
        });

        modelBuilder.Entity<PartyStatus>(entity =>
        {
            entity.Property(e => e.PartyStatusId).ValueGeneratedNever();
        });

        modelBuilder.Entity<PartyType>(entity =>
        {
            entity.Property(e => e.PartyTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<PayableType>(entity =>
        {
            entity.Property(e => e.PayableTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasIndex(e => e.CustomerId, "IX_CustomerID_Inc").HasFillFactor(100);

            entity.HasIndex(e => e.PaymentDate, "IX_PaymentDate_Inc").HasFillFactor(100);

            entity.HasIndex(e => new { e.PaymentTypeId, e.PaymentDate }, "IX_TypeID_Date_Inc").HasFillFactor(100);

            entity.Property(e => e.PaymentId).ValueGeneratedNever();
        });

        modelBuilder.Entity<PaymentCard>(entity =>
        {
            entity.Property(e => e.PaymentCardId).ValueGeneratedNever();
        });

        modelBuilder.Entity<PaymentCardType>(entity =>
        {
            entity.Property(e => e.PaymentCardTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<PaymentType>(entity =>
        {
            entity.Property(e => e.PaymentTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Payout>(entity =>
        {
            entity.Property(e => e.PayoutId).ValueGeneratedNever();
        });

        modelBuilder.Entity<PayoutBill>(entity =>
        {
            entity.HasIndex(e => e.PayoutId, "IX_PayoutID_Inc_BillID").HasFillFactor(100);

            entity.Property(e => e.TransactionId).ValueGeneratedNever();
        });

        modelBuilder.Entity<PayoutType>(entity =>
        {
            entity.Property(e => e.PayoutTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<PeriodType>(entity =>
        {
            entity.Property(e => e.PeriodTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<PeriodVolume>(entity =>
        {
            entity.HasIndex(e => new { e.PeriodTypeId, e.CustomerId, e.PeriodId }, "IX_PerTypeIDCustIDPeriodID").HasFillFactor(80);

            entity.HasIndex(e => new { e.Volume1, e.PeriodId }, "IX_Vol1PeriodID").HasFillFactor(80);
        });

        modelBuilder.Entity<PointAccount>(entity =>
        {
            entity.Property(e => e.PointAccountId).ValueGeneratedNever();
        });

        modelBuilder.Entity<PointTransaction>(entity =>
        {
            entity.HasIndex(e => new { e.CustomerId, e.PointAccountId }, "IX_CustIDPointAcctID").HasFillFactor(80);

            entity.Property(e => e.PointTransactionId).ValueGeneratedNever();
        });

        modelBuilder.Entity<PointTransactionType>(entity =>
        {
            entity.Property(e => e.PointTransactionTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<PriceType>(entity =>
        {
            entity.Property(e => e.PriceTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Rank>(entity =>
        {
            entity.Property(e => e.RankId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ReplacementCategory>(entity =>
        {
            entity.Property(e => e.ReplacementCategoryId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ReturnCategory>(entity =>
        {
            entity.Property(e => e.ReturnCategoryId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ShipCarrier>(entity =>
        {
            entity.Property(e => e.ShipCarrierId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ShipMethod>(entity =>
        {
            entity.Property(e => e.ShipMethodId).ValueGeneratedNever();
        });

        modelBuilder.Entity<SmsMessage>(entity =>
        {
            entity.Property(e => e.MessageId).ValueGeneratedNever();
        });

        modelBuilder.Entity<SmsStatus>(entity =>
        {
            entity.Property(e => e.SmsStatusId).ValueGeneratedNever();
        });

        modelBuilder.Entity<SocialNetwork>(entity =>
        {
            entity.Property(e => e.SocialNetworkId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.Property(e => e.SubscriptionId).ValueGeneratedNever();
        });

        modelBuilder.Entity<TaxAddressType>(entity =>
        {
            entity.Property(e => e.TaxAddressTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<TaxCodeType>(entity =>
        {
            entity.Property(e => e.TaxCodeTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<TaxNameType>(entity =>
        {
            entity.Property(e => e.TaxNameTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<UniLevelTree>(entity =>
        {
            entity.HasKey(e => e.CustomerId).IsClustered(false);

            entity.ToTable( t => t.IsMemoryOptimized() );

            entity.Property(e => e.CustomerId).ValueGeneratedNever();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).ValueGeneratedNever();
        });

        modelBuilder.Entity<VolumePushCycleLog>(entity =>
        {
            entity.Property(e => e.VolumePushCycleLogId).ValueGeneratedNever();
        });

        modelBuilder.Entity<WalletType>(entity =>
        {
            entity.Property(e => e.WalletTypeId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.Property(e => e.WarehouseId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
