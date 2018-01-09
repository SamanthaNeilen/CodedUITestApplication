using CodedUITestApplication.Shared.Resources;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;

namespace CodedUITestTestApplication.Tests
{
    [CodedUITest]
    public class WebTests
    {
        protected string StartUrl = ConfigurationManager.AppSettings["ApplicationStartUrl"];

        [TestMethod]
        public void WebTest_TestForm()
        {
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

            var expectedEmailMessage = string.Format(Messages.FieldRequired, Labels.EmailAddress);
            Assert.IsTrue(emailAddessValidationMessage.InnerText.Equals(expectedEmailMessage));
        }
    }
}
