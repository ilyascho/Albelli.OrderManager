using Albelli.OrderManager.Domain.Enums;

namespace Albelli.OrderManager.Domain.Products
{
    public class CanvasProduct : Product
    {
        public override decimal PackageWidth => 16;

        public CanvasProduct(ProductType productType)
        {
            this.ProductType = productType;
        }

        public CanvasProduct()
        {
        }
    }
}
