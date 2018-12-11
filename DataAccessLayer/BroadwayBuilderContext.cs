using System.Data.Entity;

namespace DataAccessLayer
{
    public class BroadwayBuilderContext : DbContext
    {
        // The constructor that links the context to the database
        public BroadwayBuilderContext(): base("name=BroadwayBuilder")
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<Permission> permissions { get; set; }
        public DbSet<Role> roles { get; set; }
    }
}
