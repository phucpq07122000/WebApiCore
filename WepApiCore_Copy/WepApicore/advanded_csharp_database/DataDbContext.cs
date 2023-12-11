using advanded_csharp_database.Models;
using Microsoft.EntityFrameworkCore;

namespace advanded_csharp_database
{
    public class DataDbContext : DbContext
    {

        public DbSet<Product>? Products { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Cart>? carts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Data Source=LAPTOP-PDVMP1JL\\SQLEXPRESS;Initial Catalog=Advanded_Csharp;Integrated Security=True");
        }
    }
}