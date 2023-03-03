using caledon_pad_admin_tests.Drivers;
using caledon_pad_admin_tests.PageObjects;

namespace caledon_pad_admin_tests;

[Binding]
public class NavBarSteps
{
    
        
    private readonly ConfigurationDriver _configurationDriver;
    private readonly NavBarPage _navBarPage;
    private readonly LocalBrowserDriver _browserDriver;
    private readonly ScenarioContext _scenarioContext;

    public NavBarSteps(ConfigurationDriver configurationDriver, NavBarPage navBarPage, LocalBrowserDriver browserDriver, ScenarioContext scenarioContext)
    {
        _configurationDriver = configurationDriver;
        _navBarPage = navBarPage;
        _browserDriver = browserDriver;
        _scenarioContext = scenarioContext;
        
    }
    
    [When(@"the user navigates to the Add Company Page")]
    public async Task WhenTheUserNavigatesToTheAddCompanyPage()
    {
        await _navBarPage.ClickCompanyMenuOption();
        await _navBarPage.ClickAddCompanyOption();
    }

    [When(@"the user navigates to the Edit Company Page")]
    public async Task WhenTheUserNavigatesToTheEditCompanyPage()
    {
        await _navBarPage.ClickCompanyMenuOption();
        await _navBarPage.ClickEditCompanyOption();
    }

    [When(@"the user navigates to the Add Merchant Page")]
    public async Task WhenTheUserNavigatesToTheAddMerchantPage()
    {
        await _navBarPage.ClickMerchantMenuOption();
        await _navBarPage.ClickAddMerchantOption();
    }
}