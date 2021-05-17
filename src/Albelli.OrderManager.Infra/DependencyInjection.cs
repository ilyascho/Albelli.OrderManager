using Albelli.OrderManager.Application.Common.Interfaces;
using Albelli.OrderManager.Infra.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Albelli.OrderManager.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraDependencies(this IServiceCollection services)
        {
            services.AddDbContext<OrderDbContext>(options => options.UseInMemoryDatabase(databaseName: "Order"));
            services.AddScoped<IOrderDbContext>(provider => provider.GetService<OrderDbContext>());

            return services;
        }
    }
}
