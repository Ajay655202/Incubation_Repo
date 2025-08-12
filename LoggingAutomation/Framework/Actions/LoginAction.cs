using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggingAutomation.Framework.Pages;
using OpenQA.Selenium;

namespace LoggingAutomation.Framework.Actions
{
    internal class LoginAction
    {
        private readonly LoginPage _loginPage;

        public LoginAction(IWebDriver driver)
        {
            _loginPage = new LoginPage(driver);
        }

        public void LoginAs(string username, string password)
        {
            _loginPage.EnterUsername(username);
            _loginPage.EnterPassword(password);
            _loginPage.ClickLogin();
        }
    }
}
