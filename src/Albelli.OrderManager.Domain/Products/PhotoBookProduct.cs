using Albelli.OrderManager.Domain.Enums;

namespace Albelli.OrderManager.Domain.Products
{
    public class PhotoBookProduct : Product
    {
        public override decimal PackageWidth => 19;

        public PhotoBookProduct(ProductType productType)
        {
            this.ProductType = productType;
        }

        public PhotoBookProduct()
        {
        }
    }
}
