using CodedUITestApplication.Shared.Resources;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;
using System.Linq;

namespace CodedUITestTestApplication.Tests
{
    [CodedUITest]
    public class WebTests
    {
        private TestContext _testContextInstance;
        public TestContext TestContext
        {
            get { return _testContextInstance; }
            set { _testContextInstance = value; }
        }

        protected string StartUrl = ConfigurationManager.AppSettings["ApplicationStartUrl"];

        [TestMethod, DataSource("Browsers")]
        public void WebTest_TestForm()
        {
            var browserIdentifier = "IE";
            if (TestContext.DataRow != null)
            {
                browserIdentifier = TestContext.DataRow[0].ToString();
            }
            BrowserWindow.CurrentBrowser = browserIdentifier;
            BrowserWindow browser = BrowserWindow.Launch(new Uri(StartUrl));

            var nameTextBox = new HtmlEdit(browser);
            nameTextBox.SearchProperties.Add(HtmlControl.PropertyNames.Id, "Name");
            nameTextBox.Text = "Some Name";

            var submitButton = new HtmlButton(browser);
            submitButton.SearchProperties.Add(HtmlButton.PropertyNames.Type, "submit");
            Mouse.Click(submitButton);

            var header = new HtmlControl(browser);
            header.SearchProperties.Add(HtmlControl.PropertyNames.Id, "addCustomerHeader");
            Assert.IsTrue(header.TryFind());

            var nameValidationmessage = new HtmlSpan(browser);
            nameValidationmessage.SearchProperties.Add(HtmlControl.PropertyNames.Id, "Name-error");
            Assert.IsFalse(nameValidationmessage.TryFind());

            var expectedEmailvalidationMessage = string.Format(Messages.FieldRequired, Labels.EmailAddress);
            var emailAddessValidationMessage = new HtmlSpan(browser);
            emailAddessValidationMessage.SearchProperties.Add(HtmlControl.PropertyNames.Class, "field-validation-error");
            emailAddessValidationMessage.SearchProperties.Add(HtmlControl.PropertyNames.InnerText, expectedEmailvalidationMessage, PropertyExpressionOperator.Contains);

            Assert.IsTrue(emailAddessValidationMessage.TryFind());
            Assert.IsTrue(emailAddessValidationMessage.InnerText.Equals(expectedEmailvalidationMessage));
        }

        [TestMethod, DataSource("Browsers")]
        public void WebTest_Selenium_TestForm()
        {
            var browserIdentifier = "Chrome";
            if (TestContext.DataRow != null)
            {
                browserIdentifier = TestContext.DataRow[0].ToString();
            }

            var driver = StartWebdriver(browserIdentifier);

            driver.Navigate().GoToUrl(new Uri(StartUrl));

            var nameTextBox = driver.FindElement(By.Id("Name"));
            nameTextBox.SendKeys("Some Name");

            var submitButton = driver.FindElement(By.TagName("button"));
            submitButton.Click();

            var header = driver.FindElement(By.Id("addCustomerHeader"));
            Assert.IsTrue(header.Displayed);

            Assert.AreEqual(0, driver.FindElements(By.Id("Name-error")).Count);

            var expectedEmailvalidationMessage = string.Format(Messages.FieldRequired, Labels.EmailAddress);
            var validationMessages = driver.FindElements(By.CssSelector(".field-validation-error"));
            Assert.IsTrue(validationMessages.Any(element => element.Displayed && ChildSpanContainsExpectedText(element, expectedEmailvalidationMessage)));

            driver.Close();
        }

        private static bool ChildSpanContainsExpectedText(IWebElement element, string expectedEmailvalidationMessage)
        {
            return element.FindElement(By.TagName("span")).Text.Equals(expectedEmailvalidationMessage);
        }

        private IWebDriver StartWebdriver(string browserIdentifier)
        {
            switch (browserIdentifier)
            {
                case "IE":
                    return new InternetExplorerDriver();
                case "Firefox":
                    return new FirefoxDriver();
                case "Chrome":
                    return new ChromeDriver();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
