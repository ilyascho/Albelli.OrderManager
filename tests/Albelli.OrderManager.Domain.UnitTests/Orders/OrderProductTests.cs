using Albelli.OrderManager.Domain.Orders;
using System;
using Xunit;

namespace Albelli.OrderManager.Domain.UnitTests.Orders
{
    public class OrderProductTests
    {
        [Fact]
        public void OrderProduct_Constructor_ShouldWork()
        {
            //Act
            var orderProduct = new OrderProduct();

            //Assert
            Assert.NotNull(orderProduct);
            Assert.Equal(Guid.Empty, orderProduct.Id);
            Assert.Equal(0, orderProduct.Quantity);
            Assert.Null(orderProduct.Product);
        }
    }
}
