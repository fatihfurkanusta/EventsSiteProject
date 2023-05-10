namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migaddAllowEventQuota : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AllowEvents", "AllowEventQuota", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AllowEvents", "AllowEventQuota");
        }
    }
}
