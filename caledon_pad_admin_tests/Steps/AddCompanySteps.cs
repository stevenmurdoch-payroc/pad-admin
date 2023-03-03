using caledon_pad_admin_tests.PageObjects;

namespace caledon_pad_admin_tests.Steps;

[Binding]
public class AddCompanySteps
{

    private readonly AddCompanyPage _addCompanyPage;
    private readonly ScenarioContext _scenarioContext;
    
    
    public AddCompanySteps(ScenarioContext scenarioContext, AddCompanyPage addCompanyPage)
    {
        _scenarioContext = scenarioContext;
        _addCompanyPage = addCompanyPage;
    }
    
    [When(@"the user fills out the Add Company Page")]
    public async Task WhenTheUserFillsOutTheAddCompanyPage(Table table)
    {
        var dataFilename = table.Rows[0][0];

        await _addCompanyPage.FillOutAddCompanyForm(dataFilename);
    }

    [When(@"submits the Add Company request")]
    public async Task WhenSubmitsTheAddCompanyRequest()
    {
        await _addCompanyPage.ClickSubmitAddCompany();
    }

    [Then(@"the Add Company confirmation message is displayed")]
    public async Task ThenTheAddCompanyConfirmationMessageIsDisplayed()
    {
        await _addCompanyPage.ConfirmAddedCompanyMessage();
    }
}