using caledon_pad_admin_tests.Drivers;
using caledon_pad_admin_tests.Helpers;
using FluentAssertions;
using Microsoft.Playwright;

namespace caledon_pad_admin_tests.PageObjects;

public class ViewAdjustmentPage : BasePage
{
    private readonly DataFileHelper _dataFileHelper;
    private readonly ScreenshotHelper _screenshotHelper;

    public ViewAdjustmentPage(ScenarioContext scenarioContext, LocalBrowserDriver browserDriver,
        ConfigurationDriver configurationDriver, DataFileHelper dataFileHelper,
        ScreenshotHelper screenshotHelper) : base(scenarioContext, browserDriver, configurationDriver)
    {
        _dataFileHelper = dataFileHelper;
        _screenshotHelper = screenshotHelper;
    }
    
    protected override string PagePath => "/cgi-bin/padpayment/view_adjustment.cgi";


    public async Task FillOutViewAdjustmentForm(string dataFilename)
    {

        var companyData = await _dataFileHelper.Load<ViewAdjustment>(dataFilename);
        await Page.Locator("#comp_select").SelectOptionAsync(new[] {companyData.CompanyId});
        //Fill in Adjustment Details 
        await Page.FillAsync("#term_id", companyData.TerminalId!);  
        await Page.FillAsync("#viewAdjust_amount", companyData.Amount!);
        await Page.FillAsync("#viewAdjust_transRef", companyData.TransactionReference!);
        await Page.FillAsync("#viewAdjust_desc", companyData.AdjustmentDescription!);
    }

    public async Task ClickViewAdjustment()
    {
        await Page.ClickAsync("#submitBut1");
    }


    public async Task ConfirmViewAdjustmentMessage()
    {
        await Page.ScreenshotAsync(new PageScreenshotOptions
            { Path = _screenshotHelper.ScreenShotFilePath("view_adjustment_confirmation.png") });

        var feedbackText =
            await Page.EvalOnSelectorAsync<string>("#titleDiv", "el => el.innerText");
        var expectedText = "View Adjustment Results";
        feedbackText.Should().Contain(expectedText);
    }
    
}