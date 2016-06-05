Feature: CardNumberValidation
	In order to avoid processing bad card numbers 
	I want to be valid card numbers

Scenario Outline: Valid Card Numbers
	Given I have the following '<cardNumber>'
	When I validated the Card Number
	Then the result should be <Status>
Examples: 
| cardNumber       | Status  |
| 4111111111111111 | Valid   |
| 5500000000000004 | Valid   |
| 411d111111111111 | Invalid |
| 4111111111111112 | Invalid |
| 411111111111111  | Invalid |


Scenario Outline: Valid Cards including Expiry
	Given I have the following '<cardNumber>' with an expiry date '<Months>' months from now 
	When I validated the Card
	Then the result should be <Status>
Examples: 
| cardNumber       | Months | Status  |
| 4111111111111111 | 0      | Valid   |
| 5500000000000004 | 0      | Valid   |
| 411d111111111111 | 0      | Invalid |
| 4111111111111112 | 0      | Invalid |
| 411111111111111  | 0      | Invalid |
| 4111111111111111 | 1      | Valid   |
| 5500000000000004 | 1      | Valid   |
| 411d111111111111 | 1      | Invalid |
| 4111111111111112 | 1      | Invalid |
| 411111111111111  | 1      | Invalid |
| 4111111111111111 | 10     | Valid   |
| 5500000000000004 | 10     | Valid   |
| 411d111111111111 | 10     | Invalid |
| 4111111111111112 | 10     | Invalid |
| 411111111111111  | 10     | Invalid |
| 4111111111111111 | 100    | Valid   |
| 5500000000000004 | 100    | Valid   |
| 411d111111111111 | 100    | Invalid |
| 4111111111111112 | 100    | Invalid |
| 411111111111111  | 100    | Invalid |
| 4111111111111111 | -1     | Invalid |
| 5500000000000004 | -1     | Invalid |
| 411d111111111111 | -1     | Invalid |
| 4111111111111112 | -1     | Invalid |
| 411111111111111  | -1     | Invalid |
| 4111111111111111 | -100   | Invalid |
| 5500000000000004 | -100   | Invalid |
| 411d111111111111 | -100   | Invalid |
| 4111111111111112 | -100   | Invalid |
| 411111111111111  | -100   | Invalid | 