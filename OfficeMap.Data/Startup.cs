using Microsoft.Extensions.DependencyInjection;

namespace OfficeMap.Data
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<FloorRepo>();
            services.AddSingleton<AttributeRepo>();
            services.AddSingleton<ObjectAttributeRepo>();
            services.AddSingleton<SvgTypeRepo>();
            services.AddSingleton<ObjectRepo>();
            services.AddSingleton<EmployeeRepo>();
            services.AddSingleton<ObjectTypeRepo>();
            services.AddSingleton<UnitRepo>();
            services.AddSingleton<WorkplaceChangeRepo>();
        }
    }
}
