namespace IfOfficeMap.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blobs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "BlobName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "BlobName");
        }
    }
}
