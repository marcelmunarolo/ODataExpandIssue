using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ODataExpandIssue.Model;

namespace ODataExpandIssue.Data.Mappings
{
    public class ProductSoldDbMapping : IEntityTypeConfiguration<ProductSold>
    {
        public void Configure(EntityTypeBuilder<ProductSold> builder)
        {
            builder.HasOne(t => t.Order)
                .WithMany(s => s.ProductsSold)
                .HasForeignKey(s => s.Order_Id)
                .IsRequired(false);

            builder.HasOne(t => t.Product)
                .WithMany(s => s.ProductsSold)
                .HasForeignKey(s => s.Product_Id)
                .IsRequired(false);
        }
    }
}