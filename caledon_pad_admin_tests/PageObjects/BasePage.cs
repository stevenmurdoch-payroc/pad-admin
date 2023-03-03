using caledon_pad_admin_tests.Drivers;
using caledon_pad_admin_tests.Drivers;
using Microsoft.Playwright;

namespace caledon_pad_admin_tests.PageObjects;

public abstract class BasePage
{
    private readonly LocalBrowserDriver _browserDriver;
    private readonly ConfigurationDriver _configurationDriver;
    private readonly ScenarioContext _scenarioContext;

    private IPage? _page;

    protected BasePage(ScenarioContext scenarioContext, LocalBrowserDriver browserDriver,
        ConfigurationDriver configurationDriver)
    {
        _scenarioContext = scenarioContext;
        _browserDriver = browserDriver;
        _configurationDriver = configurationDriver;
    }

    public IPage Page
    {
        protected get
        {
            if (_page != null) return _page;

            if (_scenarioContext.ContainsKey("Page") && _scenarioContext["Page"] != null)
                _page = (IPage)_scenarioContext["Page"];
            else
                throw new InvalidOperationException(
                    "NavigateAsync must be called or the Page property needs setting directly before accessing");

            return _page;
        }
        set => _page = value;
        
        
    }

    protected abstract string PagePath { get; }

    public async Task NavigateAsync()
    {
        if (_page is null)
        {
            var browserContext = await _browserDriver.CurrentContext;
            _page = await browserContext.NewPageAsync();

            _scenarioContext["Page"] = _page;
        }

        var baseUrl = new Uri(_configurationDriver.Configuration.GetSection("URL")["Base"]);
        var fullUrl = new Uri(baseUrl, PagePath);

        await _page.GotoAsync(fullUrl.ToString());
    }
}
