using Albelli.OrderManager.Domain.Orders;
using System;
using Xunit;

namespace Albelli.OrderManager.Domain.UnitTests.Orders
{
    public class OrderTests
    {
        [Fact]
        public void Order_Constructor_ShouldWork()
        {
            //Act
            var order = new Order();

            //Assert
            Assert.NotNull(order);
            Assert.NotEqual(Guid.Empty, order.Id);
            Assert.Empty(order.OrderProducts);
        }

        [Fact]
        public void Add_OrderProduct_ShouldWork()
        {
            //Arrange
            var order = new Order();
            var orderProduct = new OrderProduct();

            //Act
            order.OrderProducts.Add(orderProduct);

            //Assert
            Assert.Single(order.OrderProducts);
        }
    }
}
