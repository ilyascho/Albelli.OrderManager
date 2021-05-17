using Albelli.OrderManager.Domain.Products;

namespace Albelli.OrderManager.Application.Common.Interfaces
{
    public interface IProductFactory
    {
        Product Create();
    }
}
