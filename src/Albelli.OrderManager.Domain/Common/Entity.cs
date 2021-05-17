namespace Albelli.OrderManager.Domain.Common
{
    public abstract class Entity<TId>
    {
        public virtual TId Id { get; set; }
    }
}
