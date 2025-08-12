using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace LoggingAutomation.Framework.Pages
{
    internal class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement Username => WaitHelper.WaitForElementVisible(_driver, By.Id("username"));

        private IWebElement Password => WaitHelper.WaitForElementVisible(_driver, By.Id("password"));

        private IWebElement LoginButton => WaitHelper.WaitForElementVisible(_driver, By.Id("loginBtn"));

        public void EnterUsername(string username) => Username.SendKeys(username);

        public void EnterPassword(string password) => Password.SendKeys(password);

        public void ClickLogin() => LoginButton.Click();
    }
}
