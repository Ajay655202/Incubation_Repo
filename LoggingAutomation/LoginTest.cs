using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace LoggingAutomation
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class LoginTest : BaseTest
    {
        [Test]
        public void LoginToApp()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            string successMsg = driver.FindElement(By.CssSelector(".flash.success")).Text;
            Assert.IsTrue(successMsg.Contains("You logged into a secure area!"));

            Console.WriteLine("Login successful in browser.");
        }
    }
}
