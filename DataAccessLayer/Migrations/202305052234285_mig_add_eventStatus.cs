namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_eventStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "EventStatus");
        }
    }
}
