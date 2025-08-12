using System.Reflection;
using log4net;
using log4net.Config;
using OpenQA.Selenium;

namespace LoggingAutomation
{
    [TestFixture]
    public class TestLog : BaseTest
    {

        public static readonly ILog log = LogManager.GetLogger(typeof(TestLog));

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            // Load log4net configuration from file
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            log.Info("=== Test Execution Started ===");
        }

        [Test]
        public void TestLogin()
        {
            log.Info("Starting TestLogin");
            try
            {
                string expected = "admin";
                string actual = "admin";

                Assert.That(actual, Is.EqualTo(expected));
                log.Info("TestLogin passed successfully.");
            }
            catch (AssertionException ex)
            {
                log.Error("TestLogin failed.", ex);
                throw;
            }
        }

        [Test]
        public void TestSearch()
        {
            log.Info("Starting TestSearch");

            string searchTerm = "automation";
            if (searchTerm.Length > 0)
            {
                log.Debug("Search term is valid.");
                Assert.Pass();
            }
            else
            {
                log.Warn("Search term is empty.");
                Assert.Fail("Search term should not be empty.");
            }
        }

        [Test]
        public void ValidLogin_ShowsSuccessMessage()
        {
            // ARRANGE: Navigate and prepare elements
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            var usernameField = driver.FindElement(By.Id("username"));
            var passwordField = driver.FindElement(By.Id("password"));
            var loginButton = driver.FindElement(By.CssSelector("button.radius"));

            string validUsername = "tomsmith";
            string validPassword = "SuperSecretPassword!";

            // ACT: Enter credentials and click login
            usernameField.SendKeys(validUsername);
            passwordField.SendKeys(validPassword);
            loginButton.Click();

            // ASSERT: Check success message
            var message = driver.FindElement(By.Id("flash")).Text;
            Assert.IsTrue(message.Contains("You logged into a secure area!"), "Success message not found after login.");
        }

        [OneTimeTearDown]
        public void GlobalTeardown()
        {
            log.Info("Test Execution Finished");
        }
    }
}
