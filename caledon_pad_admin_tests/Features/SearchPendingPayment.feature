Feature: SearchPendingPayment
	Simple calculator for adding two numbers

	Background:
		Given the user logs in with valid credentials
		
	Scenario: Search Pending Payments
		When the user navigates to the Search Pending Payments Page 
		And the user fills out the Search Pending Payments Page
		  | dataFile             |
		  | searchpayments1.json |
		And submits the Search Pending Payments request
		Then the Search Pending Payments Page is displayed