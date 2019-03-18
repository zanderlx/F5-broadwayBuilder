using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccessLayer
{
    public class BroadwayBuilderContext : DbContext
    {
        public BroadwayBuilderContext(): base("name=BroadwayBuilder")
        {
            // Todo: will want to remove this once we start persiting data as this will cause our data to be lost when changes to models occur
            //Database.SetInitializer<BroadwayBuilderContext>(new DropCreateDatabaseIfModelChanges<BroadwayBuilderContext>());
        }

        //Creating property on db context
        //Allows to access table in db
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<TheaterJobPosting> TheaterJobPostings { get; set; }
        public DbSet<ProductionJobPosting> ProductionJobPostings { get; set; }
        public DbSet<ProductionDateTime> ProductionDateTimes { get; set; }
    }
}
