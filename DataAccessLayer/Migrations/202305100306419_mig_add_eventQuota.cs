namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_eventQuota : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventQuota", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "EventQuota");
        }
    }
}
