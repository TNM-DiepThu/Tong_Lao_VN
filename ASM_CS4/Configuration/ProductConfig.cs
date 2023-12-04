using ASM_CS4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASM_CS4.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).HasColumnType("nvarchar(100)");
            builder.Property(p => p.Price).HasColumnType("decimal");
            builder.Property(p => p.Quantity).HasColumnType("int");
            builder.Property(p => p.Status).HasColumnType("int");
            builder.Property(p => p.Description).HasColumnType("nvarchar(100)");
            builder.Property(p => p.Supplier).HasColumnType("nvarchar(100)");
            builder.Property(p => p.UrlImage).HasColumnType("nvarchar(100)");
            builder.Property(p => p.CreateDate).HasColumnType("DateTime");

            builder.HasOne(x => x.Categories).WithMany(p => p.products).HasForeignKey(x => x.idCat).HasConstraintName("FK_Categories_Product");

        }
    }
}
