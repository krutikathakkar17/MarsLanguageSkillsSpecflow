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



        public void AddLanguages()
        {
            string[] languages = { "English", "French", "Hindi", "Gujarati" };
            string[] langlevels = { "Fluent", "Basic", "Fluent", "Native/Bilingual" };

            // Loop to add languages and levels
            for (int i = 0; i < languages.Length; i++)
            {
                //In languages click on AddNew cell



                addNewlanButton = _driver.FindElement(addNewlanButtonLocator);
                addNewlanButton.Click();

                Thread.Sleep(3000);

                // Find the language input element and enter the value



                inputElement = _driver.FindElement(inputElementLocator);
                inputElement.SendKeys(languages[i]);


                // Find the dropdown element and select the appropriate level

                SelectElement levelDropdown = new SelectElement(_driver.FindElement(By.XPath("//select[@class='ui dropdown'][@name=\"level\"]")));
                levelDropdown.SelectByText(langlevels[i]);


                Thread.Sleep(3000);

                // Click the "Add" button


                addlan = _driver.FindElement(addlanLocator);
                addlan.Click();
                Thread.Sleep(3000);


            }

        }

        public void VerifyLanguagesAdded()
        {
            Thread.Sleep(3000);
            // XPaths to locate language and level elements
            string languageXPath = "//table[@class='ui fixed table']/tbody/tr/td[1]";
            string levelXPath = "//table[@class='ui fixed table']/tbody/tr/td[2]";

            // Find the elements containing languages and levels
            var languageElements = _driver.FindElements(By.XPath(languageXPath));
            var levelElements = _driver.FindElements(By.XPath(levelXPath));

            // Store the languages and levels in lists
            List<string> addedLanguages = new List<string>();
            List<string> addedLangLevels = new List<string>();

            // Extract text from each language element
            foreach (var element in languageElements)
            {
                addedLanguages.Add(element.Text);
            }

            // Extract text from each level element
            foreach (var element in levelElements)
            {
                addedLangLevels.Add(element.Text);
            }

            // Expected languages and levels for verification
            string[] expectedLanguages = { "English", "French", "Hindi", "Gujarati" };
            string[] expectedLangLevels = { "Fluent", "Basic", "Fluent", "Native/Bilingual" };

            // Verify that the added languages match the expected languages
            for (int i = 0; i < expectedLanguages.Length; i++)
            {
                Assert.AreEqual(expectedLanguages[i], addedLanguages[i], $"Language mismatch at index {i}");
                Assert.AreEqual(expectedLangLevels[i], addedLangLevels[i], $"Language level mismatch at index {i}");
            }
        }


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

     
    }

}