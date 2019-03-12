using Microsoft.EntityFrameworkCore;
using User.Api.Model;

namespace User.Api.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }
    }
}