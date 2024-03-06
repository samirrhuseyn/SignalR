using AutoMapper;
using SignalR.DtoLayer.OrderDto;
using SignalR.EntityLayer.Entities;

namespace SiqnalRApi.Mapping
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<Order, ResultOrderDto>().ReverseMap();
            CreateMap<Order, GetOrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();
        }
    }
}
