using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Communication;
using OpenQA.Selenium.Firefox;

namespace LoggingAutomation.Framework
{
    public static class DriverFactory
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        public static IWebDriver GetDriver(string browser = "Chrome")
        {
            if (_driver == null)
            {
                switch (browser.ToLower())
                {
                    case "chrome":
                        _driver = new ChromeDriver();
                        break;
                    case "firefox":
                        _driver = new FirefoxDriver();
                        break;
                    default:
                        throw new ArgumentException($"Unsupported browser: {browser}");
                }
            }
            _driver.Manage().Window.Maximize();
            return _driver;
        }

        public static void QuitDriver()
        {
            _driver?.Quit();
        }
    }
}
