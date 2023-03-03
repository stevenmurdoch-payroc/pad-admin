using Microsoft.Playwright;
using SpecFlow.Actions.Playwright;

namespace caledon_pad_admin_tests.Drivers;

public class LocalBrowserDriver
{
    private readonly ScenarioContext _scenarioContext;
    private readonly BrowserDriver _browserDriver;
    private readonly AsyncLazy<IBrowserContext> _currentBrowserContextLazy;

    public LocalBrowserDriver(ScenarioContext scenarioContext, BrowserDriver browserDriver)
    {
        _scenarioContext = scenarioContext;
        _browserDriver = browserDriver;
        _currentBrowserContextLazy = new AsyncLazy<IBrowserContext>(InitializeContext);
    }

    //This is the property that will provide the browser context.
    public Task<IBrowserContext> CurrentContext => _currentBrowserContextLazy.Value;

    private async Task<IBrowserContext> InitializeContext()
    {
        var browser = await _browserDriver.Current;

        await browser.NewContextAsync(new BrowserNewContextOptions
        {
            IgnoreHTTPSErrors = true
        });

        return browser.Contexts.Last();
    }
}