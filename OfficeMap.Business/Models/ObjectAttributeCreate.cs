using System.Collections.Generic;
using OfficeMap.Data.Models;

namespace OfficeMap.Business.Models
{
    public class ObjectAttributeCreate
    {
        public List<Attribute> Attributes { get; set; }
        public int ObjectId { get; set; }
    }
}
