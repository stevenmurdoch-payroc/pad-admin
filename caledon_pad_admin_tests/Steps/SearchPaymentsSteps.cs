using caledon_pad_admin_tests.PageObjects;

namespace caledon_pad_admin_tests.Steps;

[Binding]
public class SearchPaymentsSteps
{
    
        
        
    private readonly SearchPaymentsPage _searchPaymentsPage;
    private readonly ScenarioContext _scenarioContext;
    
    
    public SearchPaymentsSteps(ScenarioContext scenarioContext, SearchPaymentsPage searchPaymentsPage)
    {
        _scenarioContext = scenarioContext;
        _searchPaymentsPage = searchPaymentsPage;
    }
    
    
    [When(@"the user fills out the Search Payments Page")]
    public async Task WhenTheUserFillsOutTheSearchPaymentsPage(Table table)
    {
        var dataFilename = table.Rows[0][0];

        await _searchPaymentsPage.FillOutSearchPaymentsPage(dataFilename);
    }

    [When(@"submits the Search Payments request")]
    public async Task WhenSubmitsTheSearchPaymentsRequest()
    {
        await _searchPaymentsPage.ClickSearchPayments();
    }

    [Then(@"the Search Payments Page is displayed")]
    public async Task ThenTheSearchPaymentsPageIsDisplayed()
    {
        await _searchPaymentsPage.ConfirmSearchPaymentsResultsMessage();

    }
}