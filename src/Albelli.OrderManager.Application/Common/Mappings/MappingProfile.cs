using Albelli.OrderManager.Application.DTOs;
using Albelli.OrderManager.Domain.Orders;
using AutoMapper;

namespace Albelli.OrderManager.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<Order, OrderResponseDto>();
            CreateMap<OrderProduct, OrderProductDto>();
        }
    }
}
