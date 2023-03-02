using TestFramework.Driver;
using Microsoft.Extensions.DependencyInjection;

namespace TestFramework.IoC
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IDriverFixture, DriverFixture>();
            services.AddScoped<IBrowserDriver, BrowserDriver>();
        }
    }
}
