Feature: MarsLanguageSkillsTests

This feature tests creates, edits & deletes the records of languages and skills in Mars project

@tag1 
	Scenario: Verify user is able to add language and it's level
	Given User logs in Mars portal
	When User navigates to profile page
	And User adds a language with level  and clicks Add button
	Then User should see the language  and it's level  added to the profile

	Scenario: Verify user is able to edit language record
	Given User logs in Mars portal
	When User edits one of the existing languages
	Then Verify edited language record is updated

	Scenario: Verify user is able to delete language record
	Given User logs in Mars portal
	When User deletes one of the existing languages
	Then Verify language record is deleted

	Scenario: Verify user is able to add Skill and it's level
	Given User logs in Mars portal
	When User navigates to profile page
	And User adds a skill with level, and clicks Add button
	Then User should see the skill and it's level added to the profile

	Scenario: Verify user is able to edit skill record
	Given User logs in Mars portal
	When User edits one of the existing skills
	Then Verify edited skill record is updated

	Scenario: Verify user is able to delete skill record
	Given User logs in Mars portal
	When User deletes one of the existing skills
	Then Verify skill record is deleted

	
