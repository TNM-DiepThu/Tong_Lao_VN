using ASM_CS4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASM_CS4.Configuration
{
    public class Bill_DetailConfig : IEntityTypeConfiguration<Bill_Detail>
    {
        public void Configure(EntityTypeBuilder<Bill_Detail> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)"); 
            builder.Property(c => c.Quantity).HasColumnType("int");
            builder.HasOne(x => x.Bill).WithMany(y => y.BillDetails).HasForeignKey(c => c.IDHD);
            builder.HasOne(x => x.Product).WithMany(y => y.BillDetails).HasForeignKey(c => c.IDSP);
        }
    }
}
