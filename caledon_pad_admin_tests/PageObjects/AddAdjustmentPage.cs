using caledon_pad_admin_tests.Drivers;
using caledon_pad_admin_tests.Helpers;
using FluentAssertions;
using Microsoft.Playwright;

namespace caledon_pad_admin_tests.PageObjects;

public class AddAdjustmentPage : BasePage
{
    private readonly DataFileHelper _dataFileHelper;
    private readonly ScreenshotHelper _screenshotHelper;

    public AddAdjustmentPage(ScenarioContext scenarioContext, LocalBrowserDriver browserDriver,
        ConfigurationDriver configurationDriver, DataFileHelper dataFileHelper,
        ScreenshotHelper screenshotHelper) : base(scenarioContext, browserDriver, configurationDriver)
    {
        _dataFileHelper = dataFileHelper;
        _screenshotHelper = screenshotHelper;
    }
    
    protected override string PagePath => "/cgi-bin/padpayment/add_adjustment.cgi";


    public async Task FillOutAddAdjustmentForm(string dataFilename)
    {
        //Select Company:  BLUEPAYTEST
        await Page.Locator("#Adjust_comp_select").SelectOptionAsync(new[] { "45" });
        
        var companyData = await _dataFileHelper.Load<AddAdjustment>(dataFilename);
        
        //Fill in Adjustment Details 
        await Page.FillAsync("#term_id", companyData.TerminalId!);  
        await Page.FillAsync("#addAdjust_amount", companyData.Amount!);
        await Page.FillAsync("#addAdjust_transRef", companyData.TransactionReference!);
        await Page.FillAsync("#addAdjust_desc", companyData.AdjustmentDescription!);
        
        //Select PAD Adjustment
        await Page.Locator("#Adjust_batch_type_select").SelectOptionAsync(new[] { "PAD" });
        await Page.Locator("#Adjust_account_select").SelectOptionAsync(new[] { "Deposit 001-00123-***4567" });
        
    }

    public async Task ClickAddAdjustment()
    {
        await Page.ClickAsync("#submitBut1");
    }


    public async Task ConfirmAddAdjustmentMessage()
    {
        await Page.ScreenshotAsync(new PageScreenshotOptions
            { Path = _screenshotHelper.ScreenShotFilePath("add_adjustment_confirmation.png") });

        var feedbackText =
            await Page.EvalOnSelectorAsync<string>("body > div", "el => el.innerText");
        var expectedText = "Successfully!";
        feedbackText.Should().Contain(expectedText);
    }
}




