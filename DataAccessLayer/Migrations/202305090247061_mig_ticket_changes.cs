namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_ticket_changes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "Ticket_TicketId", "dbo.Tickets");
            DropIndex("dbo.Events", new[] { "Ticket_TicketId" });
            AddColumn("dbo.Tickets", "EventID", c => c.Int());
            CreateIndex("dbo.Tickets", "EventID");
            AddForeignKey("dbo.Tickets", "EventID", "dbo.Events", "EventId");
            DropColumn("dbo.Events", "Ticket_TicketId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Ticket_TicketId", c => c.Int());
            DropForeignKey("dbo.Tickets", "EventID", "dbo.Events");
            DropIndex("dbo.Tickets", new[] { "EventID" });
            DropColumn("dbo.Tickets", "EventID");
            CreateIndex("dbo.Events", "Ticket_TicketId");
            AddForeignKey("dbo.Events", "Ticket_TicketId", "dbo.Tickets", "TicketId");
        }
    }
}
