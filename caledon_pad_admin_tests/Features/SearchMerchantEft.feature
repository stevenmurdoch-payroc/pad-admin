Feature: SearchMerchantEft
	

	Background:
		Given the user logs in with valid credentials
		
	Scenario: Search Merchant EFT
		When the user navigates to the Search Merchant EFT Page 
		And the user fills out the Search Merchant EFT Page
		  | dataFile                |
		  | searchmerchanteft1.json |
		And submits the Edit Merchant EFT request
		Then the Search Merchant EFT Results Page is displayed