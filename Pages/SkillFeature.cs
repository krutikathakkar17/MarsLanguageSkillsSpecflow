using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using NUnit.Framework;

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
        /*
        //After navigating to profile page click on skills

        Thread.Sleep(5000);
        skillsButton = _driver.FindElement(skillsButtonLocator);
        skillsButton.Click();

        //In skills click on AddNew cell


        // Skills and it's levels
        string[] skills = { "Cooking", "Speaking", "Sketching", "Dancing", "Singing", "Management" };
        string[] sklevels = { "Expert", "Expert", "Intermediate", "Expert", "Expert", "Expert" };

        // Loop to add languages and levels
        for (int i = 0; i < skills.Length; i++)
        {
            Thread.Sleep(3000);

            addNewskillButton = _driver.FindElement(addNewskillButtonLocator);
            addNewskillButton.Click();

            Thread.Sleep(3000);

            // Find the skill input element and enter the value

            inputSkill = _driver.FindElement(inputSkillLocator);
            inputSkill.SendKeys(skills[i]);
            Thread.Sleep(3000);

            // Find the dropdown element and select the appropriate level
            SelectElement skLevelDropdown = new SelectElement(_driver.FindElement(By.XPath("//select[@class=\"ui fluid dropdown\"][@name=\"level\"]")));
            skLevelDropdown.SelectByText(sklevels[i]);

            // Click the "Add" button

            addSkill = _driver.FindElement(addSkillLocator);
            addSkill.Click();
            Thread.Sleep(5000);

        }*/


        

        public void VerifySkillsAdded(string expectedSkill, string expectedLevel)
        {
            Thread.Sleep(5000);

            // XPath to locate all rows in the skill table
            //  string skillXPath = "//table[@class='ui fixed table']/tbody/tr/td[1]";
            //  var rows = _driver.FindElements(By.XPath(skillXPath));

            // string skillXPath = "//div[@data-tab='second']/div[@class='row']/div[@class='twelve wide column scrollTable']/div[@class='form-wrapper']/table[@class='ui fixed table']/tbody/tr/td[1]";

            // string levelXPath = "//div[@data-tab='second']/div[@class='row']/div[@class='twelve wide column scrollTable']/div[@class='form-wrapper']/table[@class='ui fixed table']/tbody/tr/td[2]";

            string rowXPath = "//div[@data-tab='second']/div[@class='row']/div[@class='twelve wide column scrollTable']/div[@class='form-wrapper']/table[@class='ui fixed table']/tbody/tr";


            Thread.Sleep(3000);

            var rows = _driver.FindElements(By.XPath(rowXPath));


            bool found = false;

            foreach (var row in rows)
            {
                var skillElement = row.FindElement(By.XPath("./td[1]"));
                var levelElement = row.FindElement(By.XPath("./td[2]"));

                //var skillElement = _driver.FindElement(By.XPath(skillXPath));
                //var levelElement = _driver.FindElement(By.XPath(levelXPath));

                if (skillElement.Text == expectedSkill && levelElement.Text == expectedLevel)
                {
                    found = true;
                    break;
                }
            }

            Assert.IsTrue(found, $"Skill '{expectedSkill}' with level '{expectedLevel}' not found.");
        }

        
      /*  public void AddDuplicateSkill(String skill, String sklevel)
        {
            Thread.Sleep(3000);

            skillsButton = _driver.FindElement(skillsButtonLocator);
            skillsButton.Click();

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


                // string xpathCancelIcon = "//input[@value=\"Cancel\"][@class='ui button ']" ;

                // IWebElement skillCancelBtn = _driver.FindElement(By.XPath(xpathCancelIcon));

            }
        }

         public void CancelDuplicateEntry()
         {
             string xpathCancelIcon = "//input[@class='ui button'][@value='Cancel']";
             IWebElement skillCancelBtn = _driver.FindElement(By.XPath(xpathCancelIcon));
             
         } /*











        /* skillsButton = _driver.FindElement(skillsButtonLocator);
         skillsButton.Click();
         Thread.Sleep(3000);
         // XPaths to locate skill and level elements
         //string skillXPath = "//table[@class='ui fixed table']/tbody/tr/td[1]";
         // string skillXPath = "//div[@data-tab='second']/div[@class='form-wrapper']/table[@class='ui fixed table']/tbody/tr/td[1]";
         string skillXPath = "//div[@data-tab='second']/div[@class='row']/div[@class='twelve wide column scrollTable']/div[@class='form-wrapper']/table[@class='ui fixed table']/tbody/tr/td[1]";

         string levelXPath = "//div[@data-tab='second']/div[@class='row']/div[@class='twelve wide column scrollTable']/div[@class='form-wrapper']/table[@class='ui fixed table']/tbody/tr/td[2]";

         // Find the elements containing skills and levels
         var skillElements = _driver.FindElements(By.XPath(skillXPath));
         var levelElements = _driver.FindElements(By.XPath(levelXPath));

         // Store the skills and levels in lists
         List<string> addedSkills = new List<string>();
         List<string> addedSkillLevels = new List<string>();

         // Extract text from each skill element
         foreach (var element in skillElements)
         {
             addedSkills.Add(element.Text);
         }

         // Extract text from each level element
         foreach (var element in levelElements)
         {
             addedSkillLevels.Add(element.Text);
         }

         // Expected skills and levels for verification
         string[] expectedSkills = { "Cooking", "Speaking", "Sketching", "Dancing", "Singing", "Management" };
         string[] expectedSkillLevels = { "Expert", "Expert", "Intermediate", "Expert", "Expert", "Expert" };

         // Verify that the number of added skills matches the expected number
         Assert.AreEqual(expectedSkills.Length, addedSkills.Count, "The number of skills does not match the expected count.");
         Assert.AreEqual(expectedSkillLevels.Length, addedSkillLevels.Count, "The number of skill levels does not match the expected count.");

         // Verify that the added skills and levels match the expected values
         for (int i = 0; i < expectedSkills.Length; i++)
         {
             Assert.AreEqual(expectedSkills[i], addedSkills[i], $"Skill mismatch at index {i}");
             Assert.AreEqual(expectedSkillLevels[i], addedSkillLevels[i], $"Skill level mismatch at index {i}");
         }
         Thread.Sleep(3000); */


        private readonly By addSkillupdatedLocator = By.XPath("//input[@class='ui teal button'][@value='Update']");
        IWebElement addSkillupdated;

        

        public void EditSkills()
        {
            //Edit the Skills
            skillsButton = _driver.FindElement(skillsButtonLocator);
            skillsButton.Click();
            Thread.Sleep(3000);

            string skillToEdit = "Sketching";
            string newSkill = "Painting";
            string newLevel = "Intermediate";
            string xpathWriteIcon = $"//tbody/tr[td[text()='{skillToEdit}']]/td[@class='right aligned']/span[@class='button']/i[contains(@class, 'outline write icon')]";
            IWebElement editSkill = _driver.FindElement(By.XPath(xpathWriteIcon));
            editSkill.Click();

            Thread.Sleep(5000);

            IWebElement skillInput = _driver.FindElement(By.XPath("//input[@type=\"text\"][@placeholder=\"Add Skill\"][@value=\"Sketching\"]"));

            skillInput.Clear();
            skillInput.SendKeys(newSkill);

            // Change the level value
            SelectElement levelDropdown = new SelectElement(_driver.FindElement(By.XPath("//select[@class=\"ui fluid dropdown\"][@name=\"level\"]")));
            levelDropdown.SelectByText(newLevel);

            // Click the update button 


            addSkillupdated = _driver.FindElement(addSkillupdatedLocator);
            addSkillupdated.Click();
            Thread.Sleep(3000);

        }

        

        public void VerifySkillEdited(string expectedSkill)
        {
            skillsButton = _driver.FindElement(skillsButtonLocator);
            skillsButton.Click();

            Thread.Sleep(5000);

            // Create the XPath to find the skill row
            string xpath = $"//tbody/tr[td[text()='{expectedSkill}']]/td[1]";
            IWebElement levelElement = _driver.FindElement(By.XPath(xpath));

            // Get the actual level text
            string actualSkill = levelElement.Text;

            // Verify the level
            if (expectedSkill != actualSkill)
            {
                throw new Exception($"Skill level for '{expectedSkill}' was not updated correctly. Expected: {expectedSkill}, Actual: {actualSkill}");
            }
        }



        

        public void DeleteSkills()
        {
            skillsButton = _driver.FindElement(skillsButtonLocator);
            skillsButton.Click();
            Thread.Sleep(5000);
            {
                //Delete Skills
                string skillToDelete = "Dancing";



                string xpathRemoveIcon = $"//tbody/tr[td[text()='{skillToDelete}']]/td[@class='right aligned']/span[@class='button']/i[contains(@class, 'remove icon')]";

                IWebElement skillDeleteBtn = _driver.FindElement(By.XPath(xpathRemoveIcon));
                skillDeleteBtn.Click();
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













