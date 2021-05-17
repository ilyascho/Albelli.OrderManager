using Albelli.OrderManager.Application.Common.Interfaces;
using Albelli.OrderManager.Domain.Enums;
using Albelli.OrderManager.Domain.Products;

namespace Albelli.OrderManager.Application.Factories
{
    public class CardsFactory : IProductFactory
    {
        public Product Create() => new CardsProduct() { ProductType = ProductType.Cards};
    }
}
