using System.Linq;
using Microsoft.EntityFrameworkCore;
using OfficeMap.Data.Models;

namespace OfficeMap.Data
{
    public class EmployeeRepo : AbstractBaseRepository<Employee, int>
    {
        public EmployeeRepo(DbContextOptions options) : base(options)
        {
        }

        public virtual Unit GetUnit(int id)
        {
            using (var db = new OfficeMapDbContext(Options))
            {
                return (from emp in db.Employees
                        join unit in db.Units on emp.UnitId equals unit.Id
                        where emp.Id == id
                        select unit)
                        .FirstOrDefault();
            }
        }

        public virtual Employee GetByUId(string userIdentity)
        {
            using (var db = new OfficeMapDbContext(Options))
            {
                return db.Employees
                        .Include(e => e.Objects)
                        .FirstOrDefault(e => e.UserIdentity == userIdentity);
            }
        }
    }
}
