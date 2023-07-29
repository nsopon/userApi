using Microsoft.EntityFrameworkCore;
using userApi.Model;

namespace userApi.Data
{
    public class UserApiDbContext : DbContext
    {
        public UserApiDbContext(DbContextOptions<UserApiDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
