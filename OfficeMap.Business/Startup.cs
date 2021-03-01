using Microsoft.Extensions.DependencyInjection;

namespace OfficeMap.Business
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            Data.Startup.ConfigureServices(services);

            Lync.Startup.ConfigureServices(services);

            services.AddSingleton<FloorSwitch>();
            services.AddSingleton<MapDisplay>();
            services.AddSingleton<WorkplaceSwitch>();
            services.AddSingleton<Authorization>();
            services.AddSingleton<LyncDataDisplay>();
            services.AddSingleton<ObjectAttributeData>();
            services.AddSingleton<SuperUserData>();
        }
    }
}
