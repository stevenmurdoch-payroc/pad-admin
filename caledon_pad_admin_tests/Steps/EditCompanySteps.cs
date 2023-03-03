using caledon_pad_admin_tests.PageObjects;

namespace caledon_pad_admin_tests.Steps;
[Binding]
public class EditCompanySteps
{
    
    private readonly EditCompanyPage _editCompanyPage;
    private readonly ScenarioContext _scenarioContext;
    
    
    public EditCompanySteps(ScenarioContext scenarioContext, EditCompanyPage editCompanyPage)
    {
        _scenarioContext = scenarioContext;
        _editCompanyPage = editCompanyPage;
    }

    [When(@"the user fills out the Edit Company Page")]
    public async Task WhenTheUserFillsOutTheEditCompanyPage(Table table)
    {
        var dataFilename = table.Rows[0][0];

        await _editCompanyPage.FillOutEditCompanyForm(dataFilename);
    }

    [When(@"submits the Edit Company request")]
    public async Task WhenSubmitsTheEditCompanyRequest()
    {
        await _editCompanyPage.ClickUpdateCompany();
    }

    [Then(@"the Edit Company confirmation message is displayed")]
    public async Task ThenTheEditCompanyConfirmationMessageIsDisplayed()
    {
        await _editCompanyPage.ConfirmAddedCompanyMessage();
    }
}