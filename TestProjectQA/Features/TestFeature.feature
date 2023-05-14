Feature: Feature_name
Scenario: BaseScenario
	When User waits 5 seconds
	When User opens Main page
	

Scenario: Go Shopping	
	When User opens Home page
	When User clicks on AcceptCookies button
	When User clicks on GoShopping button
	When User opens Search page
	When User clicks on OkCookies button
	When User clicks on SearchField button
	When User enter in SearchField "sofa" text
	When User clicks on SearchButton button
	When User opens SearchResult page
	When User clicks on 1 product item
	When User waits 3 seconds