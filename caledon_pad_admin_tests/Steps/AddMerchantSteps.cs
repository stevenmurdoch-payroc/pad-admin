using caledon_pad_admin_tests.PageObjects;

namespace caledon_pad_admin_tests.Steps;

[Binding]
public class AddMerchantSteps
{
    
    
    private readonly AddMerchantPage _addMerchantPage;
    private readonly ScenarioContext _scenarioContext;
    
    
    public AddMerchantSteps(ScenarioContext scenarioContext, AddMerchantPage addMerchantPage)
    {
        _scenarioContext = scenarioContext;
        _addMerchantPage = addMerchantPage;
    }
    
    
    [When(@"the user fills out the Add Merchant Page")]
    public async Task WhenTheUserFillsOutTheAddMerchantPage(Table table)
    {
        var dataFilename = table.Rows[0][0];

        await _addMerchantPage.FillOutAddMerchantForm(dataFilename);
    }

    [When(@"submits the Add Merchant request")]
    public async Task WhenSubmitsTheAddMerchantRequest()
    {
        await _addMerchantPage.SaveAddMerchant();
    }
    
    
    

    [Then(@"the Add Merchant confirmation message is displayed")]
    public async Task ThenTheAddMerchantConfirmationMessageIsDisplayed()
    {
        await _addMerchantPage.ConfirmAddedMerchantMessage();
    }
}