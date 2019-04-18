namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TheaterJobPostings", "JobType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TheaterJobPostings", "JobType");
        }
    }
}
