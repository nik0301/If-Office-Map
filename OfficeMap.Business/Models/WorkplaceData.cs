using System.Collections.Generic;
using OfficeMap.Data.Models;

namespace OfficeMap.Business.Models
{
    public class WorkplaceData
    {
        public int ObjectId { get; set; }
        public List<WorkplaceChange> WorkplaceChanges { get; set; }
        public bool IsSuperUser { get; set; }
        public bool IsEmployeesWorkplace { get; set; }
        public bool IsFreeWorkplace { get; set; }
    }
}
