using caledon_pad_admin_tests.Drivers;
using caledon_pad_admin_tests.Helpers;
using FluentAssertions;
using Microsoft.Playwright;

namespace caledon_pad_admin_tests.PageObjects;

public class SearchPendingPaymentsPage : BasePage
{
    private readonly DataFileHelper _dataFileHelper;
    private readonly ScreenshotHelper _screenshotHelper;

    public SearchPendingPaymentsPage(ScenarioContext scenarioContext, LocalBrowserDriver browserDriver,
        ConfigurationDriver configurationDriver, DataFileHelper dataFileHelper,
        ScreenshotHelper screenshotHelper) : base(scenarioContext, browserDriver, configurationDriver)
    {
        _dataFileHelper = dataFileHelper;
        _screenshotHelper = screenshotHelper;
    }

    protected override string PagePath => "/cgi-bin/padpayment/search_payment.cgi";

    public async Task FillOutSearchPendingPaymentsPage(string dataFilename)
    {
        //Select Company:  BLUEPAYTEST
        
        await Page.Locator("#comp_select").SelectOptionAsync(new[] { "45" });
        
        var companyData = await _dataFileHelper.Load<SearchPayments>(dataFilename);
        
        await Page.FillAsync("#term_id", companyData.TerminalId); 
        await Page.FillAsync("#transSearch_amount", companyData.Amount);
        await Page.FillAsync("#transSearch_insertDate", companyData.InsertDate);
        await Page.FillAsync("#transSearch_insertDateEnd", companyData.InsertEndDate);
        
        await Page.FillAsync("#transSearch_tenantId", companyData.ClientId);
        await Page.FillAsync("#transSearch_bankId", companyData.BankId);
        await Page.FillAsync("#transSearch_branchNumb", companyData.BankTransitNumber);
        await Page.FillAsync("#transSearch_acctNumb", companyData.BankAccountNumber);
        await Page.FillAsync("#transSearch_chargeDesc", companyData.ChargeDescription);

        await Page.FillAsync("#transSearch_effectiveDate", companyData.EffectiveDate);
        await Page.FillAsync("#transSearch_effectiveDateEnd", companyData.EffectiveEndDate);
    }

    public async Task ClickSearchPendingPayments()
    {
        await Page.ClickAsync("body > div > div:nth-child(6) > form > table > tbody > tr:nth-child(15) > td:nth-child(2) > input[type=SUBMIT]");
    }

    public async Task ConfirmSearchPendingPaymentsResultsMessage()
    {
        
        await Page.ScreenshotAsync(new PageScreenshotOptions
            { Path = _screenshotHelper.ScreenShotFilePath("search_pending_payment_confirmation.png") });

        var feedbackText =
            await Page.EvalOnSelectorAsync<string>("#titleDiv", "el => el.innerText");
        var expectedText = "Search Pending Payment Results";
        feedbackText.Should().Contain(expectedText);
    }
}