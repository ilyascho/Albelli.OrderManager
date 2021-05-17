using Albelli.OrderManager.Domain.Enums;
using System;

namespace Albelli.OrderManager.Domain.Products
{
    public class MugProduct : Product, IStackableProduct
    {
        public override decimal PackageWidth => 94;

        public int StackLimit => 4;

        public MugProduct(ProductType productType)
        {
            this.ProductType = productType;
        }

        public MugProduct()
        {
        }

        public override decimal CalculateBinWidth(int quantity)
        {
            return Math.Ceiling((decimal)quantity / StackLimit) * PackageWidth;
        }
    }
}
