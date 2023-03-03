using caledon_pad_admin_tests.Drivers;
using caledon_pad_admin_tests.Helpers;
using FluentAssertions;
using Microsoft.Playwright;

namespace caledon_pad_admin_tests.PageObjects;

public class AddCompanyPage : BasePage
{
    private readonly DataFileHelper _dataFileHelper;
    private readonly ScreenshotHelper _screenshotHelper;

    public AddCompanyPage(ScenarioContext scenarioContext, LocalBrowserDriver browserDriver,
        ConfigurationDriver configurationDriver, DataFileHelper dataFileHelper,
        ScreenshotHelper screenshotHelper) : base(scenarioContext, browserDriver, configurationDriver)
    {
        _dataFileHelper = dataFileHelper;
        _screenshotHelper = screenshotHelper;
    }

    protected override string PagePath => "/cgi-bin/padpayment/add_company.cgi";

    public async Task FillOutAddCompanyForm(string dataFilename)
    {
        var companyData = await _dataFileHelper.Load<CreateCompany>(dataFilename);
        
        //Fill in Company Details 
        
        var rnd = new Random();
        var companyid = rnd.Next(1, 1000); // creates a number between 1 and 1000
        await Page.FillAsync("#addComp_compId",
            companyData.CompanyId! + companyid);
        await Page.FillAsync("#addComp_compName", companyData.CompanyName!);  
        await Page.FillAsync("#addComp_email",companyData.Email!);
        await Page.FillAsync("#addComp_area_code",companyData.PhoneFirst!);
        await Page.FillAsync("#addComp_exchange_code",companyData.PhoneSecond!);
        await Page.FillAsync("#addComp_station_code",companyData.PhoneThird);
        await Page.FillAsync("#addComp_phone_ext",companyData.PhoneExt!);
        await Page.FillAsync("#addComp_apatoUser",companyData.ApatoId!);
        await Page.FillAsync("#addComp_billing_bank_no",companyData.PadBankId!);
        await Page.FillAsync("#addComp_billing_branch_no",companyData.PadBranchNumber!);
        await Page.FillAsync("#addComp_billing_account_no",companyData.PadAccountNumber!);
        await Page.FillAsync("#addComp_billing_fee_trans",companyData.PadTransFee!);
        await Page.FillAsync("#addComp_billing_fee_bps",companyData.PadBasisPoints!);
        await Page.FillAsync("#addComp_billing_fee_reject",companyData.PadRejectFee!);
        await Page.FillAsync("#addComp_billing_fee_return",companyData.PadReturnFee!);
        await Page.FillAsync("#add_merchCredit_desc_PAD",companyData.PadMerchantCreditDescriptor!);
        await Page.FillAsync("#addComp_billing_bank_no_dbp",companyData.DbpBankId!);
        await Page.FillAsync("#addComp_billing_branch_no_dbp",companyData.DbpBranchNumber!);
        await Page.FillAsync("#addComp_billing_account_no_dbp",companyData.DbpAccountNumber!);
        await Page.FillAsync("#addComp_billing_fee_trans_dbp",companyData.DbpTransFee!);
        await Page.FillAsync("#addComp_billing_fee_reject_dbp",companyData.DbpRejectFee!);
        await Page.FillAsync("#addComp_billing_fee_return_dbp",companyData.DbpReturnFee!);
        await Page.FillAsync("#add_merchCredit_desc_DBP",companyData.DbpMerchantCreditDescriptor!);
        await Page.FillAsync("#addComp_billing_bank_no_chq",companyData.ChqBankId!);
        await Page.FillAsync("#addComp_billing_branch_no_chq",companyData.ChqBranchNumber!);
        await Page.FillAsync("#addComp_billing_account_no_chq",companyData.ChqAccountNumber!);
        await Page.FillAsync("#addComp_billing_fee_trans_chq",companyData.ChqTransFee!);
        await Page.FillAsync("#addComp_billing_fee_reject_chq",companyData.ChqRejectFee!);
        await Page.FillAsync("#addComp_billing_fee_return_chq",companyData.ChqReturnFee!);
        await Page.FillAsync("#add_merchCredit_desc_CHQ",companyData.ChqMerchantCreditDescriptor!);
        await Page.FillAsync("#addComp_billing_bank_no_eft",companyData.EftBankId!);
        await Page.FillAsync("#addComp_billing_branch_no_eft",companyData.EftBranchNumber!);
        await Page.FillAsync("#addComp_billing_account_no_eft",companyData.EftAccountNumber!);
        await Page.FillAsync("#addComp_billing_fee_trans_eft",companyData.EftTransFee!);
        await Page.FillAsync("#addComp_billing_fee_reject_eft",companyData.EftRejectFee!);
        await Page.FillAsync("#addComp_billing_fee_return_eft",companyData.EftReturnFee!);
        await Page.FillAsync("#add_merchCredit_desc_EFTP",companyData.EftMerchantCreditDescriptor!);
        
    }

    public async Task ClickSubmitAddCompany()
    {
        await Page.ClickAsync("#submit");
    }

    public async Task ConfirmAddedCompanyMessage()
    {
        await Page.ScreenshotAsync(new PageScreenshotOptions
            { Path = _screenshotHelper.ScreenShotFilePath("add_company_confirmation.png") });

        var feedbackText =
            await Page.EvalOnSelectorAsync<string>("#message > em > font > b", "el => el.innerText");
        var expectedText = "Successfully added company";
        feedbackText.Should().Contain(expectedText);
    }
}