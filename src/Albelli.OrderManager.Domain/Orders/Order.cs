using Albelli.OrderManager.Domain.Common;
using System;
using System.Collections.Generic;

namespace Albelli.OrderManager.Domain.Orders
{
    public class Order : Entity<Guid>
    {
        public decimal RequiredBinWidth { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }

        public Order()
        {
            this.Id = Guid.NewGuid();
            this.OrderProducts = new List<OrderProduct>();
        }
    }
}
