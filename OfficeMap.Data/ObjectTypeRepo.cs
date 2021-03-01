using Microsoft.EntityFrameworkCore;
using OfficeMap.Data.Models;

namespace OfficeMap.Data
{
    public class ObjectTypeRepo : AbstractBaseRepository<ObjectType, string>
    {
        public ObjectTypeRepo(DbContextOptions options) : base(options)
        {
        }
    }
}
