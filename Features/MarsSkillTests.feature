Feature: MarsSkillTests

A short summary of the feature

@tag1
    Scenario Outline: Verify user is able to add Skill and it's level
	Given User logs in Mars portal and navigates to profile page
	When User adds a skill "<Skill>" with level "<Level>", and clicks Add button
	Then User should see the skill "<Skill>" and it's level "<Level>" added to the profile

	Examples:
      | Skill     | Level            |
      | Cooking   | Expert           |
	  

    Scenario: Adding a duplicate skill
     Given  User logs in Mars portal and navigates to profile page
     When  User adds a duplicate skill with level and clicks Add button
     Then  User should see an error message for duplicate skill

	Scenario: Verify user is able to edit skill record
	Given User logs in Mars portal and navigates to profile page
	When User edits one of the existing skills "<Level>"
	Then Verify edited skill record is updated

	Examples:
         | Level            |
         | Intermediate     |

	Scenario: Verify user is able to delete skill record
	Given User logs in Mars portal and navigates to profile page
	When User deletes one of the existing skills
	Then Verify skill record is deleted

	
	