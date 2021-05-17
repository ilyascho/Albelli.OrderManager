using Albelli.OrderManager.Application.Factories;
using Albelli.OrderManager.Domain.Enums;
using Albelli.OrderManager.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Albelli.OrderManager.Application.UnitTests.Factories
{
    public class ProductFactoryTests
    {
        public static IEnumerable<object[]> ProductTypeEnumValues()
        {
            foreach (var type in Enum.GetValues(typeof(ProductType)))
            {
                yield return new object[] { type };
            }
        }

        [Theory]
        [MemberData(nameof(ProductTypeEnumValues))]
        public void ProductFactory_ShouldCreate_TypeSpecificProduct(ProductType productType)
        {
            //Act
            var product = ProductFactory.Create(productType);

            //Assert
            Assert.NotNull(product);
            Assert.Equal(productType, product.ProductType);
        }
    }
}
