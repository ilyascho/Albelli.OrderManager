using Albelli.OrderManager.Application.Factories;
using Albelli.OrderManager.Domain.Orders;
using Albelli.OrderManager.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Albelli.OrderManager.Application
{
    public class OrderBuilder
    {
        private Order order;

        public OrderBuilder AddPhotoBook(int quantity = 1)
        {
            this.Add(new PhotoBookFactory().Create(), quantity);

            return this;
        }

        public OrderBuilder AddCalendar(int quantity = 1)
        {
            this.Add(new CalendarFactory().Create(), quantity);

            return this;
        }

        public OrderBuilder AddCanvas(int quantity = 1)
        {
            this.Add(new CanvasFactory().Create(),  quantity);

            return this;
        }

        public OrderBuilder AddCards(int quantity = 1)
        {
            this.Add(new CardsFactory().Create(), quantity);

            return this;
        }

        public OrderBuilder AddMug(int quantity = 1)
        {
            this.Add(new MugFactory().Create(), quantity);

            return this;
        }

        private void Add(Product product, int quantity)
        {
            this.order ??= this.Build();
            var orderProduct = new OrderProduct { Id = Guid.NewGuid(), Product = product, Quantity = quantity };
            this.order.RequiredBinWidth += product.CalculateBinWidth(quantity);
            this.order.OrderProducts.Add(orderProduct);
        }

        public Order Build()
        {
            return this.order ?? new Order();
        }
    }
}
