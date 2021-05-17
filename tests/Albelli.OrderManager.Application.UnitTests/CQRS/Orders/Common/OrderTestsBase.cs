using Albelli.OrderManager.Application.DTOs;
using Albelli.OrderManager.Domain.Orders;
using Albelli.OrderManager.Infra.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Albelli.OrderManager.Application.UnitTests.CQRS.Orders.Common
{
    public class OrderTestsBase
    {        
        protected readonly DbContextOptions<OrderDbContext> options;
        protected readonly OrderDbContext orderDbContext;
        protected readonly Order order;
        protected readonly List<OrderDto> orderDtos;
        protected readonly OrderDto orderDto;
        protected readonly OrderResponseDto orderResponseDto;

        public OrderTestsBase()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Order, OrderResponseDto>();
                cfg.CreateMap<Order, OrderDto>();
            });
            IMapper iMapper = config.CreateMapper();
            
            options = new DbContextOptionsBuilder<OrderDbContext>()
                                .UseInMemoryDatabase(databaseName: "TestDB")
                                .Options;

            orderDbContext = new OrderDbContext(options);

            order = new OrderBuilder()
                .AddPhotoBook(1)
                .AddCalendar(1)
                .AddMug(10)
                .Build();

            orderResponseDto = iMapper.Map<Order, OrderResponseDto>(order);
            orderDto = iMapper.Map<Order, OrderDto>(order);
            orderDtos = new List<OrderDto>
            {
                iMapper.Map<Order, OrderDto>(order)
            };

            orderDbContext.Add(order);
            orderDbContext.SaveChanges();
        }
    }
}
