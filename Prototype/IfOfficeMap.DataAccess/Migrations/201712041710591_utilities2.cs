namespace IfOfficeMap.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class utilities2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Utilities",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        PositiobX = c.Single(nullable: false),
                        PositionY = c.Single(nullable: false),
                        Name = c.String(),
                        PlaceType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Utilities");
        }
    }
}
