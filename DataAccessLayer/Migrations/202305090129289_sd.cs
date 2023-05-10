namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        TicketNumber = c.String(maxLength: 50),
                        UserID = c.Int(nullable: false),
                        EventStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            AddColumn("dbo.Events", "Ticket_TicketId", c => c.Int());
            CreateIndex("dbo.Events", "Ticket_TicketId");
            AddForeignKey("dbo.Events", "Ticket_TicketId", "dbo.Tickets", "TicketId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "UserID", "dbo.Users");
            DropForeignKey("dbo.Events", "Ticket_TicketId", "dbo.Tickets");
            DropIndex("dbo.Tickets", new[] { "UserID" });
            DropIndex("dbo.Events", new[] { "Ticket_TicketId" });
            DropColumn("dbo.Events", "Ticket_TicketId");
            DropTable("dbo.Tickets");
        }
    }
}
