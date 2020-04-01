using Microsoft.EntityFrameworkCore;
using ODataExpandIssue.Data.Mappings;
using ODataExpandIssue.Model;

namespace ODataExpandIssue.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomersAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSold> ProductsSold { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryDbMapping());
            modelBuilder.ApplyConfiguration(new ProductDbMapping());
            modelBuilder.ApplyConfiguration(new CustomerDbMapping());
            modelBuilder.ApplyConfiguration(new CustomerAddressDbMapping());
            modelBuilder.ApplyConfiguration(new OrderDbMapping());
            modelBuilder.ApplyConfiguration(new ProductSoldDbMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}