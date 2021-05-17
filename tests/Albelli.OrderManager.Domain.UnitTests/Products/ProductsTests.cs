using Albelli.OrderManager.Domain.Products;
using Moq;
using System;
using Xunit;

namespace Albelli.OrderManager.Domain.UnitTests.Products
{
    public class ProductsTests
    {
        [Fact]
        
        public void Product_Constructor_ShouldWork()
        {
            //Act
            var product = new Mock<Product>() { CallBase = true };
            product.Object.Id = Guid.NewGuid();
            product.Object.ProductType = Enums.ProductType.Mug;           

            //Assert
            Assert.NotNull(product);
        }
    }
}
