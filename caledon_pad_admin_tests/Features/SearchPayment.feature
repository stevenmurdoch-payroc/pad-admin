Feature: SearchPayment
	

	Background:
		Given the user logs in with valid credentials
		
	Scenario: Search Payments
		When the user navigates to the Search Payments Page 
		And the user fills out the Search Payments Page
		  | dataFile                |
		  | searchpayments1.json |
		And submits the Search Payments request
		Then the Search Payments Page is displayed