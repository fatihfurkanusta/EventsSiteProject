namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_eventloc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventLoc", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "EventLoc");
        }
    }
}
