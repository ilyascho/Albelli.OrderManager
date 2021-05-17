using Albelli.OrderManager.Domain.Orders;
using Albelli.OrderManager.Domain.Products;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;


namespace Albelli.OrderManager.Application.Common.Interfaces
{
    public interface IOrderDbContext
    {
        DbSet<Order> Orders { get; set; }

        DbSet<OrderProduct> OrderProducts { get; set; }

        DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
