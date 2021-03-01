namespace IfOfficeMap.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workplaces", "PositionX", c => c.Single(nullable: false));
            AddColumn("dbo.Workplaces", "PositionY", c => c.Single(nullable: false));
            AddColumn("dbo.Workplaces", "Data", c => c.String());
            DropColumn("dbo.Workplaces", "Position");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workplaces", "Position", c => c.String());
            DropColumn("dbo.Workplaces", "Data");
            DropColumn("dbo.Workplaces", "PositionY");
            DropColumn("dbo.Workplaces", "PositionX");
        }
    }
}
