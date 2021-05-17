using Albelli.OrderManager.Domain.Enums;

namespace Albelli.OrderManager.Domain.Products
{
    public class CardsProduct : Product
    {
        public override decimal PackageWidth => 4.7M;

        public CardsProduct(ProductType productType)
        {
            this.ProductType = productType;
        }

        public CardsProduct()
        {
        }
    }
}
