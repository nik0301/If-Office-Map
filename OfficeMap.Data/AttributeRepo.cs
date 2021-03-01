using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OfficeMap.Data.Models;

namespace OfficeMap.Data
{
    public class AttributeRepo : AbstractBaseRepository<Attribute, string>
    {
        public AttributeRepo(DbContextOptions options) : base(options)
        {
        }

        public virtual List<Attribute> GetNonExistingForObject(int id)
        {
            using (var db = new OfficeMapDbContext(Options))
            {
                return (from attributes in db.Attributes
                        where !(from objectAttributes in db.ObjectAttributes
                                where objectAttributes.ObjectId == id
                                select objectAttributes.AttributeId).Contains(attributes.Id)
                        select attributes)
                    .OrderBy(a => a.Name)
                    .ToList();
            }
        }
    }
}
