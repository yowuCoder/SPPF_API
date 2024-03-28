using SPPF_API.Background;

namespace SPPF_API.Middleware
{
    public static class HostExtension
    {
        public static void ConfigurationHostService(this IServiceCollection services)
        {
            services.AddHostedService<ConnectionState>();
        }
    }
}
