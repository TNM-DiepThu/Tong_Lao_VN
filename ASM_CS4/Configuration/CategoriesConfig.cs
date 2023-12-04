using ASM_CS4.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ASM_CS4.Configuration
{
    public class CategoriesConfig : IEntityTypeConfiguration<Categories>
    {
        public void Configure(EntityTypeBuilder<Categories> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.name).HasColumnType("nvarchar(100)");
            builder.Property(p => p.description).HasColumnType("nvarchar(1000)");
        }
    }
}
