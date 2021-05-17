using System;

namespace Albelli.OrderManager.Application.DTOs
{
    public class OrderResponseDto
    {
        public Guid Id { get; set; }
        public decimal RequiredBinWidth { get; set; }
    }
}
