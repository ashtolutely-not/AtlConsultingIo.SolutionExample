using AutoMapper;

using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;



namespace CompanyName.Core.Entities.Order;

public class OrderEntitiesMapper : ExigoEntityMapper
{
    public OrderEntitiesMapper()
    {
        CreateMap<AutoOrderDetailResponse,SmartshipItem>( MemberList.None );
        CreateMap<GiftCardPayment, CreatePaymentRequest>( MemberList.None )
            .ForMember( d => d.OrderID, o => o.MapFrom( s => s.OrderId.HasValue ? s.OrderId.Value : 0 ))
            .ForMember( d => d.PaymentDate , o => o.MapFrom( s => s.TransactionDate.GetValueOrDefault()))
            .ForMember( d => d.PaymentTy, o => o.MapFrom( s => ExigoConfiguration.Checkout.TypeIDs.GiftCardPaymentType ))
            .ForMember( d => d.Memo, o => o.MapFrom( s => s.Reference));
    }

    
}
