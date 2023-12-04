using ASM_CS4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ASM_CS4.Configuration
{
    public class CartConfig : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Description).HasColumnType("nvarchar(1000)");

            // Thiết lập mối quan hệ một-một giữa Cart và User
            builder
                .HasOne(c => c.User) // Cart có một User
                .WithOne(u => u.Cart) // User có một Cart
                .HasForeignKey<Cart>(c => c.UserId);

        }
    }
}
