Feature: AmountValidation
	In order to avoid processing bad amount
	I want to be valid entered amounts

Scenario Outline: Valid amount
	Given I have amount of <amount>
	When I validated the amount
	Then the result should be <Status>
Examples: 
| amount   | Status  |
| 1        | Invalid |
| 100      | Valid   |
| 10000    | Valid   |
| 99999998 | Valid   |
| 99999999 | Invalid |
