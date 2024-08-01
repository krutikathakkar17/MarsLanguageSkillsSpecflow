using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using NUnit.Framework;
using System.Reflection.Emit;

namespace Mars_Language_Skills.Pages
{
    public class SkillFeature
    {

        private IWebDriver _driver;

        public SkillFeature(IWebDriver driver)
        {
            _driver = driver;
        }

        private readonly By skillsButtonLocator = By.XPath("//a[contains(.,'Skills')][@data-tab=\"second\"]");
        IWebElement skillsButton;


        private readonly By addNewskillButtonLocator = By.XPath("//div[@class = \"ui teal button\"][text()=\"Add New\"]");
        IWebElement addNewskillButton;

        private readonly By inputSkillLocator = By.XPath("//input[@placeholder=\"Add Skill\"][@type=\"text\"]");
        IWebElement inputSkill;

        private readonly By addSkillLocator = By.XPath("//input[@value=\"Add\"][@class='ui teal button ']");
        IWebElement addSkill;

          private readonly By editskillLocator = By.XPath("//tbody/tr/td[@class='right aligned']/span[@class='button']/i[contains(@class, 'outline write icon')]");
         IWebElement editskill;

         private readonly By DeleteskillLocator = By.XPath("//tbody/tr/td[@class='right aligned']/span[@class='button']/i[contains(@class, 'remove icon')]");
         IWebElement deleteSkill;
        

        public void AddSkills(String skill, String sklevel)
        {
            skillsButton = _driver.FindElement(skillsButtonLocator);
            skillsButton.Click();

            addNewskillButton = _driver.FindElement(addNewskillButtonLocator);
            addNewskillButton.Click();

            string skillPopupXPath = "//div[@class='ns-box-inner']";
            string expectedMessage = $"{skill} has been added to your skills";

            Thread.Sleep(3000);

            // Find the language input element and enter the value
            inputSkill = _driver.FindElement(inputSkillLocator);
            inputSkill.SendKeys(skill);

            // Find the dropdown element and select the appropriate level

            SelectElement skLevelDropdown = new SelectElement(_driver.FindElement(By.XPath("//select[@class=\"ui fluid dropdown\"][@name=\"level\"]")));
            skLevelDropdown.SelectByText(sklevel);

            Thread.Sleep(7000);

            // Click the "Add" button

            addSkill = _driver.FindElement(addSkillLocator);
            addSkill.Click();

            Thread.Sleep(1000);

            var popupElement = _driver.FindElement(By.XPath(skillPopupXPath));
            string popupText = popupElement.Text;

            Assert.AreEqual(expectedMessage, popupText, $"Pop-up message mismatch. Expected: '{expectedMessage}', but got: '{popupText}'");
            Thread.Sleep(5000);

        }
      

        public void VerifySkillsAdded(string expectedSkill, string expectedLevel)
        {
            Thread.Sleep(5000);


            string rowXPath = "//div[@data-tab='second']/div[@class='row']/div[@class='twelve wide column scrollTable']/div[@class='form-wrapper']/table[@class='ui fixed table']/tbody/tr";


            Thread.Sleep(3000);

            var rows = _driver.FindElements(By.XPath(rowXPath));


            bool found = false;

            foreach (var row in rows)
            {
                var skillElement = row.FindElement(By.XPath("./td[1]"));
                var levelElement = row.FindElement(By.XPath("./td[2]"));

                
                if (skillElement.Text == expectedSkill && levelElement.Text == expectedLevel)
                {
                    found = true;
                    break;
                }
            }

            Assert.IsTrue(found, $"Skill '{expectedSkill}' with level '{expectedLevel}' not found.");

            Thread.Sleep(5000);

            deleteSkill = _driver.FindElement(DeleteskillLocator);
            deleteSkill.Click();
        }

        
        public void AddDuplicateSkill(String skill, String sklevel)
        {
            Thread.Sleep(3000);

            AddSkills("Cooking", "Expert");

            Thread.Sleep(3000);


            addNewskillButton = _driver.FindElement(addNewskillButtonLocator);
            addNewskillButton.Click();

            inputSkill = _driver.FindElement(inputSkillLocator);
            inputSkill.SendKeys(skill);

            SelectElement skLevelDropdown = new SelectElement(_driver.FindElement(By.XPath("//select[@class=\"ui fluid dropdown\"][@name=\"level\"]")));
            skLevelDropdown.SelectByText(sklevel);

            addSkill = _driver.FindElement(addSkillLocator);
            addSkill.Click();
            Thread.Sleep(5000);

        }

        
        public void VerifyNoDuplicateSkillAdded()
        {
            {
                
                string popupXPath = "//div[contains(@class, 'ns-box') and contains(@class, 'ns-growl') and contains(@class, 'ns-effect-jelly') and contains(@class, 'ns-type-error') and contains(@class, 'ns-show')]";
                string expectedMessage = "This skill is already exist in your skill list.";

                Thread.Sleep(1000);

                var popupElement = _driver.FindElement(By.XPath(popupXPath));
                string popupText = popupElement.Text;

                Assert.AreEqual(expectedMessage, popupText, $"Pop-up message mismatch. Expected: '{expectedMessage}', but got: '{popupText}'");
                Thread.Sleep(5000);

                deleteSkill = _driver.FindElement(DeleteskillLocator);
                deleteSkill.Click();


            }
        }
                                               

        private readonly By addSkillupdatedLocator = By.XPath("//input[@class='ui teal button'][@value='Update']");
        IWebElement addSkillupdated;

        
        public void EditSkills(String level)
        { 

            AddSkills("Cooking","Expert");
            Thread.Sleep(3000);


            editskill = _driver.FindElement(editskillLocator);
            editskill.Click();


            Thread.Sleep(5000);


            // Change the level value
            SelectElement levelDropdown = new SelectElement(_driver.FindElement(By.XPath("//select[@class=\"ui fluid dropdown\"][@name=\"level\"]")));

            levelDropdown.SelectByText(level);
         
            // Click the update button 

            addSkillupdated = _driver.FindElement(addSkillupdatedLocator);
            addSkillupdated.Click();
            Thread.Sleep(7000);

        }

        public void VerifySkillEdited(string skill,string expectedLevel)
        {

            Thread.Sleep(5000);

            // Create the XPath to find the skill row
            string xpath = $"//tbody/tr[td[text()='{expectedLevel}']]/td[2]";
            IWebElement levelElement = _driver.FindElement(By.XPath(xpath));

            Thread.Sleep(5000);

            // Get the actual level text
            string actualLevel = levelElement.Text;

            Thread.Sleep(5000);

            Assert.AreEqual(expectedLevel, actualLevel, $"Skill level for '{skill}' was not updated correctly.");

            Thread.Sleep(8000);

            deleteSkill = _driver.FindElement(DeleteskillLocator);
            deleteSkill.Click();
        }


        public void DeleteSkills()
        {
            Thread.Sleep(3000);

            AddSkills("Cooking", "Expert");

            Thread.Sleep(5000);
            {

                deleteSkill = _driver.FindElement(DeleteskillLocator);
                deleteSkill.Click();

                Thread.Sleep(5000);

            }

        }

        
        public void VerifySkillDeleted(string skill)
        {
            Thread.Sleep(5000);

            // Create the XPath to find the skill row

            string xpath = $"//tbody/tr[td[text()='{skill}']]";
            var skillElements = _driver.FindElements(By.XPath(xpath));

            // Verify that no elements are found for the deleted skill

            Assert.IsTrue(skillElements.Count == 0, $"Skill '{skill}' was not deleted successfully.");

          
            Thread.Sleep(5000);
        }
    }
}













