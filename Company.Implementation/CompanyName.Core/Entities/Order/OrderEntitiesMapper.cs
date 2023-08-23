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
using AutoMapper;



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
