using Microsoft.EntityFrameworkCore;
using OfficeMap.Data.Models;

namespace OfficeMap.Data
{
    public class SvgTypeRepo : AbstractBaseRepository<SvgType, string>
    {
        public SvgTypeRepo(DbContextOptions options) : base(options)
        {
        }
    }
}
