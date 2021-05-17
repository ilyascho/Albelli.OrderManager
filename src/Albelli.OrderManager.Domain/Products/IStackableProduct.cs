namespace Albelli.OrderManager.Domain.Products
{
    public interface IStackableProduct
    {
        int StackLimit { get; }
    }
}
