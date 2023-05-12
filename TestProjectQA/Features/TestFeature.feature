Feature: Feature_name
Scenario: BaseScenario
	When User waits 5 seconds

Scenario: Go Shopping
	When User waits 3 seconds
	When User opens Main page
	When User clicks on GoShopping button
	When User waits 3 seconds
	When User opens Search page
	When User clicks on SearchField button
	When User enter in SearchField "sofa" text
	When User waits 3 seconds