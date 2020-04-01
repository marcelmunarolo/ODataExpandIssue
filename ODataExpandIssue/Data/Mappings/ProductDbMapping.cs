using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ODataExpandIssue.Model;

namespace ODataExpandIssue.Data.Mappings
{
    public class ProductDbMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(t => t.Category)
                .WithMany(s => s.Products)
                .HasForeignKey(s => s.Category_Id)
                .IsRequired(false);

            builder.HasMany(t => t.ProductsSold)
                .WithOne(s => s.Product)
                .HasForeignKey(s => s.Product_Id)
                .IsRequired(false);
        }
    }
}