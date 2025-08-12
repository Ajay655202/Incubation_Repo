using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace LoggingAutomation
{
    internal class DemoQA
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            string browser = "chrome"; 

            if (browser.ToLower() == "chrome")
            {
                driver = new ChromeDriver();
            }
            else if (browser.ToLower() == "firefox")
            {
                driver = new FirefoxDriver();
            }
            else
            {
                throw new ArgumentException("Unsupported browser: " + browser);
            }

            driver.Manage().Window.Maximize();

            // Implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //Explicit wait
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void GetPageDetailsAndPrint()
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.demoqa.com");

                wait.Until(drv => drv.Title.Contains("DEMOQA"));

                //Get Page Title and Title Length
                string pageTitle = driver.Title;
                int titleLength = pageTitle.Length;
                Console.WriteLine("Page Title: " + pageTitle);
                Console.WriteLine("Title Length: " + titleLength);

                //Get Page URL and URL Length
                string currentUrl = driver.Url;
                int urlLength = currentUrl.Length;
                Console.WriteLine("Page URL: " + currentUrl);
                Console.WriteLine("URL Length: " + urlLength);

                //Get Page Source and Source Length
                string pageSource = driver.PageSource;
                int sourceLength = pageSource.Length;
                Console.WriteLine("Page Source Length: " + sourceLength);
            }
            catch (WebDriverTimeoutException ex)
            {
                Assert.Fail("Timeout waiting for page title. " + ex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed with error: " + ex.Message);
            }
        }

        [TearDown]
        public void Teardown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
