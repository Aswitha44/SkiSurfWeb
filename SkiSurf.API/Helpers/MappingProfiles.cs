using AutoMapper;
using SkiSurf.API.DTOs;
using SkiSurf.Core.Entities;
using SkiSurf.Core.Entities.Identity;
using SkiSurf.Core.Entities.OrderAggregate;
using Address = SkiSurf.Core.Entities.OrderAggregate.Address;

namespace SkiSurf.API.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles() {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d=>d.ProductBrand,o=>o.MapFrom(s=>s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
               .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
            CreateMap<SkiSurf.Core.Entities.Identity.Address, AddressDto>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<AddressDto, SkiSurf.Core.Entities.OrderAggregate.Address>();
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.ShortName))
                .ForMember(d => d.ShippingPrice, o => o.MapFrom(s => s.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDto>()
            .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ItemOrdered.ProductItemId))
             .ForMember(d => d.ProductName, o => o.MapFrom(s => s.ItemOrdered.ProductName))
              .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.ItemOrdered.PictureUrl))
              .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());



        }
    }
}
