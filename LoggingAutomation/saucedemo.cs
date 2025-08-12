using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Security.Policy;
using System.IO;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;

namespace LoggingAutomation
{
    internal class saucedemo
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void CompletePurchaseFlow()
        {
            try
            {
                // 1. Login Page
                driver.Navigate().GoToUrl("https://www.saucedemo.com/");

                driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
                driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
                driver.FindElement(By.Id("login-button")).Click();

                // 2. Select First Item, Note Price, Add to Cart
                IWebElement firstItemPriceElement = driver.FindElement(By.ClassName("inventory_item_price"));
                string selectedItemPrice = firstItemPriceElement.Text;
                Console.WriteLine("Selected Item Price: " + selectedItemPrice);

                // Add to cart
                driver.FindElement(By.CssSelector("button.btn_inventory")).Click();

                // 3. Go to Cart
                driver.FindElement(By.ClassName("shopping_cart_link")).Click();

                // Verify price in cart
                IWebElement cartPriceElement = driver.FindElement(By.ClassName("inventory_item_price"));
                string cartPrice = cartPriceElement.Text;
                Console.WriteLine("Cart Page Price: " + cartPrice);
                Assert.AreEqual(selectedItemPrice, cartPrice, "Price mismatch in Cart");

                // 4. Click Checkout
                driver.FindElement(By.Id("checkout")).Click();

                // 5. Enter Checkout Details
                driver.FindElement(By.Id("first-name")).SendKeys("Test");
                driver.FindElement(By.Id("last-name")).SendKeys("User");
                driver.FindElement(By.Id("postal-code")).SendKeys("12345");
                driver.FindElement(By.Id("continue")).Click();

                // 6. Verify Price on Checkout Overview Page
                IWebElement overviewPriceElement = driver.FindElement(By.ClassName("inventory_item_price"));
                string checkoutPrice = overviewPriceElement.Text;
                Console.WriteLine("Checkout Overview Price: " + checkoutPrice);
                Assert.AreEqual(selectedItemPrice, checkoutPrice, "Price mismatch in Checkout Overview");

                // 7. Finish Order
                driver.FindElement(By.Id("finish")).Click();

                // Confirmation
                IWebElement completeHeader = driver.FindElement(By.ClassName("complete-header"));
                Assert.IsTrue(completeHeader.Displayed && completeHeader.Text.Contains("Thank you"),
                    "Order confirmation not displayed.");

                Console.WriteLine("Test completed successfully");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed: " + ex.Message);
            }
        }

        [Test]
        public void ValidLoginTest()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            // Enter valid credentials
            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            // Verify success message
            IWebElement successMsg = wait.Until(
                d => d.FindElement(By.Id("flash"))
            );

            Assert.IsTrue(successMsg.Text.Contains("Welcome to the Secure Area"),
                "Login success message not found.");

            Console.WriteLine("Valid login successful!");

