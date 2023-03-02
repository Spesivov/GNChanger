using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;
using SystemTests.Pages;
using TestFramework.Driver;
using TestFramework.Extensions;

namespace SystemTests;

public static class Startup
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();

        services.RunDriverInitializer();
        services.AddScoped<ILoginPage, LoginPage>();
        services.AddScoped<IBlogPage, BlogPage>();
        services.AddScoped<IResourcePage, ResourcePage>();

        services.AddScoped<IDriverFixture, DriverFixture>();
        services.AddScoped<IBrowserDriver, BrowserDriver>();

        return services;
    }

}
