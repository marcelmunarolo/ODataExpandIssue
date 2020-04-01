using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ODataExpandIssue.Model;

namespace ODataExpandIssue.Data.Mappings
{
    public class CustomerDbMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasMany(t => t.CustomerAddresses)
                .WithOne(s => s.Customer)
                .HasForeignKey(s => s.CustomerId)
                .IsRequired(false);

            builder.HasMany(t => t.Orders)
                .WithOne(s => s.Customer)
                .HasForeignKey(s => s.Customer_Id)
                .IsRequired(false);
        }
    }
}