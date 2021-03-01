using System.Linq;
using Microsoft.EntityFrameworkCore;
using OfficeMap.Data.Models;

namespace OfficeMap.Data
{
    public class FloorRepo : AbstractBaseRepository<Floor, int>
    {
        public FloorRepo(DbContextOptions options) : base(options)
        {
        }

        public virtual int? GetUsersFloorId(string userIdentity)
        {
            using (var db = new OfficeMapDbContext(Options))
            {
                return (from employee in db.Employees
                        join dbObject in db.Objects on employee.Id equals dbObject.EmployeeId
                        where employee.UserIdentity == userIdentity
                        select dbObject.FloorId)
                    .FirstOrDefault();
            }
        }
    }
}
