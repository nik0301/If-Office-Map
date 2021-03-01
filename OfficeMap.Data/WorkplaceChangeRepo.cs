using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OfficeMap.Data.Models;

namespace OfficeMap.Data
{
    public class WorkplaceChangeRepo:AbstractBaseRepository<WorkplaceChange, int>
    {
        public WorkplaceChangeRepo(DbContextOptions options) : base(options)
        {
        }

        public List<WorkplaceChange> GetByEmployeeId(int employeeId)
        {
            using (var db = new OfficeMapDbContext(Options))
            {
                return db.WorkplacesChanges
                    .Where(w => w.EmployeeId == employeeId)
                    .ToList();
            }
        }

        public virtual List<WorkplaceChange> GetByObjectId(int objectId)
        {
            using (var db = new OfficeMapDbContext(Options))
            {
                return db.WorkplacesChanges
                    .Include(w => w.Employee)
                    .Where(w => w.NewWorkplaceId == objectId && w.ApprovalDate == null)
                    .ToList();
            }
        }
    }
}
