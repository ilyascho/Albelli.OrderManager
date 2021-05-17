using Albelli.OrderManager.Application.Common.Interfaces;
using Albelli.OrderManager.Domain.Enums;
using Albelli.OrderManager.Domain.Products;

namespace Albelli.OrderManager.Application.Factories
{
    public class MugFactory : IProductFactory
    {
        public Product Create() => new MugProduct() { ProductType = ProductType.Mug};
    }
}
