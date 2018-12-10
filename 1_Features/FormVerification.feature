Feature: Form Verification.
		In order to meet requirements of compliance bodies,
		as HCP coordinator and Engagement Owner,
		I want to be able to verify existing form.

@US_sHCP
Scenario: 02.sHCP_verification
	Given I am logged in as HCPCoordinator
	When User searches for existing sHCP form and opens it
	Then sHCP Form is in view mode
	And Form is in status Draft
	When User clicks Send To Engagement Owner For Verification button
	Then Form has been sent for verification
	When I click Logout Link
	Then I am logged out
	When I log in as engagementOwner
	And User searches for existing sHCP form and opens it
	Then sHCP Form is in view mode
	When User clicks Edit button
	Then sHCP Form is in edit mode
	When I fill in Information section
	Then Information Section is filled correctly
	When I click Save Form Button
	Then sHCP Form is in view mode
	And Form is in status Verified
	When I click Logout Link
	Then I am logged out

@US_mHCP
Scenario: 02.mHCP_verification
	Given I am logged in as engagementOwner
	When User searches for existing mHCP form and opens it
	Then mHCP Form is in view mode
	And Form is in status Draft
	When User clicks Edit button
	Then mHCP Form is in edit mode
	When User clicks Cancel button
	Then HomePage is displayed
	When User searches for existing mHCP form and opens it
	Then mHCP Form is in view mode
	When User clicks Edit button
	Then mHCP Form is in edit mode
	When I fill in Information section
	Then Information Section is filled correctly
	When I click Save Form Button
	Then mHCP Form is in view mode
	And Form is in status Verified
	When I click Logout Link
	Then I am logged out
