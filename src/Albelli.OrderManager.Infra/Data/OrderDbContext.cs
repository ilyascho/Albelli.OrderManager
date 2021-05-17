using Albelli.OrderManager.Application.Common.Interfaces;
using Albelli.OrderManager.Domain.Orders;
using Albelli.OrderManager.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace Albelli.OrderManager.Infra.Database
{
    public class OrderDbContext : DbContext, IOrderDbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<PhotoBookProduct> PhotoBookProduct { get; set; }

        public DbSet<CalendarProduct> CalendarProduct { get; set; }

        public DbSet<CanvasProduct> CanvasProduct { get; set; }

        public DbSet<CardsProduct> CardsProduct { get; set; }

        public DbSet<MugProduct> MugProduct { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>();
            modelBuilder.Entity<PhotoBookProduct>();
            modelBuilder.Entity<CalendarProduct>();
            modelBuilder.Entity<CanvasProduct>();
            modelBuilder.Entity<CardsProduct>();
            modelBuilder.Entity<MugProduct>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
