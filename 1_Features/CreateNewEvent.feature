Feature: Create New Event.
	In order to group HCP spend reports
	As an event owner
	I want to create new event if it does not exist already

Background:
Given I am logged in as eventOwner
#######################################

@NewiHCP
Scenario Outline: Search for existing event
	When I click Search Event button
	Then Event Information search page is displayed

	When I fill in Event Information section
	|<eventtitle>|<eventtype>|<eventvenue>|<startdate>|<enddate>|
	And I click Search button
	Then Event search results are displayed

	When I click Create Event button
	Then HCP Event Form page is displayed

	When I asldkjalskjdlaskjd
	Then alskjdalsjdlaksjd

Examples:
| eventtitle  | eventtype      | eventvenue | startdate  | enddate    |
| first event | Advisory Board | Venue      | 06/20/2013 | 06/20/2013 |