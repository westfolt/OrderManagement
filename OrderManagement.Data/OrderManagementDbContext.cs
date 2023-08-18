using Microsoft.EntityFrameworkCore;
using OrderManagement.Data.Configuration;
using OrderManagement.Data.Entities;

namespace OrderManagement.Data
{
    public class OrderManagementDbContext : DbContext
    {
        public OrderManagementDbContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomersConfiguration());
            modelBuilder.ApplyConfiguration(new OrdersConfiguration());
        }

        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Order>? Orders { get; set; }
    }
}
