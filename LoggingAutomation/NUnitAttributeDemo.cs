using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace LoggingAutomation
{
    [TestFixture]
    public class NUnit1
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            Console.WriteLine("One-time setup before all tests.");
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test, Category("Smoke")]
        public void ValidLoginTest()
        {
            // Arrange
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            // Act
            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            // Assert
            string message = driver.FindElement(By.Id("flash")).Text;
            Assert.IsTrue(message.Contains("You logged into a secure area!"));
        }

        [Test, Category("Regression"), Ignore("Temporarily disabled for maintenance")]
        public void InvalidLoginTest()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            driver.FindElement(By.Id("username")).SendKeys("wronguser");
            driver.FindElement(By.Id("password")).SendKeys("wrongpass");
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            string errorMessage = driver.FindElement(By.Id("flash")).Text;
            Assert.IsTrue(errorMessage.Contains("Your username is invalid!"));
        }

        [Test, Explicit("Run manually when needed"), Category("EdgeCase")]
        public void ManualOnlyTest()
        {
            Console.WriteLine("This test runs only when explicitly executed.");
            Assert.Pass("Manual test passed.");
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }

        [OneTimeTearDown]
        public void OneTimeTeardown()
        {
            Console.WriteLine("One-time cleanup after all tests.");
        }
    }
}
