using ASM_CS4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASM_CS4.Configuration
{
    public class BillConfig : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("HoaDon");
            builder.HasKey(x => x.Id); 
            builder.Property(x => x.CreateDate).HasColumnType("Datetime").IsRequired();
            builder.Property(x => x.Status).HasColumnType("int").IsRequired(); 

        }
    }
}
