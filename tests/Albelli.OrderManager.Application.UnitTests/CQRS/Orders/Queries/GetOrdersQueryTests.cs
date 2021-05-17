using Albelli.OrderManager.Application.CQRS.Orders.Queries;
using Albelli.OrderManager.Application.DTOs;
using Albelli.OrderManager.Application.UnitTests.CQRS.Orders.Common;
using Albelli.OrderManager.Domain.Orders;
using AutoMapper;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Albelli.OrderManager.Application.UnitTests.CQRS.Orders.Queries
{
    public class GetOrdersQueryTests : OrderTestsBase
    {
        protected readonly Mock<IMapper> mapper;
        protected readonly GetOrdersQueryHandler getOrdersQueryHandler;

        public GetOrdersQueryTests()
        {
            mapper = new Mock<IMapper>();
            getOrdersQueryHandler = new GetOrdersQueryHandler(orderDbContext, mapper.Object);
        }

        [Fact]
        public async Task GetOrdersQueryHandler_Returns_OrderProducts()
        {
            // Arranage
            mapper.Setup(x => x.Map<List<OrderDto>>(It.IsAny<List<Order>>())).Returns(orderDtos);

            // Act
            var result = await getOrdersQueryHandler.Handle(new GetOrdersQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Single(result);
        }
    }
}
