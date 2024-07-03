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


        

        public void AddLanguages(String language, String level)
        {
            addNewlanButton = _driver.FindElement(addNewlanButtonLocator);
            addNewlanButton.Click();

            string popupXPath = "//div[@class='ns-box-inner']";
            string expectedMessage = $"{language} has been added to your languages";

            Thread.Sleep(3000);

            // Find the language input element and enter the value
            inputElement = _driver.FindElement(inputElementLocator);
            inputElement.SendKeys(language);

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

      /*  public void CancelEmptyEntry()
        {
            string xpathCancelIcon = "//input[@class='ui button'][@value='Cancel']";
            IWebElement skillCancelBtn = _driver.FindElement(By.XPath(xpathCancelIcon));

        } */


        /* public void VerifyLanguageAddedThroughPopup(string expectedLanguage)
        {

               // XPath to locate the pop-up message element
               string popupXPath = "//div[@class='ns-box-inner']";
               //string popupXPath = "//div[@class='ns-box-inner']";
               //  string popupXPath = "//div[contains(@class, 'ns-box') and contains(@class, 'ns-growl') and contains(@class, 'ns-effect-jelly') and contains(@class, 'ns-type-success') and contains(@class, 'ns-show')]//div[@class='ns-box-inner']";


               var popupElement = _driver.FindElement(By.XPath(popupXPath));
               Thread.Sleep(20000);

               // Extract the text from the pop-up element
               string popupText = popupElement.Text;
               Thread.Sleep(7000);

               // Construct the expected message
               string expectedMessage = $"{expectedLanguage} has been added to your languages";

        // Verify the pop-up message
         Assert.AreEqual(expectedMessage, popupText, $"Pop-up message mismatch. Expected: '{expectedMessage}', but got: '{popupText}'");
        } */


        /*  Thread.Sleep(3000);
          // XPaths to locate language and level elements
          string languageXPath = "//table[@class='ui fixed table']/tbody/tr/td[1]";
          string levelXPath = "//table[@class='ui fixed table']/tbody/tr/td[2]";

          // Find the elements containing languages and levels
          var languageElement = _driver.FindElement(By.XPath(languageXPath));
          var levelElement = _driver.FindElement(By.XPath(levelXPath));

          String actualLanguage = languageElement.Text;
          String actualLevel = levelElement.Text;

          // Store the languages and levels in lists
          List<string> addedLanguages = new List<string>();
          List<string> addedLangLevels = new List<string>();

          // Extract text from each language element
          //foreach (var element in languageElements)
          //{
          //    addedLanguages.Add(element.Text);
          //}

          // Extract text from each level element
          //foreach (var element in levelElements)
          //{
           //   addedLangLevels.Add(element.Text);
          //}

          // Expected languages and levels for verification
          //string[] expectedLanguages = { "English", "French", "Hindi", "Gujarati" };
         // string[] expectedLangLevels = { "Fluent", "Basic", "Fluent", "Native/Bilingual" };

          // Verify that the added languages match the expected languages
          //for (int i = 0; i < expectedLanguages.Length; i++)
          //{
              Assert.AreEqual(language, actualLanguage, $"Language mismatch at index");
              Assert.AreEqual(level, actualLevel, $"Language level mismatch at index");
          //}
          */



        private readonly By addUpdatedLocator = By.XPath("//input[@class='ui teal button'][@value='Update']");
        IWebElement addUpdated;
        private object language;
        private double expectedLevel;

        

        public void EditLanguages()
        {
            Thread.Sleep(5000);
            string languageToEdit = "English";
            string newLevel = "Native/Bilingual";



            // Create the XPath selector based on the language value
            string xpath = $"//tbody/tr[td[text()='{languageToEdit}']]/td[@class='right aligned']/span[@class='button']/i[contains(@class, 'outline write icon')]";
            IWebElement editlan = _driver.FindElement(By.XPath(xpath));

            Console.WriteLine("editlanguage", editlan);

            //console.WriteLine log(editlan);
            editlan.Click();

            // Find the dropdown element and select the new level
            SelectElement levelDropdown = new SelectElement(_driver.FindElement(By.XPath("//select[@class='ui dropdown']")));

            levelDropdown.SelectByText(newLevel);

            // Optionally, save the changes by clicking the update button



            addUpdated = _driver.FindElement(addUpdatedLocator);
            addUpdated.Click();
            Thread.Sleep(3000);



        }


        

        public void VerifyLanguageLeveleditted(string language, string expectedLevel)
        {
            // Create the XPath to find the language row
            string xpath = $"//tbody/tr[td[text()='{language}']]/td[2]";
            IWebElement levelElement = _driver.FindElement(By.XPath(xpath));

            // Get the actual level text
            string actualLevel = levelElement.Text;

            // Verify the level
            Assert.AreEqual(expectedLevel, actualLevel, $"Language level for '{language}' was not updated correctly.");

        }

        

        public void DeleteLanguages()
        {
            Thread.Sleep(5000);

            string languagetoDelete = "French";

            // Find the language input element and get its value
            string xpath = $"//tbody/tr[td[text()='{languagetoDelete}']]/td[@class='right aligned']/span[@class='button']/i[contains(@class, 'remove icon')]";

            IWebElement languageDeleteBtn = _driver.FindElement(By.XPath(xpath));
            languageDeleteBtn.Click();

            Thread.Sleep(3000);

            //  string rwXPath = "//table[@class='ui fixed table']/tbody/tr";
            //  var button = _driver.FindElements(By.XPath(rwXPath));

            // foreach (var deletebutton in button)
            //  {
            // var languageElement = deletebutton.FindElement(By.XPath(xpath));

            /* if (languageElement.Text == languageToDelete)
             {
                 deleteButton.Click();
                 Thread.Sleep(3000);
                 VerifyLanguageDeleted(languageToDelete);
                 found = true;
                 break;
             }*/

            //  }




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
            Thread.Sleep(5000);
        }


      /*  public void DeleteRestOfLanguages(string language)
        {

            string xpath = $"//tbody/tr[td[text()='{language}']]/td[@class='right aligned']/span[@class='button']/i[contains(@class, 'remove icon')]";

            IWebElement languageDeleteBtn = _driver.FindElement(By.XPath(xpath));
            languageDeleteBtn.Click();

            string popupXPath = "//div[contains(@class, 'ns-box') and contains(@class, 'ns-growl') and contains(@class, 'ns-effect-jelly') and contains(@class, 'ns-type-error') and contains(@class, 'ns-show')]";
            string expectedMessage = $"{language} has been deleted from your languages";

            var popupElement = _driver.FindElement(By.XPath(popupXPath));
            string popupText = popupElement.Text;

            Assert.AreEqual(expectedMessage, popupText, $"Pop-up message mismatch. Expected: '{expectedMessage}', but got: '{popupText}'");
            Thread.Sleep(7000);

           
        }


        public void VerifyAllLanguageDeleted(string language)
        {
            Thread.Sleep(5000);
            // Create the XPath to find the language row
            string xpath = $"//tbody/tr[td[text()='{language}']]";
            var languageElements = _driver.FindElements(By.XPath(xpath));
            // Verify that no elements are found for the deleted language
            Assert.IsTrue(languageElements.Count == 0, $"Language '{language}' was not deleted successfully.");
            Thread.Sleep(5000);

        }
      */







    }
}