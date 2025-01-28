using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartMngShop.Customer.Domain.Models;

namespace SmartMngShop.Customer.Data.Configutrations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<CustomerUser>
    {
        public void Configure(EntityTypeBuilder<CustomerUser> builder)
        {
            builder.Property(customer => customer.FirstName).IsRequired()
                .HasMaxLength(70);
            builder.Property(customer => customer.LastName).IsRequired()
                .HasMaxLength(70);
            builder.Property(customer => customer.Email).IsRequired()
                .HasMaxLength(30);
        }
    }
}
