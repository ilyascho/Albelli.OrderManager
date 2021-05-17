using Albelli.OrderManager.Domain.Enums;

namespace Albelli.OrderManager.Domain.Products
{
    public class CalendarProduct : Product
    {

        public override decimal PackageWidth => 10;

        public CalendarProduct(ProductType productType)
        {
            this.ProductType = productType;
        }

        public CalendarProduct()
        {
        }
    }
}
