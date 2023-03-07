using caledon_pad_admin_tests.PageObjects;

namespace caledon_pad_admin_tests.Steps;

[Binding]
public class SearchPendingPaymentsSteps
{
    
        
        
    private readonly SearchPendingPaymentsPage _searchPendingPaymentsPage;
    private readonly ScenarioContext _scenarioContext;
    
    
    public SearchPendingPaymentsSteps(ScenarioContext scenarioContext, SearchPendingPaymentsPage searchPendingPaymentsPage)
    {
        _scenarioContext = scenarioContext;
        _searchPendingPaymentsPage = searchPendingPaymentsPage;
    }
    
    
    [When(@"the user fills out the Search Pending Payments Page")]
    public async Task WhenTheUserFillsOutTheSearchPendingPaymentsPage(Table table)
    {
        var dataFilename = table.Rows[0][0];

        await _searchPendingPaymentsPage.FillOutSearchPendingPaymentsPage(dataFilename);
    }

    [When(@"submits the Search Pending Payments request")]
    public async Task WhenSubmitsTheSearchPendingPaymentsRequest()
    {
        await _searchPendingPaymentsPage.ClickSearchPendingPayments();
    }

    [Then(@"the Search Pending Payments Page is displayed")]
    public async Task ThenTheSearchPendingPaymentsPageIsDisplayed()
    {
        await _searchPendingPaymentsPage.ConfirmSearchPendingPaymentsResultsMessage();

    }
}