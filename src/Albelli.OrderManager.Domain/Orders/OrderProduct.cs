using Albelli.OrderManager.Domain.Common;
using Albelli.OrderManager.Domain.Products;
using System;

namespace Albelli.OrderManager.Domain.Orders
{
    public class OrderProduct : Entity<Guid>
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }

        public OrderProduct()
        { 
        }
    }
}
