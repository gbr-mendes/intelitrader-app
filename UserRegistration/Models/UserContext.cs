using Microsoft.EntityFrameworkCore;

namespace UserRegistration.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public UserContext(DbContextOptions options) : base(options) { }
    }
}