            // Logout
            driver.FindElement(By.CssSelector("i[class*='icon-signout']")).Click();
        }

        [Test]
        public void InvalidLoginTest()
        {

            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");

            // Enter invalid credentials
            driver.FindElement(By.Id("username")).SendKeys("invalidUser");
            driver.FindElement(By.Id("password")).SendKeys("wrongPassword!");
            driver.FindElement(By.CssSelector("button[type='submit']")).Click();

            // Verify error message
            IWebElement errorMsg = wait.Until(
                d => d.FindElement(By.Id("flash"))
            );

            Assert.IsTrue(errorMsg.Text.Contains("Your username is invalid!") ||
                          errorMsg.Text.Contains("Your password is invalid!"),
                "Invalid login message not found.");

            Console.WriteLine("Invalid login handled correctly.");
        }

        [Test]
        public void SelectDropdownOptions()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/select-menu");
            // Modern Select One Dropdown
            IWebElement selectOneDropdown = driver.FindElement(By.Id("selectOne"));
            selectOneDropdown.Click();
            IWebElement selectOneOption = driver.FindElement(By.XPath("//div[contains(@id, 'react-select-3-option-0')]"));
            selectOneOption.Click();

            string selectedOne = driver.FindElement(By.CssSelector("#selectOne .css-1uccc91-singleValue")).Text;
            Assert.AreEqual("Dr.", selectedOne);
            Console.WriteLine("Selected from 'Select One': " + selectedOne);

            // Modern Multi-Select (Value)
            IWebElement valueDropdown = driver.FindElement(By.Id("react-select-2-input"));
            valueDropdown.SendKeys("Group");
            valueDropdown.SendKeys(Keys.Enter);

            var selectedValues = driver.FindElements(By.CssSelector("#withOptGroup div[class*='singleValue']"));
            Assert.IsTrue(selectedValues.Any(v => v.Text.Contains("Group")));
            Console.WriteLine("Selected from multi-value dropdown: Group");

            //Old Style Select Menu

            var oldSelect = new SelectElement(driver.FindElement(By.Id("oldSelectMenu")));
            oldSelect.SelectByText("Blue");
            Assert.AreEqual("Blue", oldSelect.SelectedOption.Text);
            Console.WriteLine("Old select dropdown selected: " + oldSelect.SelectedOption.Text);

            // Multiselect Dropdown
            IWebElement multiselectInput = driver.FindElement(By.XPath("//div[text()='Select...']/..//input"));
            multiselectInput.SendKeys("Red");
            multiselectInput.SendKeys(Keys.Enter);
            multiselectInput.SendKeys("Black");
            multiselectInput.SendKeys(Keys.Enter);

            var selectedTags = driver.FindElements(By.CssSelector("div[class*='multiValue'] div"));
            var selectedTexts = selectedTags.Select(t => t.Text).ToList();
            Assert.IsTrue(selectedTexts.Contains("Red") && selectedTexts.Contains("Black"));
            Console.WriteLine("Modern multi-select selected: " + string.Join(", ", selectedTexts));

            // Standard Multi Select
            var stdMultiSelect = new SelectElement(driver.FindElement(By.Id("cars")));
            if (stdMultiSelect.IsMultiple)
            {
                stdMultiSelect.DeselectAll();
                stdMultiSelect.SelectByValue("volvo");
                stdMultiSelect.SelectByValue("audi");

                var selectedOptions = stdMultiSelect.AllSelectedOptions.Select(o => o.Text).ToList();
                Assert.IsTrue(selectedOptions.Contains("Volvo") && selectedOptions.Contains("Audi"));
                Console.WriteLine("Standard multi-select options: " + string.Join(", ", selectedOptions));
            }
        }

        [Test]
        public void ClickSeleniumTestingAndProcessResults()
        {
            driver.Navigate().GoToUrl("https://www.seleniumeasy.com/lander");

            driver.SwitchTo().Frame(1);

            var links = wait.Until(d => d.FindElements(By.XPath("//img/ancestor::a")));
            Logging.log.Info("Found results: " + links.Count);

            foreach (var link in links)
            {
                Logging.log.Info($"Title: {link.Text}, URL: {link.GetAttribute("href")}");
            }

            Assert.IsTrue(links.Count >= 2, "Less than 2 results found.");

            links[1].Click();
            Logging.log.Info("Navigated to second result page: " + driver.Title);
        }

        [Test]
        public void UploadAndDownloadFile()
        {

            string sampleFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sample-upload.txt");
            if (!File.Exists(sampleFilePath))
                File.WriteAllText(sampleFilePath, "This is a test file for upload.");

            driver.Navigate().GoToUrl("https://demoqa.com/upload-download");

            //Upload file
            IWebElement uploadInput = driver.FindElement(By.Id("uploadFile"));
            uploadInput.SendKeys(sampleFilePath);

            string uploadedText = driver.FindElement(By.Id("uploadedFilePath")).Text;
            Assert.IsTrue(uploadedText.Contains("sample-upload.txt"));
            Console.WriteLine("Uploaded File Verified: " + uploadedText);

            //Download file
            string beforeDownloadFile = GetLatestFileInDownloadDir();

            driver.FindElement(By.Id("downloadButton")).Click();

            Thread.Sleep(3000);

            string afterDownloadFile = GetLatestFileInDownloadDir();

            Assert.AreNotEqual(beforeDownloadFile, afterDownloadFile, "Download file not detected");
            Console.WriteLine("Downloaded File Detected: " + Path.GetFileName(afterDownloadFile));
        }

        private string GetLatestFileInDownloadDir()
        {
            string downloadDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Downloads");
            if (!Directory.Exists(downloadDirectory))
            {
                Directory.CreateDirectory(downloadDirectory);
            }
            var dirInfo = new DirectoryInfo(downloadDirectory);
            var file = dirInfo.GetFiles()
                              .OrderByDescending(f => f.LastWriteTime)
                              .FirstOrDefault();

            return file?.FullName ?? string.Empty;
        }

        [Test]
        public void HandleJavaScriptAlerts()
        {
            driver.Navigate().GoToUrl("https://demoqa.com/alerts");
            // Alert 1: Simple Alert
            driver.FindElement(By.Id("alertButton")).Click();

            IAlert alert1 = wait.Until(ExpectedConditions.AlertIsPresent());
            Assert.AreEqual("You clicked a button", alert1.Text);
            Console.WriteLine("Alert 1 text verified: " + alert1.Text);
            alert1.Accept();

            //Alert 2: Timed Alert
            driver.FindElement(By.Id("timerAlertButton")).Click();

            IAlert alert2 = wait.Until(ExpectedConditions.AlertIsPresent());
            Assert.AreEqual("This alert appeared after 5 seconds", alert2.Text);
            Console.WriteLine("Alert 2 text verified: " + alert2.Text);
            alert2.Accept();

            //Alert 3: Confirm Alert – CANCEL
            driver.FindElement(By.Id("confirmButton")).Click();

            IAlert alert3 = wait.Until(ExpectedConditions.AlertIsPresent());
            Assert.AreEqual("Do you confirm action?", alert3.Text);
            Console.WriteLine("Alert 3 text verified: " + alert3.Text);
            alert3.Dismiss();

            string confirmResult = driver.FindElement(By.Id("confirmResult")).Text;
            Assert.IsTrue(confirmResult.Contains("Cancel"));
            Console.WriteLine("Alert 3 cancel result: " + confirmResult);

            //Alert 4: Prompt Alert – Enter text + OK
            driver.FindElement(By.Id("promtButton")).Click();

            IAlert alert4 = wait.Until(ExpectedConditions.AlertIsPresent());
            Assert.AreEqual("Please enter your name", alert4.Text);
            alert4.SendKeys("John Doe");
            alert4.Accept();

            string promptResult = driver.FindElement(By.Id("promptResult")).Text;
            Assert.IsTrue(promptResult.Contains("Ajay"));
            Console.WriteLine("Prompt alert result: " + promptResult);
        }

        [Test]
        public void SearchBookUsingShadowDOM()
        {
            var js = (IJavaScriptExecutor)driver;

            string searchQuery = "Python";

            // Access <book-app> > #input element inside nested shadow DOM
            string script = @"
                const bookApp = document.querySelector('book-app');
                const shadowRoot1 = bookApp.shadowRoot;
                const appHeader = shadowRoot1.querySelector('app-header');
                const appToolbar = appHeader.shadowRoot.querySelector('app-toolbar');
                const bookInput = shadowRoot1.querySelector('book-input');
                const inputField = bookInput.shadowRoot.querySelector('input');
                inputField.value = '" + searchQuery + @"';
                inputField.dispatchEvent(new Event('input', { bubbles: true }));
            ";

            js.ExecuteScript(script);

            // Wait a bit to allow results to load
            Thread.Sleep(3000);

            Console.WriteLine("Book search for '" + searchQuery + "' submitted via Shadow DOM input.");
        }

        [Test]
        public void ScrollAndValidateNewContent()
        {

            var js = (IJavaScriptExecutor)driver;

            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/infinite_scroll");

            Actions actions = new Actions(driver);

            int scrollsNeeded = 10;
            int initialParagraphs = driver.FindElements(By.ClassName("jscroll-added")).Count;

            for (int i = 0; i < scrollsNeeded; i++)
            {
                js.ExecuteScript("window.scrollBy(0, 1000);");

                actions.SendKeys(Keys.PageDown).Perform();

                Thread.Sleep(1500); 
            }

            //Collect paragraphs after scrolling
            var paragraphs = driver.FindElements(By.ClassName("jscroll-added"));

            Assert.GreaterOrEqual(paragraphs.Count, 10, "Not enough paragraphs loaded.");

            Console.WriteLine("Total paragraphs loaded: " + paragraphs.Count);
            Console.WriteLine("\n--- Last 10 Paragraphs ---");

            foreach (var para in paragraphs.Skip(paragraphs.Count - 10))
            {
                Console.WriteLine(para.Text + "\n");
            }
        }

        [TearDown]
        public void Teardown()
        {
            if (driver != null)
                driver.Quit();
        }
    }
}
