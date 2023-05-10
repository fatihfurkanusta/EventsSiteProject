namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "UserID");
            AddForeignKey("dbo.Events", "UserID", "dbo.Users", "UserID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "UserID", "dbo.Users");
            DropIndex("dbo.Events", new[] { "UserID" });
            DropColumn("dbo.Events", "UserID");
        }
    }
}
