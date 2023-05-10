namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_allowEvent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AllowEvents",
                c => new
                    {
                        AllowEventId = c.Int(nullable: false, identity: true),
                        AllowEventName = c.String(maxLength: 50),
                        AllowEventLoc = c.String(maxLength: 50),
                        AllowEventDescription = c.String(maxLength: 200),
                        AllowEventDate = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        AllowEventStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AllowEventId)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AllowEvents", "UserID", "dbo.Users");
            DropForeignKey("dbo.AllowEvents", "CategoryID", "dbo.Categories");
            DropIndex("dbo.AllowEvents", new[] { "CategoryID" });
            DropIndex("dbo.AllowEvents", new[] { "UserID" });
            DropTable("dbo.AllowEvents");
        }
    }
}
