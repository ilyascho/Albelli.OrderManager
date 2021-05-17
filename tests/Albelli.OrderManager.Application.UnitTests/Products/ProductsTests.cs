using Albelli.OrderManager.Application.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Albelli.OrderManager.Application.UnitTests
{
    public class ProductsTests
    {
        [Fact]
        public void CalculateRequiredWidth_ForOnePhotoBook_IsSuccessful()
        {
            // Arrange
            var product = new PhotoBookFactory().Create();

            // Act
            decimal actualWidth = product.CalculateBinWidth(1);

            // Assert
            Assert.Equal(19.0M, actualWidth);
        }

        [Fact]
        public void CalculateRequiredWidth_ForTwoPhotoBooks_IsSuccessful()
        {
            // Arrange
            var product = new PhotoBookFactory().Create();

            // Act
            decimal actualWidth = product.CalculateBinWidth(quantity:2);

            // Assert
            Assert.Equal(38.0M, actualWidth);
        }

        [Fact]
        public void CalculateRequiredWidth_ForTwoPhotoBookAndTenMugs_IsSuccessful()
        {
            // Arrange
            var order = new OrderBuilder()
                .AddPhotoBook(2)
                .AddMug(10)
                .Build();

            // Act
            decimal actualWidth = 0.0M;
            foreach (var product in order.OrderProducts)
            {
                actualWidth += product.Product.CalculateBinWidth(product.Quantity);
            }

            // Assert
            Assert.Equal(320.0M, actualWidth);
        }

        [Fact]
        public void CalculateRequiredWidth_OneForAllProductTypes_IsSuccessful()
        {
            // Arrange
            var order = new OrderBuilder()
                .AddPhotoBook(1)
                .AddCalendar(1)
                .AddCanvas(1)
                .AddCards(1)
                .AddMug(1)
                .Build();

            // Act
            decimal actualWidth = 0.0M;
            foreach (var product in order.OrderProducts)
            {
                actualWidth += product.Product.CalculateBinWidth(product.Quantity);
            }

            // Assert
            Assert.Equal(143.7M, actualWidth);
        }
    }
}
