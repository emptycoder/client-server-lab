using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Services.DataServerService
{
    public static class DataServerExtension
    {
        public static void AddDataServer(this IServiceCollection services, IConfiguration configuration)
        {
            IDataServer dataServer = new DataServer(configuration.GetSection("DataServerUrl").Get<string>());
            services.AddSingleton(dataServer);
        }
    }
}
