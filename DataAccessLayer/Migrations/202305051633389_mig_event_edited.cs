namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_event_edited : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventDescription", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "EventDescription");
        }
    }
}
