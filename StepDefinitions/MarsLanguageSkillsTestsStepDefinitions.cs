using Mars_Language_Skills.Pages;
using MarsLanguageSkillsSpecflow.Pages;
using MarsLanguageSkillsSpecflow.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MarsLanguageSkillsSpecflow.StepDefinitions
{
    [Binding]
    public class MarsLanguageSkillsTestsStepDefinitions
    {

        private readonly IWebDriver _commonDriver;
        private readonly LoginPage _loginPageObj;
        private readonly ProfilePage _profilePageObj;
        private readonly LanguageFeature _languageFeatureObj;
        private readonly SkillFeature _skillFeatureObj;

        public MarsLanguageSkillsTestsStepDefinitions(CommonDriver commonDriver)
        {
            _commonDriver = commonDriver.driver;
            _loginPageObj = new LoginPage(_commonDriver);
            _profilePageObj = new ProfilePage(_commonDriver);
            _languageFeatureObj = new LanguageFeature(_commonDriver);
            _skillFeatureObj = new SkillFeature(_commonDriver);

        }


        [Given(@"User logs in Mars portal and navigates to profile page")]
        public void GivenUserLogsInMarsPortalAndNavigatesToProfilePage()
        {
            _loginPageObj.LoginActions("krits17.kt@gmail.com", "Singapore_24");
            _profilePageObj.VerifyLoggedinUser();
        }


        [When(@"User adds a language ""([^""]*)"" with level ""([^""]*)"" and clicks Add button")]
        public void WhenUserAddsALanguageWithLevelAndClicksAddButton(string language, string level)
        {
            _languageFeatureObj.AddLanguages(language, level);
        }

        [Then(@"User should see the language ""([^""]*)"" and its level ""([^""]*)"" added to the profile")]
        public void ThenUserShouldSeeTheLanguageAndItsLevelAddedToTheProfile(string language, string level)
        {
            _languageFeatureObj.VerifyLanguagesAdded(language, level);

        }

        [When(@"User adds an empty language with level and clicks Add button")]
        public void WhenUserAddsAnEmptyLanguageWithLevelAndClicksAddButton()
        {
            _languageFeatureObj.AddingEmptyLanguage("Fluent");
        }

        [Then(@"User should see an error message")]
        public void ThenUserShouldSeeAnErrorMessage()
        {
            _languageFeatureObj.VerifyNoEmptyLanguageAdded();

        } 

        [When(@"User edits one of the existing languages ""([^""]*)""")]
        public void WhenUserEditsOneOfTheExistingLanguages(String level)
        {
            _languageFeatureObj.EditLanguages(level);
        }


        [Then(@"Verify edited language record is updated")]
        public void ThenVerifyRecordIsUpdated()
        {
            _languageFeatureObj.VerifyLanguageLeveleditted("Fluent", "Native/Bilingual");
        }

        [When(@"User deletes one of the existing languages")]
        public void WhenUserDeletesOneOfTheExistingLanguages()
        {
            _languageFeatureObj.DeleteLanguages();
        }

        [Then(@"Verify language record is deleted")]
        public void Verifylanguagerecordisdeleted()
        {
            _languageFeatureObj.VerifyLanguageDeleted("English");
        }


        [When(@"User adds a skill ""([^""]*)"" with level ""([^""]*)"", and clicks Add button")]
        public void WhenUserAddsASkillWithLevelAndClicksAddButton(string skill, string level)
        {
            _skillFeatureObj.AddSkills(skill, level);
        }

        [Then(@"User should see the skill ""([^""]*)"" and it's level ""([^""]*)"" added to the profile")]
        public void ThenUserShouldSeeTheSkillAndItsLevelAddedToTheProfile(string skill, string level)
        {
            _skillFeatureObj.VerifySkillsAdded(skill, level);
        }

         [When(@"User adds a duplicate skill with level and clicks Add button")]
         public void WhenUserAddsADuplicateSkillWithLevelAndClicksAddButton()
         {
             _skillFeatureObj.AddDuplicateSkill("Cooking", "Expert");
         }

         [Then(@"User should see an error message for duplicate skill")]
         public void ThenUserShouldSeeAnErrorMessageForDuplicateSkill()
         {
             _skillFeatureObj.VerifyNoDuplicateSkillAdded();
           
        } 
        

        [When(@"User edits one of the existing skills ""([^""]*)""")]
        public void WhenUserEditsOneOfTheExistingSkills(string level)
        {
            _skillFeatureObj.EditSkills(level);
        }


        [Then(@"Verify edited skill record is updated")]
        public void ThenVerifyrecordisupdated()
        {
            _skillFeatureObj.VerifySkillEdited("Expert", "Intermediate"); 
        }

        [When(@"User deletes one of the existing skills")]
        public void WhenUserDeletesOneOfTheExistingSkills()
        {
            _skillFeatureObj.DeleteSkills();
        }

        [Then(@"Verify skill record is deleted")]
        public void thenVerifskillrecordisdeleted()
        {
            _skillFeatureObj.VerifySkillDeleted("Cooking");
        }
    }
}
