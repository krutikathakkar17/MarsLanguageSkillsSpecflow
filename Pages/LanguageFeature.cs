using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using NUnit.Framework;

namespace Mars_Language_Skills.Pages
{

    public class LanguageFeature
    {
        private IWebDriver _driver;

        public LanguageFeature(IWebDriver driver)
        {
            _driver = driver;
        }

        private readonly By addNewlanButtonLocator = By.XPath("//div[@data-tab='first']//div[@class='ui teal button ']");
        IWebElement addNewlanButton;

        private readonly By inputElementLocator = By.XPath("//input[@type='text'][@placeholder='Add Language']");
        IWebElement inputElement;

        private readonly By addlanLocator = By.XPath("//input[@type='button'][@value='Add']");
        IWebElement addlan;

          private readonly By editlanLocator = By.XPath("//tbody/tr/td[@class='right aligned']/span[@class='button']/i[contains(@class, 'outline write icon')]");
         IWebElement editlan;


        private readonly By DeletelanLocator = By.XPath("//tbody/tr/td[@class='right aligned']/span[@class='button']/i[contains(@class, 'remove icon')]");
        IWebElement deleteLan;


        


        public void AddLanguages(String language, String level)
        {
            addNewlanButton = _driver.FindElement(addNewlanButtonLocator);
            addNewlanButton.Click();

            string popupXPath = "//div[@class='ns-box-inner']";
            string expectedMessage = $"{language} has been added to your languages";

            Thread.Sleep(9000);

            // Find the language input element and enter the value
            inputElement = _driver.FindElement(inputElementLocator);
            inputElement.SendKeys(language);

            Thread.Sleep(7000);

            // Find the dropdown element and select the appropriate level
            SelectElement levelDropdown = new SelectElement(_driver.FindElement(By.XPath("//select[@class='ui dropdown'][@name=\"level\"]")));
            levelDropdown.SelectByText(level);

            Thread.Sleep(3000);

            // Click the "Add" button
            addlan = _driver.FindElement(addlanLocator);
            addlan.Click();

            Thread.Sleep(1000);

            var popupElement = _driver.FindElement(By.XPath(popupXPath));
            string popupText = popupElement.Text;
            Assert.AreEqual(expectedMessage, popupText, $"Pop-up message mismatch. Expected: '{expectedMessage}', but got: '{popupText}'");

            Thread.Sleep(7000);
        }

        public void VerifyLanguagesAdded(string expectedLanguage, string expectedLevel)
        {
            Thread.Sleep(5000);

            // XPath to locate all rows in the language table
            string rowXPath = "//table[@class='ui fixed table']/tbody/tr";
            var rows = _driver.FindElements(By.XPath(rowXPath));

            bool found = false;

            foreach (var row in rows)
            {
                var languageElement = row.FindElement(By.XPath("./td[1]"));
                var levelElement = row.FindElement(By.XPath("./td[2]"));

                if (languageElement.Text == expectedLanguage && levelElement.Text == expectedLevel)
                {
                    found = true;
                    break;
                }
            }

            Assert.IsTrue(found, $"Language '{expectedLanguage}' with level '{expectedLevel}' not found.");

            Thread.Sleep(5000);

            deleteLan = _driver.FindElement(DeletelanLocator);
            deleteLan.Click();

        }

        public void AddingEmptyLanguage(String level)
        {
            Thread.Sleep(8000);

            addNewlanButton = _driver.FindElement(addNewlanButtonLocator);
            addNewlanButton.Click();

            SelectElement levelDropdown = new SelectElement(_driver.FindElement(By.XPath("//select[@class='ui dropdown'][@name=\"level\"]")));
            levelDropdown.SelectByText(level);

            addlan = _driver.FindElement(addlanLocator);
            addlan.Click();

        }

        public void VerifyNoEmptyLanguageAdded()
        {
            string popupXPath = "//div[contains(@class, 'ns-box') and contains(@class, 'ns-growl') and contains(@class, 'ns-effect-jelly') and contains(@class, 'ns-type-error') and contains(@class, 'ns-show')]";
            string expectedMessage = "Please enter language and level";

            Thread.Sleep(1000);

            var popupElement = _driver.FindElement(By.XPath(popupXPath));
            string popupText = popupElement.Text;

            Assert.AreEqual(expectedMessage, popupText, $"Pop-up message mismatch. Expected: '{expectedMessage}', but got: '{popupText}'");
            Thread.Sleep(5000);
        }

        private readonly By addUpdatedLocator = By.XPath("//input[@class='ui teal button'][@value='Update']");
        IWebElement addUpdated;
        
        

        

        public void EditLanguages(String level)
        {
            Thread.Sleep(5000);
          
            AddLanguages("English", "Fluent");

            Thread.Sleep(5000);

            editlan = _driver.FindElement(editlanLocator);
            editlan.Click();

            // Find the dropdown element and select the new level
            SelectElement levelDropdown = new SelectElement(_driver.FindElement(By.XPath("//select[@class='ui dropdown']")));

            levelDropdown.SelectByText(level);

            // Optionally, save the changes by clicking the update button

            addUpdated = _driver.FindElement(addUpdatedLocator);
            addUpdated.Click();

            Thread.Sleep(3000);

        }


      public void VerifyLanguageLeveleditted(string language, string expectedLevel)
        {
            // Create the XPath to find the language row
            string xpath = $"//tbody/tr[td[text()='{expectedLevel}']]/td[2]";
            IWebElement levelElement = _driver.FindElement(By.XPath(xpath));

            // Get the actual level text
            string actualLevel = levelElement.Text;

            // Verify the level
            Assert.AreEqual(expectedLevel, actualLevel, $"Language level for '{language}' was not updated correctly.");

            Thread.Sleep(5000);

            deleteLan = _driver.FindElement(DeletelanLocator);
            deleteLan.Click();

        }

        

        public void DeleteLanguages()
        {
            Thread.Sleep(5000);

            AddLanguages("English", "Fluent");

            Thread.Sleep(3000);

              deleteLan = _driver.FindElement(DeletelanLocator);
              deleteLan.Click();

            Thread.Sleep(3000);

        }


        public void VerifyLanguageDeleted(string language)
        {
            Thread.Sleep(5000);

            // Create the XPath to find the language row
            string xpath = $"//tbody/tr[td[text()='{language}']]";
            var languageElements = _driver.FindElements(By.XPath(xpath));

            // Verify that no elements are found for the deleted language
            Assert.IsTrue(languageElements.Count == 0, $"Language '{language}' was not deleted successfully.");
            Thread.Sleep(8000);
        }


    }
}