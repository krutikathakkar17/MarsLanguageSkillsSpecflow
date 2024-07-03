Feature: MarsLanguageSkillsTests

This feature tests creates, edits & deletes the records of languages and skills in Mars project
 
	Scenario Outline: Add a language and level to the profile
    Given User logs in Mars portal
    When User navigates to profile page
    And User adds a language "<Language>" with level "<Level>" and clicks Add button
    Then User should see the language "<Language>" and its level "<Level>" added to the profile

    Examples:
      | Language | Level        |
      | English  | Fluent        |
      | French   | Basic         |
      | Hindi    | Native/Bilingual |
      

  Scenario: Adding a language with an empty name
  Given User logs in Mars portal
  When User adds an empty language with level and clicks Add button
  Then User should see an error message 


 
	Scenario: Verify user is able to edit language record
	Given User logs in Mars portal
	When User edits one of the existing languages
	Then Verify edited language record is updated

	Scenario: Verify user is able to delete language record
	Given User logs in Mars portal
	When User deletes one of the existing languages
	Then Verify language record is deleted

	Scenario Outline: Verify user is able to add Skill and it's level
	Given User logs in Mars portal
	When User navigates to profile page
	And User adds a skill "<Skill>" with level "<Level>", and clicks Add button
	Then User should see the skill "<Skill>" and it's level "<Level>" added to the profile

	Examples:
      | Skill     | Level            |
      | Cooking   | Expert           |
	  | Speaking  | Expert           |
	  | Sketching | Intermediate     |
      | Dancing   | Expert           |
      | Singing   | Expert           |
      | Management| Expert           |
	
	Scenario: Verify user is able to edit skill record
	Given User logs in Mars portal
	When User edits one of the existing skills
	Then Verify edited skill record is updated

	Scenario: Verify user is able to delete skill record
	Given User logs in Mars portal
	When User deletes one of the existing skills
	Then Verify skill record is deleted

	
	