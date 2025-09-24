using Microsoft.EntityFrameworkCore;
using WatchAlonge.Models;

namespace WatchAlonge.Data 
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
