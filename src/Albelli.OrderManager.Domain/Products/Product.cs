using Albelli.OrderManager.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Albelli.OrderManager.Domain.Products
{
    public abstract class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public ProductType ProductType { get; set; }
        public abstract decimal PackageWidth { get; }

        public virtual decimal CalculateBinWidth(int quantity)
        {
            return quantity * PackageWidth;
        }
    }

}
