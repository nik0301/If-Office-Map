using System.Collections.Generic;
using OfficeMap.Data.Models;

namespace OfficeMap.Business.Models
{
    public class ObjectDetails
    {
        public int ObjectId { get; set; }
        public ObjectType Type { get; set; }
        public List<Detail> Attributes { get; set; }
        public EmployeeDetails EmployeeDetails { get; set; }
        public bool IsSuperUser { get; set; }
    }
}
