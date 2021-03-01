using Microsoft.Extensions.DependencyInjection;

namespace OfficeMap.Lync
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<LyncData>();
        }
    }
}
