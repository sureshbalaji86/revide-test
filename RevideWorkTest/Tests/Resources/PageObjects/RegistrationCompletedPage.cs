using NUnit.Framework;
using OpenQA.Selenium;

namespace RevideWorkTest.Tests.Resources.PageObjects
{
    public class RegistrationCompletedPage
    {
        private IWebDriver driver;
        private string regSuccessMessage = "Snyggt!\r\nHåll koll på mejlboxen för spännande och informativa kommunikationer från oss.\r\n\r\nVänliga hälsningar, Voyado";
        By content = By.Id("content");
        public RegistrationCompletedPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void verifyRegistrationSuccessMessage()
        {
            var contentElement = driver.FindElement(content, 10);
            Assert.IsTrue(string.Equals(contentElement.Text, regSuccessMessage));
        }
        public string getRegistrationCompletedPageUrl()
        {
            return driver.Url;
        }
    }
}
