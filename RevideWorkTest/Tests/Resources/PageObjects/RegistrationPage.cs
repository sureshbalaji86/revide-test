using NUnit.Framework;
using OpenQA.Selenium;

namespace RevideWorkTest.Tests.Resources.PageObjects
{
    public class RegistrationPage
    {
        private IWebDriver driver;
        private string url;
        By firstName = By.Id("attr_firstName_Value");
        By lastName = By.Id("attr_lastName_Value");
        By email = By.Id("attr_email_Value");
        By mobilePhone = By.Id("attr_mobilePhone_Value");
        By submitButton = By.Id("submitBtn");
        By validationErrorMsg = By.XPath("//span[contains(@class,'field-validation-error')]");

        public RegistrationPage(IWebDriver driver, string url)
        {
            this.driver = driver;
            this.url = url;
        }

        public void goToPage()
        {
            driver.Navigate().GoToUrl(url);
        }
        public void addFirstName(string FirstName)
        {
            var firstNameElement = driver.FindElement(firstName, 10);
            Assert.IsTrue(firstNameElement.Displayed, "FirstName is not displayed");
            Assert.IsTrue(string.Equals(firstNameElement.GetAttribute("placeholder"), "Förnamn"), "The Firstname placeholder is not as expected");
            firstNameElement.Click();
            firstNameElement.Clear();
            firstNameElement.SendKeys(FirstName);
        }
        public void addLastName(string LastName)
        {
            var lastNameElement = driver.FindElement(lastName, 10);
            Assert.IsTrue(lastNameElement.Displayed, "lastNameElement is not displayed");
            Assert.IsTrue(string.Equals(lastNameElement.GetAttribute("placeholder"), "Efternamn"));
            lastNameElement.Click();
            lastNameElement.Clear();
            lastNameElement.SendKeys(LastName);
        }
        public void addEmail(string Email)
        {
            var emailElement = driver.FindElement(email, 10);
            Assert.IsTrue(emailElement.Displayed, "emailElement is not displayed");
            Assert.IsTrue(string.Equals(emailElement.GetAttribute("placeholder"), "E-post"));
            emailElement.Click();
            emailElement.Clear();
            emailElement.SendKeys(Email);
        }
        public void addmobilePhone(string MobilePhone)
        {
            var mobilePhoneElement = driver.FindElement(mobilePhone, 10);
            Assert.IsTrue(mobilePhoneElement.Displayed, "mobilePhoneElement is not displayed");
            Assert.IsTrue(string.Equals(mobilePhoneElement.GetAttribute("placeholder"), "Mobiltelefon"));
            mobilePhoneElement.Click();
            mobilePhoneElement.Clear();
            mobilePhoneElement.SendKeys(MobilePhone);
        }
        public void submitRegistrationForm()
        {
            var submitButtonElement = driver.FindElement(submitButton, 10);
            Assert.IsTrue(submitButtonElement.Displayed, "Submit Button is not displayed");
            submitButtonElement.Click();
        }

        public void VerifyValidationErrorMessage(string expectedMessage)
        {
            IWebElement inlineError = driver.FindElement(validationErrorMsg);

            bool isErrorShown = false;

            if (inlineError.Text.Contains(expectedMessage))

            {

                isErrorShown = true;

            }

            Assert.AreEqual(true, isErrorShown);
        }
    }
}
