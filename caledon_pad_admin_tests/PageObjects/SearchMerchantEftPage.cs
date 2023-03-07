using caledon_pad_admin_tests.Drivers;
using caledon_pad_admin_tests.Helpers;
using FluentAssertions;
using Microsoft.Playwright;

namespace caledon_pad_admin_tests.PageObjects;

public class SearchMerchantEftPage :BasePage
{
    private readonly DataFileHelper _dataFileHelper;
    private readonly ScreenshotHelper _screenshotHelper;

    public SearchMerchantEftPage(ScenarioContext scenarioContext, LocalBrowserDriver browserDriver,
        ConfigurationDriver configurationDriver, DataFileHelper dataFileHelper,
        ScreenshotHelper screenshotHelper) : base(scenarioContext, browserDriver, configurationDriver)
    {
        _dataFileHelper = dataFileHelper;
        _screenshotHelper = screenshotHelper;
    }

    protected override string PagePath => "/cgi-bin/padpayment/search_merchant_eft.cgi";

    public async Task FillOutSearchMerchantEftPage(string dataFilename)
    {
        var companyData = await _dataFileHelper.Load<SearchMerchantEft>(dataFilename);
        
        await Page.FillAsync("#viewEFTCrdit_termId", companyData.TerminalId);
    }

    public async Task ClickGoOnSearchMerchantEft()
    {
        await Page.ClickAsync("body > div > div:nth-child(6) > form > table > tbody > tr:nth-child(8) > td:nth-child(3) > input[type=SUBMIT]");
    }
    
    public async Task ConfirmMerchantEftSearchResultsMessage()
    {
        await Page.ScreenshotAsync(new PageScreenshotOptions
            { Path = _screenshotHelper.ScreenShotFilePath("search_merchant_eft_confirmation.png") });

        var feedbackText =
            await Page.EvalOnSelectorAsync<string>("#titleDiv", "el => el.innerText");
        var expectedText = "Search Merchant EFT Results";
        feedbackText.Should().Contain(expectedText);
    }
}