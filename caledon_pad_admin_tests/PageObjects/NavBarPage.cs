using caledon_pad_admin_tests.Drivers;

namespace caledon_pad_admin_tests.PageObjects;

public class NavBarPage : BasePage
{
    public NavBarPage(ScenarioContext scenarioContext, LocalBrowserDriver browserDriver,
        ConfigurationDriver configurationDriver) : base(scenarioContext, browserDriver, configurationDriver)
    {
    }
    
    protected override string PagePath => "/cgi-bin/padpayment/search_payment.cgi";

    public async Task ClickCompanyMenuOption()
    {
        await Page.ClickAsync("#menu > li:nth-child(1) > a");
    }

    public async Task ClickAddCompanyOption()
    {
        await Page.GotoAsync("https://web-dev.caledoncard.com/cgi-bin/padpayment/add_company.cgi");
    }

    public async Task ClickEditCompanyOption()
    {
        await Page.GotoAsync("https://web-dev.caledoncard.com/cgi-bin/padpayment/edit_company.cgi");
        
    }

    public async Task ClickMerchantMenuOption()
    {
        await Page.ClickAsync("#menu > li:nth-child(2) > a");
    }

    public async Task ClickAddMerchantOption()
    {
        await Page.GotoAsync("https://web-dev.caledoncard.com/cgi-bin/padpayment/add_merchant.cgi");
    }
}