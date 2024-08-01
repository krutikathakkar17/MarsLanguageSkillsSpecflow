Feature: MarsLanguageTests

This feature tests creates, edits & deletes the records of languages and skills in Mars project
 
	Scenario Outline: Add a language and level to the profile
    Given User logs in Mars portal and navigates to profile page
    When User adds a language "<Language>" with level "<Level>" and clicks Add button
    Then User should see the language "<Language>" and its level "<Level>" added to the profile

    Examples:
      | Language | Level        |
      | English  | Fluent       |
     
     
      

  Scenario: Adding a language with an empty name
  Given User logs in Mars portal and navigates to profile page
  When User adds an empty language with level and clicks Add button
  Then User should see an error message 


	Scenario: Verify user is able to edit language record
	Given User logs in Mars portal and navigates to profile page
	When User edits one of the existing languages "<Level>"
	Then Verify edited language record is updated

	Examples:
      | Level             |
      | Native/Bilingual  |

	Scenario: Verify user is able to delete language record
	Given User logs in Mars portal and navigates to profile page
	When User deletes one of the existing languages
	Then Verify language record is deleted

	
