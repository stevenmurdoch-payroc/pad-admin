using caledon_pad_admin_tests.Drivers;
using caledon_pad_admin_tests.PageObjects;

namespace caledon_pad_admin_tests;

[Binding]
public class LoginSteps
{
        
    private readonly ConfigurationDriver _configurationDriver;
    private readonly LoginPage _page;

    public LoginSteps(ConfigurationDriver configurationDriver, LoginPage page)
    {
        _configurationDriver = configurationDriver;
        _page = page;
    }

    
    [Given(@"a logged out user")]
    public async Task GivenALoggedOutUser()
    {
        await _page.NavigateAsync();
    }

    [Given(@"the user logs in with valid credentials")]
    [When(@"the user logs in with valid credentials")]
    public async Task WhenTheUserLogsInWithCredentials()
    {
        await _page.NavigateAsync();
        await _page.SetUserName(_configurationDriver.Configuration.GetSection("Credentials")["User"]);
        await _page.SetPassword(_configurationDriver.Configuration.GetSection("Credentials")["Password"]);
        await _page.ClickPadAdminLogin();
    }

    [Then(@"they log in successfully")]
    public async Task ThenTheyLogInSuccessfully()
    {
        await _page.VerfiyLoggedInTransactionLookup();
    }
}