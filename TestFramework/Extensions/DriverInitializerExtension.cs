using Microsoft.Extensions.DependencyInjection;
using TestFramework.Settings;
using Microsoft.Extensions.Configuration;

namespace TestFramework.Extensions;
public static class DriverInitializerExtension
{
    public static IServiceCollection RunDriverInitializer(
        this IServiceCollection services)
    {
        services.AddSingleton(ReadConfig());

        return services;
    }

    private static TestSettings ReadConfig()
    {
        var test = AppDomain.CurrentDomain.BaseDirectory;
        var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();

        var section = config.GetSection(nameof(TestSettings));

        var settings = section.Get<TestSettings>() ?? throw new Exception("Setting deserialized incorrectly");

        return settings;
    }

}
