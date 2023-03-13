using caledon_pad_admin_tests.Drivers;
using caledon_pad_admin_tests.Helpers;
using FluentAssertions;
using Microsoft.Playwright;

namespace caledon_pad_admin_tests.PageObjects;

public class SearchPaymentsPage : BasePage
{
    private readonly DataFileHelper _dataFileHelper;
    private readonly ScreenshotHelper _screenshotHelper;

    public SearchPaymentsPage(ScenarioContext scenarioContext, LocalBrowserDriver browserDriver,
        ConfigurationDriver configurationDriver, DataFileHelper dataFileHelper,
        ScreenshotHelper screenshotHelper) : base(scenarioContext, browserDriver, configurationDriver)
    {
        _dataFileHelper = dataFileHelper;
        _screenshotHelper = screenshotHelper;
    }

    protected override string PagePath => "/cgi-bin/padpayment/search_payment.cgi";

    public async Task FillOutSearchPaymentsPage(string dataFilename)
    {

        var companyData = await _dataFileHelper.Load<SearchPayments>(dataFilename);
        await Page.Locator("#comp_select").SelectOptionAsync(new[] {companyData.CompanyId});
        await Page.FillAsync("#term_id", companyData.TerminalId); 
        await Page.FillAsync("#transSearch_amount", companyData.Amount);
        await Page.FillAsync("#transSearch_insertDate", companyData.InsertDate);
        await Page.FillAsync("#transSearch_insertDateEnd", companyData.InsertEndDate);
        await Page.FillAsync("#transSearch_transDate", companyData.DebitTransDate);
        await Page.FillAsync("#transSearch_transDateEnd", companyData.DebitTransEndDate);
        await Page.FillAsync("#transSearch_payDate", companyData.CreditPaymentDate);
        await Page.FillAsync("#transSearch_payDateEnd", companyData.CreditPaymentEndDate);
        await Page.FillAsync("#transSearch_refNumb", companyData.TransactionReferenceNumber);
        await Page.FillAsync("#transSearch_tenantId", companyData.ClientId);
        await Page.FillAsync("#transSearch_bankId", companyData.BankId);
        await Page.FillAsync("#transSearch_branchNumb", companyData.BankTransitNumber);
        await Page.FillAsync("#transSearch_acctNumb", companyData.BankAccountNumber);
        await Page.FillAsync("#transSearch_chargeDesc", companyData.ChargeDescription);
        await Page.FillAsync("#transSearch_rejectCode", companyData.RejectCode);
        await Page.FillAsync("#transSearch_rejectDate", companyData.RejectDate);
        await Page.FillAsync("#transSearch_returnCode", companyData.ReturnItemCode);
        await Page.FillAsync("#transSearch_returnCode", companyData.ReturnItemDate);
        await Page.FillAsync("#transSearch_debitFileId", companyData.DebitFileId);
    }

    public async Task ClickSearchPayments()
    {
        await Page.ClickAsync("body > div > div:nth-child(6) > form > table > tbody > tr:nth-child(22) > td:nth-child(2) > input[type=SUBMIT]");
    }

    public async Task ConfirmSearchPaymentsResultsMessage()
    {
        
        await Page.ScreenshotAsync(new PageScreenshotOptions
            { Path = _screenshotHelper.ScreenShotFilePath("search_payment_confirmation.png") });

        var feedbackText =
            await Page.EvalOnSelectorAsync<string>("#titleDiv", "el => el.innerText");
        var expectedText = "Search Payment Results";
        feedbackText.Should().Contain(expectedText);
    }
}