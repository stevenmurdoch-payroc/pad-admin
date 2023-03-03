Feature: Company
	Add and Edit a Company

	Background:
		Given the user logs in with valid credentials
		
	Scenario: Add a Company
	When the user navigates to the Add Company Page 
	And the user fills out the Add Company Page
 	 	| dataFile                   |
  		| addcompany1.json           |
    And submits the Add Company request
    Then the Add Company confirmation message is displayed 
    
    @wip-specify-company-via-datafile
	Scenario: Edit a Company
		When the user navigates to the Edit Company Page 
		And the user fills out the Edit Company Page
		  | dataFile         |
		  | editcompany1.json |
		And submits the Edit Company request
		Then the Edit Company confirmation message is displayed 