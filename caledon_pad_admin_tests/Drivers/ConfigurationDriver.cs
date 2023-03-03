using Microsoft.Extensions.Configuration;

namespace caledon_pad_admin_tests.Drivers;

public class ConfigurationDriver
{
    private readonly Lazy<IConfiguration> _configurationLazy;

    public ConfigurationDriver()
    {
        _configurationLazy = new Lazy<IConfiguration>(GetConfiguration);
    }

    public IConfiguration Configuration => _configurationLazy.Value;

    private IConfiguration GetConfiguration()
    {
        return new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
    }
}
