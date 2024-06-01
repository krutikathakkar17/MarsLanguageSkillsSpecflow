using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsLanguageSkillsSpecflow.Pages
{
    public class LoginPage
    {

        private readonly By signinButtonLocator = By.XPath("//A[@class='item'][text()='Sign In']");
        IWebElement signinButton;
        private readonly By usernametextBoxLocator = By.XPath("(//INPUT[@type='text'])[2]");
        IWebElement usernametextBox;
        private readonly By passwordtextBoxLocator = By.XPath("//INPUT[@type='password']");
        IWebElement passwordtextBox;
        private readonly By loginButtonLocator = By.XPath("//BUTTON[@class='fluid ui teal button'][text()='Login']");
        IWebElement loginButton;
        public void LoginActions(IWebDriver driver, string username, string password)
        {
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("http://localhost:5000/");
           // //http://localhost:5000/Home

            //SignIn into Mars portal
            signinButton = driver.FindElement(signinButtonLocator);
            signinButton.Click();

            //Enter login credentials, emailid & password
            usernametextBox = driver.FindElement(usernametextBoxLocator);
            usernametextBox.SendKeys(username);

            passwordtextBox = driver.FindElement(passwordtextBoxLocator);
            passwordtextBox.SendKeys(password);

            //Click on LoginButton
            loginButton = driver.FindElement(loginButtonLocator);
            loginButton.Click();
            Thread.Sleep(5000);
        }
      
    }
}
