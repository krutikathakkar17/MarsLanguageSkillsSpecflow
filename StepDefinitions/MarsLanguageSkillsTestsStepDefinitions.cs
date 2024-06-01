using Mars_Language_Skills.Pages;
using MarsLanguageSkillsSpecflow.Pages;
using MarsLanguageSkillsSpecflow.Utilities;
using OpenQA.Selenium.Chrome;

namespace MarsLanguageSkillsSpecflow.StepDefinitions
{
    [Binding]
    public class MarsLanguageSkillsTestsStepDefinitions : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        ProfilePage profilePageObj = new ProfilePage();
        LanguageFeature languageFeatureObj = new LanguageFeature();
        SkillFeature SkillFeatureObj = new SkillFeature();


        [Given(@"User logs in Mars portal")]
        public void GivenUserLogsInMarsPortal()
        {
            // IWebDriver driver = new ChromeDriver();
            driver = new ChromeDriver();

            //LoginPage obeject initialization

           // LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver, "krits17.kt@gmail.com", "Singapore_24");
           
        }

        [When(@"User navigates to profile page")]
        public void WhenUserNavigatesToProfilePage()
        {
            profilePageObj.VerifyLoggedinUser(driver);
        }

        [When(@"User adds a language with level, and clicks Add button")]
        public void WhenUserAddsALanguageWithLevelAndClicksAddButton()
        {
            languageFeatureObj.AddLanguages(driver);
        }

        [Then(@"User should see the language and it's level added to the profile")]
        public void ThenUserShouldSeeTheLanguageAndItsLevelAddedToTheProfile()
        {
           languageFeatureObj.VerifyLanguagesAdded(driver);
        }

        [When(@"User edits one of the existing languages")]
        public void WhenUserEditsOneOfTheExistingLanguages()
        {
            languageFeatureObj.EditLanguages(driver);
        }

      /*  [When(@"User clicks on update button to save the changes in languages")]
        public void WhenUserClicksOnUpdateButtonToSaveTheChangesInLanguages()
        {
           // throw new PendingStepException();
        }*/

        [Then(@"Verify edited language record is updated")]
        public void ThenVerifyRecordIsUpdated()
        {
            languageFeatureObj.VerifyLanguageLeveleditted(driver, "English", "Native/Bilingual");
        }

        [When(@"User deletes one of the existing languages")]
        public void WhenUserDeletesOneOfTheExistingLanguages()
        {
            languageFeatureObj.DeleteLanguages(driver);
        }

        [Then(@"Verify language record is deleted")]
        public void Verifylanguagerecordisdeleted()
        {
           languageFeatureObj.VerifyLanguageDeleted(driver, "French");
        }


        [When(@"User adds a skill with level, and clicks Add button")]
        public void WhenUserAddsASkillWithLevelAndClicksAddButton()
        {
            SkillFeatureObj.AddSkills(driver);
        }

        [Then(@"User should see the skill and it's level added to the profile")]
        public void ThenUserShouldSeeTheSkillAndItsLevelAddedToTheProfile()
        {
           SkillFeatureObj.VerifySkillsAdded(driver);
        }

        [When(@"User edits one of the existing skills")]
        public void WhenUserEditsOneOfTheExistingSkills()
        {
          SkillFeatureObj.EditSkills(driver);
        }

        [Then(@"Verify edited skill record is updated")]
        public void ThenVerifyrecordisupdated()
        {
          SkillFeatureObj.VerifySkillEdited(driver, "Painting"); 
        }

        [When(@"User deletes one of the existing skills")]
        public void WhenUserDeletesOneOfTheExistingSkills()
        {
          SkillFeatureObj.DeleteSkills(driver);
        }

        [Then(@"Verify skill record is deleted")]
        public void thenVerifskillrecordisdeleted()
        {
          SkillFeatureObj.VerifySkillDeleted(driver, "Dancing");
        }
    }
}
