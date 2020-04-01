using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ODataExpandIssue.Model;

namespace ODataExpandIssue.Data.Mappings
{
    public class CategoryDbMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(t => t.Products)
                .WithOne(s => s.Category)
                .HasForeignKey(s => s.Category_Id)
                .IsRequired(false);
        }
    }
}