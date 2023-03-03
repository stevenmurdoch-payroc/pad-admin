using caledon_pad_admin_tests.Drivers;
using FluentAssertions;

namespace caledon_pad_admin_tests.PageObjects;

public class LoginPage : BasePage
{
    private readonly ConfigurationDriver _configurationDriver;

    public LoginPage(ScenarioContext scenarioContext, LocalBrowserDriver browserDriver,
        ConfigurationDriver configurationDriver) :
        base(scenarioContext, browserDriver, configurationDriver)
    {
        _configurationDriver = configurationDriver;
    }
    
    protected override string PagePath => new Uri(_configurationDriver.Configuration.GetSection("URL")["Base"]).ToString();
    
    
    public async Task SetUserName(string username)
    {
        await Page.Locator("body > div > div.login_box > div:nth-child(1) > form > table > tbody > tr:nth-child(1) > td:nth-child(2) > input[type=TEXT]").FillAsync(username);
    }
    
    public async Task SetPassword(string password)
    {
        await Page.Locator("body > div > div.login_box > div:nth-child(1) > form > table > tbody > tr:nth-child(2) > td:nth-child(2) > input[type=PASSWORD]").FillAsync(password);
    }
    
    public async Task ClickPadAdminLogin()
    {
        await Page.Locator("body > div > div.login_box > div:nth-child(1) > form > table > tbody > tr:nth-child(4) > td > input[type=SUBMIT]").ClickAsync();
    }


    public async Task VerfiyLoggedInTransactionLookup()
    {
        Page.Url.Should().Contain("/padpayment/search_payment.cgi");
    }
}