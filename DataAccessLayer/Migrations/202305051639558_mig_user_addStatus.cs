namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_user_addStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserStatus");
        }
    }
}
