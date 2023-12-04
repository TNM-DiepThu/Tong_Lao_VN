using ASM_CS4.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ASM_CS4.data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
            
        }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<Bill> bill { get; set; }
        public DbSet<Bill_Detail> bill_Details { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<Cart_Detail> Cart_Details { get; set; }
        public DbSet<Categories> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-RNC4UFP\SQLEXPRESS;Initial Catalog=ShopHocLai;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.
                ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
