using Albelli.OrderManager.Domain.Orders;
using System;
using System.Collections.Generic;

namespace Albelli.OrderManager.Application.DTOs
{
    public class OrderDto
    {
        public Guid Id { get; set; }

        public double RequiredBinWidth { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }
    }
}
