namespace IfOfficeMap.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minorRename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilities", "PositionX", c => c.Single(nullable: false));
            DropColumn("dbo.Utilities", "PositiobX");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Utilities", "PositiobX", c => c.Single(nullable: false));
            DropColumn("dbo.Utilities", "PositionX");
        }
    }
}
