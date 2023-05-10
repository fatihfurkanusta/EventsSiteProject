namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_user_edit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserEmail", c => c.String(maxLength: 200));
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 20));
            AlterColumn("dbo.Users", "UserEmail", c => c.String(maxLength: 50));
        }
    }
}
