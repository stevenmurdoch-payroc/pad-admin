using caledon_pad_admin_tests.PageObjects;

namespace caledon_pad_admin_tests.Steps;

[Binding]
public class ViewAdjustmentSteps
{
    
        
    
    private readonly ViewAdjustmentPage _viewAdjustmentPage;
    private readonly ScenarioContext _scenarioContext;
    
    
    public ViewAdjustmentSteps(ScenarioContext scenarioContext, ViewAdjustmentPage viewAdjustmentPage)
    {
        _scenarioContext = scenarioContext;
        _viewAdjustmentPage = viewAdjustmentPage;
    }
    
    
    [When(@"the user fills out the View Adjustment Page")]
    public async Task WhenTheUserFillsOutTheViewAdjustmentPage(Table table)
    {
        var dataFilename = table.Rows[0][0];

        await _viewAdjustmentPage.FillOutViewAdjustmentForm(dataFilename);
    }

    [When(@"submits the View Adjustment request")]
    public async Task WhenSubmitsTheViewAdjustmentRequest()
    {
        await _viewAdjustmentPage.ClickViewAdjustment();
    }

    [Then(@"the View Adjustment confirmation message is displayed")]
    public async Task ThenTheViewAdjustmentConfirmationMessageIsDisplayed()
    {
        await _viewAdjustmentPage.ConfirmViewAdjustmentMessage();
    }
}