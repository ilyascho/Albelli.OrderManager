using Albelli.OrderManager.Application.CQRS.Orders.Queries;
using Albelli.OrderManager.Application.DTOs;
using Albelli.OrderManager.Application.UnitTests.CQRS.Orders.Common;
using Albelli.OrderManager.Domain.Orders;
using AutoMapper;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Albelli.OrderManager.Application.UnitTests.CQRS.Orders.Queries
{
    public class GetOrderByIdQueryTests : OrderTestsBase
    {
        protected readonly Mock<IMapper> mapper;
        protected readonly GetOrderByIdQueryHandler getOrderByIdQueryHandler;

        public GetOrderByIdQueryTests()
        {
            mapper = new Mock<IMapper>();
            getOrderByIdQueryHandler = new GetOrderByIdQueryHandler(orderDbContext, mapper.Object);
        }

        [Fact]
        public async Task GetOrderByIdQueryHandler_Returns_OrderProducts()
        {
            //Arrange
            mapper.Setup(x => x.Map<OrderDto>(It.IsAny<Order>())).Returns(orderDto);
            
            // Act
            var result = await getOrderByIdQueryHandler.Handle(new GetOrderByIdQuery { Id = Guid.NewGuid() }, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.NotEqual(Guid.Empty, result.Id);
            Assert.Equal(19 + 10 + (3 * 94), result.RequiredBinWidth);
        }
    }
}
