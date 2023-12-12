using advanded_csharp_database.Models;
using Microsoft.EntityFrameworkCore;

namespace advanded_csharp_database
{
    public class DataDbContext : DbContext
    {
        public DbSet<Product>? Products { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Cart>? carts { get; set; }
        public DbSet<Order>? orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=sql.bsite.net\\MSSQL2016;Database=ghddhhg_Ghddhhg;User Id=ghddhhg_Ghddhhg;Password=123456;Trusted_Connection=False;");
        }
    }
}