Feature: Login
	Check if login functionality works

@mytag
Scenario: Login user as Administrator
	Given I navigate to application
	And I enter username and password
		| UserName   | Password |
		| Admin54536 | advent12 |
	And I click login
	Then I should see user logged in to the application
	And I logout from application