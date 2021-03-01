namespace IfOfficeMap.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class missing3 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employees", name: "Workplace_ID", newName: "WorkplaceID");
            RenameColumn(table: "dbo.Workplaces", name: "Employee_ID", newName: "EmployeeID");
            RenameIndex(table: "dbo.Employees", name: "IX_Workplace_ID", newName: "IX_WorkplaceID");
            RenameIndex(table: "dbo.Workplaces", name: "IX_Employee_ID", newName: "IX_EmployeeID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Workplaces", name: "IX_EmployeeID", newName: "IX_Employee_ID");
            RenameIndex(table: "dbo.Employees", name: "IX_WorkplaceID", newName: "IX_Workplace_ID");
            RenameColumn(table: "dbo.Workplaces", name: "EmployeeID", newName: "Employee_ID");
            RenameColumn(table: "dbo.Employees", name: "WorkplaceID", newName: "Workplace_ID");
        }
    }
}
