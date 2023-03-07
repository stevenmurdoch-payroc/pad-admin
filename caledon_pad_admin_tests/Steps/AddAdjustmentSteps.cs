using caledon_pad_admin_tests.PageObjects;

namespace caledon_pad_admin_tests.Steps;

[Binding]
public class AddAdjustmentSteps
{
    
        
    
    private readonly AddAdjustmentPage _addAdjustmentPage;
    private readonly ScenarioContext _scenarioContext;
    
    
    public AddAdjustmentSteps(ScenarioContext scenarioContext, AddAdjustmentPage addAdjustmentPage)
    {
        _scenarioContext = scenarioContext;
        _addAdjustmentPage = addAdjustmentPage;
    }
    
    
    [When(@"the user fills out the Add Adjustment Page")]
    public async Task WhenTheUserFillsOutTheAddAdjustmentPage(Table table)
    {
        var dataFilename = table.Rows[0][0];

        await _addAdjustmentPage.FillOutAddAdjustmentForm(dataFilename);
    }

    [When(@"submits the Add Adjustment request")]
    public async Task WhenSubmitsTheAddAdjustmentRequest()
    {
        await _addAdjustmentPage.ClickAddAdjustment();
    }

    [Then(@"the Add Adjustment confirmation message is displayed")]
    public async Task ThenTheAddAdjustmentConfirmationMessageIsDisplayed()
    {
        await _addAdjustmentPage.ConfirmAddAdjustmentMessage();
    }
}