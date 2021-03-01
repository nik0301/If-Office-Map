using System.Data.Entity.Infrastructure;
using IfOfficeMap.DataAccess.Database;

namespace IfOfficeMap.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IfOfficeMap.DataAccess.DbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            TargetDatabase = new DbConnectionInfo("DefaultConnection");
        }

        protected override void Seed(IfOfficeMap.DataAccess.DbContext context)
        {
            //context.Employee.Add(new Employee()
            //{
            //    Workplace = null,
            //    ID = Guid.NewGuid(),
            //    Email = "andrei.poda@if.lv",
            //    FirstName = "Andrei",
            //    LastName = "Poda"
            //});

            //context.Workplaces.Add(new Workplace()
            //{
            //    Employee = null,
            //    ID =  Guid.NewGuid(),
            //    Data = "",
            //    Note = "Default 1",
            //    PositionX = 129,
            //    PositionY = 165
            //});

            //context.Workplaces.Add(new Workplace()
            //{
            //    Employee = null,
            //    ID = Guid.NewGuid(),
            //    Data = "",
            //    Note = "Default 1",
            //    PositionX = 660,
            //    PositionY = 165
            //});

            //context.Workplaces.AddOrUpdate();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
