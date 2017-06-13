Feature: PersonScreenFeature
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given I have the following people in the database
	| Name | Weight |
	| A    | 100    |
	| B    | 80     |
	When I load the people screen
	Then I see the following table
	| Name | Weight |
	| A    | 100    |
	| B    | 80     |
	And the average weight is 90


	@mytag
Scenario: Add two numbers
	Given I have the following people in the database
	| Name | Weight |
	| A    | 100    |
	| B    | 80     |
	When I load the screen
	And I add a new person C of weight 60
	Then I see the following table
	| Name | Weight |
	| A    | 100    |
	| B    | 80     |
	| C    | 60     |
	And the average weight is 80
