using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OfficeMap.Data.Models;

namespace OfficeMap.Data
{
    public class UnitRepo : AbstractBaseRepository<Unit, string>
    {
        public UnitRepo(DbContextOptions options) : base(options)
        {
        }

        public virtual List<Unit> GetUnits(int floorId)
        {
            using (var db = new OfficeMapDbContext(Options))
            {
                return (from o in db.Objects
                        join employee in db.Employees on o.EmployeeId equals employee.Id
                        join unit in db.Units on employee.UnitId equals unit.Id
                        where o.FloorId == floorId
                        select unit)
                    .Distinct()
                    .ToList();
            }
        }
    }
}
