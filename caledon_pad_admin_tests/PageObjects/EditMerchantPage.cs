using caledon_pad_admin_tests.Drivers;
using caledon_pad_admin_tests.Helpers;
using FluentAssertions;
using Microsoft.Playwright;

namespace caledon_pad_admin_tests.PageObjects;

public class EditMerchantPage : BasePage
{
    private readonly DataFileHelper _dataFileHelper;
    private readonly ScreenshotHelper _screenshotHelper;

    public EditMerchantPage(ScenarioContext scenarioContext, LocalBrowserDriver browserDriver,
        ConfigurationDriver configurationDriver, DataFileHelper dataFileHelper,
        ScreenshotHelper screenshotHelper) : base(scenarioContext, browserDriver, configurationDriver)
    {
        _dataFileHelper = dataFileHelper;
        _screenshotHelper = screenshotHelper;
    }

    protected override string PagePath => "/cgi-bin/padpayment/edit_merchant.cgi";

    public async Task FillOutEditMerchantForm(string dataFilename)
    {
        //Select Company:  ABCTEST
        await Page.Locator("#editMerch_compId").SelectOptionAsync(new[] { "57" });
        
        var companyData = await _dataFileHelper.Load<EditMerchant>(dataFilename);
        
        var rnd = new Random();
        var randombankid = rnd.Next(1, 100); // creates a number between 1 and 1000
        
        //Select Merchant: SPEC1000
        await Page.FillAsync("#editMerch_termId", companyData.TerminalId);
        await Page.FillAsync("#editMerch_description",companyData.Description);
        await Page.FillAsync("#editMerch_bankId",companyData.BankId!); 
        await Page.FillAsync("#editMerch_branchNumb",companyData.BranchNumber!);  
        await Page.FillAsync("#editMerch_acctNumb",companyData.AccountNumber! + randombankid);
        await Page.FillAsync("#editMerch_creditDays", companyData.CreditDelayDays!); 
        await Page.FillAsync("#editMerch_creditThreshold",companyData.CreditThreshold!); 
        await Page.FillAsync("#editMerch_fundingDays",companyData.FundingDelayDays!);
        await Page.FillAsync("#editMerch_reason", companyData.HoldPendingSuspendReason!);
        await Page.FillAsync("#editMerch_holdDate", companyData.HoldPendingSuspendDate!);
        await Page.FillAsync("#editMerch_setupFee",companyData.SetupFee!); 
        await Page.FillAsync("#editMerch_depositAmt",companyData.DepositAmount!);
        await Page.FillAsync("#max_transaction_amount",companyData.PadMaxThresAmount!); 
        await Page.FillAsync("#max_monthly_transaction_count",companyData.PadMaxMonthlyTransCount!); 
        await Page.FillAsync("#max_monthly_transaction_volume",companyData.PadMaxMonthlyVolume!);
        await Page.FillAsync("#eft_max_transaction_amount",companyData.EftMaxThresAmount!); 
        await Page.FillAsync("#eft_max_monthly_transaction_count",companyData.EftMaxMonthlyTransCount!); 
        await Page.FillAsync("#eft_max_monthly_transaction_volume",companyData.EftMaxMonthlyVolume!);
        
    }

    public async Task ClickUpdateMerchant()
    {
        await Page.GetByText("Update").ClickAsync();
    }

    public async Task ConfirmAddedMerchantMessage()
    {
        
        await Page.PauseAsync();
        
        
        await Page.ScreenshotAsync(new PageScreenshotOptions
            { Path = _screenshotHelper.ScreenShotFilePath("edit_merchant_confirmation.png") });

        var feedbackText =
            await Page.EvalOnSelectorAsync<string>("#editMerch_msgDiv > em > font > b", "el => el.innerText");
        var expectedText = "Update termId";
        feedbackText.Should().Contain(expectedText);
    }
}