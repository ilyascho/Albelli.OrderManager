using Albelli.OrderManager.Domain.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Albelli.OrderManager.Application.DTOs
{
    public class OrderProductDto
    {
        public ProductType ProductType { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        [DefaultValue(1)]
        public int Quantity { get; set; }
    }
}
