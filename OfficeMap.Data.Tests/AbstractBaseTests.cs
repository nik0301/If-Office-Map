using Microsoft.EntityFrameworkCore;

namespace OfficeMap.Data.Tests
{
    public class AbstractBaseTests
    {     
        protected  DbContextOptions GetDbOptions()
        {
            var builder = new DbContextOptionsBuilder();
            //builder.UseSqlServer("Server=swb32051\\db_st01;Database=JuniorSchool_OfficeMap_AT;User ID=JuniorSchool_admin;Password=B8z5QaAMDe;MultipleActiveResultSets=true");
            builder.UseSqlServer("Server=.\\SQLEXPRESS;Database=OfficeMapTests;Trusted_Connection=True;MultipleActiveResultSets=true");
            return builder.Options;
        }
    }
}
