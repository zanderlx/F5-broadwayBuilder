using System.Data.Entity;

namespace DataAccessLayer
{
    public class BroadwayBuilderContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }

        // The constructor that links the context to the database
        public BroadwayBuilderContext(): base("name=BroadwayBuilder")
        {

        }
    }
}
