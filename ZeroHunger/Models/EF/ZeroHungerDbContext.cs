using System.Data.Entity;

namespace ZeroHunger.Models.EF
{
    public class ZeroHungerDbContext : DbContext
    {
        public DbSet<Access> Accesses { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }
    }
}