using caledon_pad_admin_tests.Drivers;
using caledon_pad_admin_tests.Helpers;
using FluentAssertions;
using Microsoft.Playwright;

namespace caledon_pad_admin_tests.PageObjects;

public class AddMerchantPage : BasePage
{
    private readonly DataFileHelper _dataFileHelper;
    private readonly ScreenshotHelper _screenshotHelper;

    public AddMerchantPage(ScenarioContext scenarioContext, LocalBrowserDriver browserDriver,
        ConfigurationDriver configurationDriver, DataFileHelper dataFileHelper,
        ScreenshotHelper screenshotHelper) : base(scenarioContext, browserDriver, configurationDriver)
    {
        _dataFileHelper = dataFileHelper;
        _screenshotHelper = screenshotHelper;
    }

    protected override string PagePath => "/cgi-bin/padpayment/add_merchant.cgi";


    public async Task FillOutAddMerchantForm(string dataFilename)
    {
        //Select Company:  ABCTEST
        await Page.Locator("#addMerch_comp_select").SelectOptionAsync(new[] { "57" });
        
        var companyData = await _dataFileHelper.Load<AddMerchant>(dataFilename);
        
        //Fill in Merchant Details 
        
        var rnd = new Random();
        var terminalnumber = rnd.Next(1000, 9999);
        await Page.FillAsync("#addMerch_termId", companyData.TerminalId! + terminalnumber);  
        await Page.FillAsync("#addMerch_bankId",companyData.BankId!);
        await Page.FillAsync("#addMerch_branchNumb",companyData.BranchNumber!);  
        await Page.FillAsync("#addMerch_acctNumb",companyData.AccountNumber!); 
        await Page.FillAsync("#addMerch_transFee",companyData.TransFee!); 
        await Page.FillAsync("#addMerch_BPSFee",companyData.BasisPoints!); 
        await Page.FillAsync("#addMerch_rejectFee",companyData.RejectFee!); 
        await Page.FillAsync("#addMerch_returnFee",companyData.ReturnFee!);
        await Page.FillAsync("#addMerch_creditDays", companyData.CreditDelayDays!); 
        await Page.FillAsync("#addMerch_creditThreshold",companyData.CreditThreshold!); 
        await Page.FillAsync("#addMerch_fundingDays",companyData.FundingDelayDays!); 
        await Page.FillAsync("#addMerch_desc",companyData.MerchantDescription!); 
        await Page.FillAsync("#addMerch_address",companyData.Address!); 
        await Page.FillAsync("#addMerch_setupFee",companyData.SetupFee!); 
        await Page.FillAsync("#addMerch_depositAmt",companyData.DepositAmount!); 
        await Page.FillAsync("#maximum_transaction_amount",companyData.PadMaxThresAmount!); 
        await Page.FillAsync("#maximum_monthly_transaction_count",companyData.PadMaxMonthlyTransCount!); 
        await Page.FillAsync("#maximum_monthly_volume",companyData.PadMaxMonthlyVolume!);
        await Page.FillAsync("#eft_maximum_transaction_amount",companyData.EftMaxThresAmount!); 
        await Page.FillAsync("#eft_maximum_monthly_transaction_count",companyData.EftMaxMonthlyTransCount!); 
        await Page.FillAsync("#eft_maximum_monthly_volume",companyData.EftMaxMonthlyVolume!);
        await Page.GetByLabel("Decline transactions/batches:").UncheckAsync();
        




    }

    public async Task ConfirmAddedMerchantMessage()
    {
        await Page.ScreenshotAsync(new PageScreenshotOptions
            { Path = _screenshotHelper.ScreenShotFilePath("add_merchant_confirmation.png") });

        var feedbackText =
            await Page.EvalOnSelectorAsync<string>("#message > em > font > b", "el => el.innerText");
        var expectedText = "Merchant Added Successfully!";
        feedbackText.Should().Contain(expectedText);
    }

    public async Task SaveAddMerchant()
    {
        await Page.ClickAsync("#save");
    }
}