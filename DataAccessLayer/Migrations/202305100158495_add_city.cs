namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_city : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        CityName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CityID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cities");
        }
    }
}
