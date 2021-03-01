using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OfficeMap.Data.Models;

namespace OfficeMap.Data
{
    public class ObjectAttributeRepo : AbstractBaseRepository<ObjectAttribute, int>
    {
        public ObjectAttributeRepo(DbContextOptions options) : base(options)
        {
        }

        public virtual List<ObjectAttribute> GetObjectAttributes(int objectId)
        {
            using (var db = new OfficeMapDbContext(Options))
            {
                return db.ObjectAttributes
                    .Include(oa => oa.Attribute)
                    .Where(oa => oa.ObjectId == objectId)
                    .ToList();
            }
        }
    }
}
