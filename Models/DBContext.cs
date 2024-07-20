using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Foodie.Models;
    

namespace Foodie.Models
{
    public class FoodieDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public FoodieDBContext(DbContextOptions<FoodieDBContext> options, IConfiguration configuration) : base(options)
        { Configuration = configuration; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("CustomerDataService");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Restaurant> Restaurants { get; set; } = null!;
        public DbSet<Address> Address { get; set; } = null!;
    }
}
