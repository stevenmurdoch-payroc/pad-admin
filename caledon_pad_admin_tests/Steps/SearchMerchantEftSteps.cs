using caledon_pad_admin_tests.PageObjects;

namespace caledon_pad_admin_tests.Steps;

[Binding]
public class SearchMerchantEftSteps
{
    
        
    private readonly SearchMerchantEftPage _searchMerchantEftPage;
    private readonly ScenarioContext _scenarioContext;
    
    
    public SearchMerchantEftSteps(ScenarioContext scenarioContext, SearchMerchantEftPage searchMerchantEftPage)
    {
        _scenarioContext = scenarioContext;
        _searchMerchantEftPage = searchMerchantEftPage;
    }
    
    
    [When(@"the user fills out the Search Merchant EFT Page")]
    public async Task WhenTheUserFillsOutTheSearchMerchantEftPage(Table table)
    {
        var dataFilename = table.Rows[0][0];

        await _searchMerchantEftPage .FillOutSearchMerchantEftPage(dataFilename);
    }

    [When(@"submits the Edit Merchant EFT request")]
    public async Task WhenSubmitsTheEditMerchantEftRequest()
    {
        await _searchMerchantEftPage.ClickGoOnSearchMerchantEft();
    }

    [Then(@"the Search Merchant EFT Results Page is displayed")]
    public async Task ThenTheSearchMerchantEftResultsPageIsDisplayed()
    {
        await _searchMerchantEftPage.ConfirmMerchantEftSearchResultsMessage();
    }
}