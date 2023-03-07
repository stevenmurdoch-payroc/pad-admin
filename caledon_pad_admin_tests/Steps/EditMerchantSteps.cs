using caledon_pad_admin_tests.PageObjects;

namespace caledon_pad_admin_tests;

[Binding]
public class EditMerchantSteps
{
    
    private readonly EditMerchantPage _editMerchantPage;
    private readonly ScenarioContext _scenarioContext;
    
    
    public EditMerchantSteps(ScenarioContext scenarioContext, EditMerchantPage editMerchantPage)
    {
        _scenarioContext = scenarioContext;
        _editMerchantPage = editMerchantPage;
    }

    [When(@"the user fills out the Edit Merchant Page")]
    public async Task WhenTheUserFillsOutTheEditMerchantPage(Table table)
    {
        var dataFilename = table.Rows[0][0];

        await _editMerchantPage.FillOutEditMerchantForm(dataFilename);
    }

    [When(@"submits the Edit Merchant request")]
    public async Task WhenSubmitsTheEditMerchantRequest()
    {
        await _editMerchantPage.ClickUpdateMerchant();
    }

    [Then(@"the Edit Merchant confirmation message is displayed")]
    public async Task ThenTheEditMerchantConfirmationMessageIsDisplayed()
    {
        await _editMerchantPage.ConfirmAddedMerchantMessage();
    }
}