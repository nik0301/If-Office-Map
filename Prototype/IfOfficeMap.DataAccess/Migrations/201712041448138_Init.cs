namespace IfOfficeMap.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Workplaces",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Position = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workplaces", "ID", "dbo.Employees");
            DropIndex("dbo.Workplaces", new[] { "ID" });
            DropTable("dbo.Workplaces");
            DropTable("dbo.Employees");
        }
    }
}
