using MarsLanguageSkillsSpecflow.Utilities;
using TechTalk.SpecFlow;

namespace MarsLanguageSkillsSpecflow.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly CommonDriver _commonDriver;

        public Hooks(CommonDriver commonDriver)
        {
            _commonDriver = commonDriver;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _commonDriver.Initialize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _commonDriver.Cleanup();
        }
    }
}



/*
  [BeforeScenario(Order = 1)]
public void InitializeBrowser()
{
    // Launch the browser using Selenium
}

[BeforeScenario(Order = 2)]
public void LoginBeforeScenario()
{
    // Perform login actions using Selenium
}

[BeforeScenario(Order = 3, Tags = "@addFunctionality")]
public void AddTestDataBeforeScenario()
{
    // Add data "Item1" to the table using Selenium actions
}

@login
Scenario: Login to the application
    Given I am on the login page
    When I enter username "user1" and password "password123"
    Then I should be logged in successfully

@editFunctionality
Scenario: Edit user profile
    Given I am logged in (assuming login is done in a separate scenario)
    When I edit my profile details
    Then the profile details should be updated successfully


[BeforeScenario(Order = 1, Tags = "@login")]
public void LoginBeforeScenario()
{
    // Perform login actions using Selenium
}

[BeforeScenario(Order = 2, Tags = "@editFunctionality")]
public void NavigateToProfileBeforeScenario()
{
    // Navigate to the user profile page using Selenium
}

// ... other BeforeScenario hooks with different orders and tags ...
 
 */