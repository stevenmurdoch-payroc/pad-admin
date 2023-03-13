using caledon_pad_admin_tests.Drivers;
using caledon_pad_admin_tests.Helpers;
using FluentAssertions;
using Microsoft.Playwright;

namespace caledon_pad_admin_tests.PageObjects;

public class EditCompanyPage : BasePage
{
    private readonly DataFileHelper _dataFileHelper;
    private readonly ScreenshotHelper _screenshotHelper;

    public EditCompanyPage(ScenarioContext scenarioContext, LocalBrowserDriver browserDriver,
        ConfigurationDriver configurationDriver, DataFileHelper dataFileHelper,
        ScreenshotHelper screenshotHelper) : base(scenarioContext, browserDriver, configurationDriver)
    {
        _dataFileHelper = dataFileHelper;
        _screenshotHelper = screenshotHelper;
    }

    protected override string PagePath => "/cgi-bin/padpayment/edit_company.cgi";

    public async Task FillOutEditCompanyForm(string dataFilename)
    {
        //Select Company:  ABCTEST

        var companyData = await _dataFileHelper.Load<EditCompany>(dataFilename);
        
        //Fill in Company Details 
        await Page.Locator("#editComp_compId_select").SelectOptionAsync(new[] {companyData.CompanyId});
        var rnd = new Random();
        var randombankid = rnd.Next(1, 100); // creates a number between 1 and 1000
        await Page.FillAsync("#editComp_compName", companyData.CompanyName!);  
        await Page.FillAsync("#editComp_email",companyData.Email!);
        await Page.FillAsync("#editComp_apatoUser",companyData.ApatoId!);  
        await Page.FillAsync("#editComp_billing_bank_no",companyData.PadBankId!);
        await Page.FillAsync("#editComp_billing_branch_no",companyData.PadBranchNumber!);
        await Page.FillAsync("#editComp_billing_account_no",companyData.PadAccountNumber! + randombankid);
        await Page.FillAsync("#editComp_billing_fee_trans",companyData.PadTransFee!);
        await Page.FillAsync("#editComp_billing_fee_bps",companyData.PadBasisPoints!);
        await Page.FillAsync("#editComp_billing_fee_reject",companyData.PadRejectFee!);
        await Page.FillAsync("#editComp_billing_fee_return",companyData.PadReturnFee!);
        await Page.FillAsync("#edit_merchCredit_desc_PAD",companyData.PadMerchantCreditDescriptor!);
        await Page.FillAsync("#editComp_billing_bank_no_dbp",companyData.DbpBankId!);
        await Page.FillAsync("#editComp_billing_branch_no_dbp",companyData.DbpBranchNumber!);
        await Page.FillAsync("#editComp_billing_account_no_dbp",companyData.DbpAccountNumber!);
        await Page.FillAsync("#editComp_billing_fee_trans_dbp",companyData.DbpTransFee!); 
        await Page.FillAsync("#editComp_billing_fee_reject_dbp",companyData.DbpRejectFee!);
        await Page.FillAsync("#editComp_billing_fee_return_dbp",companyData.DbpReturnFee!);
        await Page.FillAsync("#edit_merchCredit_desc_DBP",companyData.DbpMerchantCreditDescriptor!);
        await Page.FillAsync("#editComp_billing_bank_no_chq",companyData.ChqBankId!);
        await Page.FillAsync("#editComp_billing_branch_no_chq",companyData.ChqBranchNumber!);
        await Page.FillAsync("#editComp_billing_account_no_chq",companyData.ChqAccountNumber!);
        await Page.FillAsync("#editComp_billing_fee_trans_chq",companyData.ChqTransFee!);
        await Page.FillAsync("#editComp_billing_fee_reject_chq",companyData.ChqRejectFee!);
        await Page.FillAsync("#editComp_billing_fee_return_chq",companyData.ChqReturnFee!);
        await Page.FillAsync("#edit_merchCredit_desc_CHQ",companyData.ChqMerchantCreditDescriptor!); 
        await Page.FillAsync("#editComp_billing_bank_no_eft",companyData.EftBankId!);
        await Page.FillAsync("#editComp_billing_branch_no_eft",companyData.EftBranchNumber!);
        await Page.FillAsync("#editComp_billing_account_no_eft",companyData.EftAccountNumber!);
        await Page.FillAsync("#editComp_billing_fee_trans_eft",companyData.EftTransFee!);
        await Page.FillAsync("#editComp_billing_fee_reject_eft",companyData.EftRejectFee!);
        await Page.FillAsync("#editComp_billing_fee_return_eft",companyData.EftReturnFee!);
        await Page.FillAsync("#edit_merchCredit_desc_EFTP",companyData.EftMerchantCreditDescriptor!);
    }

    public async Task ClickUpdateCompany()
    {
        await Page.ClickAsync("#editComp_Update");
    }

    public async Task ConfirmAddedCompanyMessage()
    {
        await Page.ScreenshotAsync(new PageScreenshotOptions
            { Path = _screenshotHelper.ScreenShotFilePath("edit_company_confirmation.png") });

        var feedbackText =
            await Page.EvalOnSelectorAsync<string>("#editComp_msgDiv > em > font > b", "el => el.innerText");
        var expectedText = "Company has been updated successfully";
        feedbackText.Should().Contain(expectedText);
    }
}