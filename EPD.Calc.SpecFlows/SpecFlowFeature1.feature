﻿Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press add
	Then the result should be 120 on the screen

Scenario: Multiply two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press multiply
	Then the result should be 3500 on the screen

Scenario: Subtract two numbers
	Given I have entered 50 into the calculator
	And I have entered 70 into the calculator
	When I press subtract
	Then the result should be -20 on the screen