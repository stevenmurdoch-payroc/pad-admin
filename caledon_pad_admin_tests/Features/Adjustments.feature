Feature: Adjustments
Add and View an Adjustment 

	Background:
		Given the user logs in with valid credentials
		
	Scenario: Add an Adjustment
		When the user navigates to the Add Adjustments Page 
		And the user fills out the Add Adjustment Page
		  | dataFile          |
		  | addadjustment1.json |
		And submits the Add Adjustment request
		Then the Add Adjustment confirmation message is displayed
		
	Scenario: View an Adjustment
		When the user navigates to the View Adjustments Page 
		And the user fills out the View Adjustment Page
		  | dataFile            |
		  | viewadjustment1.json |
		And submits the View Adjustment request
		Then the View Adjustment confirmation message is displayed