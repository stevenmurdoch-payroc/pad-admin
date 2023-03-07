Feature: Merchant
Add and Edit a Merchant

    Background:
        Given the user logs in with valid credentials
		
    Scenario: Add a Merchant
        When the user navigates to the Add Merchant Page 
        And the user fills out the Add Merchant Page
          | dataFile         |
          | addmerchant1.json |
        And submits the Add Merchant request
        Then the Add Merchant confirmation message is displayed
        
        @wip
    Scenario: Edit a Merchant
        When the user navigates to the Edit Merchant Page 
        And the user fills out the Edit Merchant Page
          | dataFile          |
          | editmerchant1.json |
        And submits the Edit Merchant request
        Then the Edit Merchant confirmation message is displayed 