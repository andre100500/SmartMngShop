using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SmartMngShop.Customer.Domain.Models;

namespace SmartMngShop.Customer.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<CustomerUser>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CustomerUser> builder)
        {
            builder.Property(customer => customer.FirstName).IsRequired().HasMaxLength(15);
            builder.Property(customer => customer.LastName).IsRequired().HasMaxLength(15);
            builder.Property(customer => customer.Email).IsRequired().HasMaxLength(50);
            builder.Property(customer => customer.RoleCustomer).IsRequired().HasMaxLength(25);
        }
    }
}
