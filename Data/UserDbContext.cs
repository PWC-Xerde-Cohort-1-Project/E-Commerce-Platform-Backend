using eCommerce.Model;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Data
{
    public class UserDbContext : DbContext 
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
    }
}
