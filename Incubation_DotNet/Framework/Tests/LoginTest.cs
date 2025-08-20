using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggingAutomation.Framework.Actions;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;

namespace LoggingAutomation.Framework.Tests
{
    [TestFixture]
    public class LoginTests
    {
        private IWebDriver _driver;
        private LoginAction loginAction;
        private string browser;
        private string baseUrl;
        private string userId;
        private string password;

        [SetUp]
        public void SetUp()
        {
            string path =string.Concat(AppContext.BaseDirectory,"Framework");
            var config = new ConfigurationBuilder()
            .SetBasePath(path) // so it finds the file in bin
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
            browser = config["Browser"];

            baseUrl = config["BaseUrl"];
            userId = config["UserId"];
            password = config["Password"];
            _driver = DriverFactory.GetDriver(browser);
            loginAction = new LoginAction(_driver);
        }

        [Test]
        public void LoginToApp()
        {
            _driver.Navigate().GoToUrl(baseUrl);
            loginAction.LoginAs(userId, password);
            Assert.IsTrue(_driver.Url.Contains("dashboard"));
        }

        [TearDown]
        public void TearDown()
        {
            DriverFactory.QuitDriver();
        }
    }
}
