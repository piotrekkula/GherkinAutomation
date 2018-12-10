Feature: Smoke Testing
	In order to make sure test environment is configured properly
	As an Engagement Owner
	I want to perform a series of smoke tests.

Background:
Given I am logged in as engagementOwner
#######################################

@Smoke_Test
Scenario: Smoke Test sHCP form
	When I clicked New Form button
	Then sHCP Form option is visible
	When I select sHCP option
	And I click Next button
	Then New sHCP Form opens
	And Smoke Test passes

@Smoke_Test
Scenario: Smoke Test mHCP form
	When I clicked New Form button
	Then mHCP Form option is visible
	When I select mHCP option
	And I click Next button
	Then New mHCP Form opens
	And Smoke Test passes

@Smoke_Test
Scenario: Smoke Test uHCP form
	When I clicked New Form button
	Then uHCP Form option is visible
	When I select uHCP option
	And I click Next button
	Then New uHCP Form opens
	And Smoke Test passes

@Smoke_Test
Scenario: Check visibility of Legacy when user is not admin.
	When I clicked New Form button
	Then Legacy form option is not visible