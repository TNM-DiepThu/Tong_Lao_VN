using ASM_CS4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASM_CS4.Configuration
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Description).HasColumnType("nvarchar(100)");
            builder.Property(p => p.RoleName).HasColumnType("nvarchar(100)");
        }
    }
}
