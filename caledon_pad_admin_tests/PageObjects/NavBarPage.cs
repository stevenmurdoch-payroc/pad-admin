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

    public async Task ClickEditMerchantOption()
    {
        await Page.GotoAsync("https://web-dev.caledoncard.com/cgi-bin/padpayment/edit_merchant.cgi");
    }

    public async Task ClickEftMenuOption()
    {
        await Page.ClickAsync("#menu > li:nth-child(3) > a");
    }

    public async Task ClickSearchMerchantEftOption()
    {
        await Page.GotoAsync("https://web-dev.caledoncard.com/cgi-bin/padpayment/search_merchant_eft.cgi");
    }

    public async Task ClickSearchPaymentsMenuOption()
    {
        await Page.ClickAsync("#menu > li:nth-child(4) > a");
    }

    public async Task ClickSearchPendingPaymentsMenuOption()
    {
        await Page.ClickAsync("#menu > li:nth-child(5) > a");
    }

    public async Task ClickAdjustmentMenuOption()
    {
        await Page.ClickAsync("#menu > li:nth-child(6) > a");
    }

    public async Task ClickAddAdjustmentOption()
    {
        await Page.GotoAsync("https://web-dev.caledoncard.com/cgi-bin/padpayment/add_adjustment.cgi");
    }

    public async Task ClickViewAdjustmentOption()
    {
        await Page.GotoAsync("https://web-dev.caledoncard.com/cgi-bin/padpayment/view_adjustment.cgi");
    }
}