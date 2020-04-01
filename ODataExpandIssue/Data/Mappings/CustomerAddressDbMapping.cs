using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ODataExpandIssue.Model;

namespace ODataExpandIssue.Data.Mappings
{
    public class CustomerAddressDbMapping : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> builder)
        {
            builder.HasOne(t => t.Customer)
                .WithMany(s => s.CustomerAddresses)
                .HasForeignKey(s => s.CustomerId)
                .IsRequired(false);
        }
    }
}