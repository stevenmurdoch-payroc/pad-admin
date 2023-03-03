@login
Feature: Login to PAD Admin

    Scenario: User can log into PAD Admin with valid credentials
        Given a logged out user
        When the user logs in with valid credentials
        Then they log in successfully