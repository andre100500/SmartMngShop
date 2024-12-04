using Microsoft.EntityFrameworkCore;
using SmartMngShop.Customer.Domain.Models;

namespace SmartMngShop.Customer.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<CustomerUser> Customers { get; set; }
        public DbSet<DateCustomerWork> Works { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
