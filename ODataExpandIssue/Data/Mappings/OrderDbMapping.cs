using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ODataExpandIssue.Model;

namespace ODataExpandIssue.Data.Mappings
{
    public class OrderDbMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(t => t.Customer)
                .WithMany(s => s.Orders)
                .HasForeignKey(s => s.Customer_Id)
                .IsRequired(false);

            builder.HasMany(t => t.ProductsSold)
                .WithOne(s => s.Order)
                .HasForeignKey(s => s.Order_Id)
                .IsRequired(false);
        }
    }
}