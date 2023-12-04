using ASM_CS4.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ASM_CS4.Configuration
{
    public class Cart_DetailConfig : IEntityTypeConfiguration<Cart_Detail>
    {
        public void Configure(EntityTypeBuilder<Cart_Detail> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.soluong).HasColumnType("int");

            builder.Property(p => p.status).HasColumnType("int");
            builder.HasOne(x => x.Cart).WithMany(p => p.CartDetails).HasForeignKey(x => x.IdCart).HasConstraintName("FK_Cart_User");
            builder.HasOne(x => x.Product).WithMany(p => p.CartDetails).HasForeignKey(x => x.IdSp).HasConstraintName("FK_Product_CartDetail");
        }
    
    }
}
