using System.Collections.Generic;
using OfficeMap.Data.Models;

namespace OfficeMap.Business.Models
{
    public class WorkplaceEmployeeSetData
    {
        public int Objectid { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
