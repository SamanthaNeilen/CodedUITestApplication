using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodedUITestTestApplication.Tests
{
    [CodedUITest]
    public class WindowsAppTests
    {
        [TestMethod]
        public void Test_Windows_Calculator()
        {
            var app = ApplicationUnderTest.Launch(@"C:\Windows\system32\calc.exe");

            var button5 = new WinButton(app);
            button5.SearchProperties.Add(WinControl.PropertyNames.Name, "5");
            Mouse.Click(button5);

            var buttonPlus = new WinButton(app);
            buttonPlus.SearchProperties.Add(WinControl.PropertyNames.Name, "Add");
            Mouse.Click(buttonPlus);

            Mouse.Click(button5);

            var buttonEquals = new WinButton(app);
            buttonEquals.SearchProperties.Add(WinControl.PropertyNames.Name, "Equals");
            Mouse.Click(buttonEquals);

            var resultText = new WinText(app);
            resultText.SearchProperties.Add(WinControl.PropertyNames.Name, "Result");
            Assert.AreEqual("10", resultText.DisplayText);
        }


        [TestMethod]
        public void Test_WPF_Addition()
        {
            var app = ApplicationUnderTest.Launch(@"..\..\..\CodedUITestApplication.WPF\bin\Debug\CodedUITestApplication.WPF.exe");

            var amount1Edit = new WpfEdit(app);
            amount1Edit.SearchProperties.Add(WpfEdit.PropertyNames.AutomationId, "txtFirstAmount");
            amount1Edit.Text = "5";

            var amount2Edit = new WpfEdit(app);
            amount2Edit.SearchProperties.Add(WpfEdit.PropertyNames.AutomationId, "txtSecondAmount");
            amount2Edit.Text = "10";

            var buttonPlus = new WpfButton(app);
            buttonPlus.SearchProperties.Add(WpfEdit.PropertyNames.AutomationId, "btnAdd");
            Mouse.Click(buttonPlus);

            var resultLabel = new WpfText(app);
            resultLabel.SearchProperties.Add(WpfEdit.PropertyNames.AutomationId, "lblResult");
            Assert.AreEqual("15", resultLabel.DisplayText);
        }
    }
}
