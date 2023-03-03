using caledon_pad_admin_tests.Drivers;

namespace caledon_pad_admin_tests.Helpers;

public class ScreenshotHelper
{
    private readonly ConfigurationDriver _configurationDriver;

    public ScreenshotHelper(ConfigurationDriver configurationDriver)
    {
        _configurationDriver = configurationDriver;
    }

    public string ScreenShotDirPath()
    {
        return Path.Combine(PathHelper.GetBasePath(), _configurationDriver.Configuration.GetSection("Screenshot")["Path"]);
    }

    public string ScreenShotFilePath(string filename)
    {
        return Path.Combine(ScreenShotDirPath(), filename);
    }
}
