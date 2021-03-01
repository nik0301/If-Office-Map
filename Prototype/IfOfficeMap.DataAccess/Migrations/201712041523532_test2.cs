namespace IfOfficeMap.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Workplaces", "ID", "dbo.Employees");
            DropIndex("dbo.Workplaces", new[] { "ID" });
            AddColumn("dbo.Employees", "WorkplaceID", c => c.Guid());
            AddColumn("dbo.Workplaces", "EmployeeID", c => c.Guid());
            CreateIndex("dbo.Employees", "WorkplaceID");
            CreateIndex("dbo.Workplaces", "EmployeeID");
            AddForeignKey("dbo.Employees", "WorkplaceID", "dbo.Workplaces", "ID");
            AddForeignKey("dbo.Workplaces", "EmployeeID", "dbo.Employees", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workplaces", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Employees", "WorkplaceID", "dbo.Workplaces");
            DropIndex("dbo.Workplaces", new[] { "EmployeeID" });
            DropIndex("dbo.Employees", new[] { "WorkplaceID" });
            DropColumn("dbo.Workplaces", "EmployeeID");
            DropColumn("dbo.Employees", "WorkplaceID");
            CreateIndex("dbo.Workplaces", "ID");
            AddForeignKey("dbo.Workplaces", "ID", "dbo.Employees", "ID");
        }
    }
}
