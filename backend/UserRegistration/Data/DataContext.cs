using Microsoft.EntityFrameworkCore;
using UserRegistration.Models;

namespace UserRegistration.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DataContext(DbContextOptions options) : base(options) { }
    }
}