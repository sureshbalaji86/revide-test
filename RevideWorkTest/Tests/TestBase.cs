using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RevideWorkTest.Tests.Resources.Models;
using System;
using System.Text;

namespace RevideWorkTest.Tests
{
    [TestFixture]
    public abstract class TestBase
    {
        public IWebDriver driver;
        private StringBuilder verificationErrors;
        public string baseURL;
        private Random random = new Random();

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            baseURL = "https://revidetest.customer.eclub.se/open/registration/register/084e3810-da2f-42da-9acb-aa4200e101b7";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        protected UserModel createRandomUserData()
        {
            string randomNumber = random.Next(1111, 9999).ToString();
            UserModel userModel = new UserModel();
            userModel.FirstName = "firstName" + randomNumber;
            userModel.LastName = "lastName" + randomNumber;
            userModel.Email = "test" + randomNumber + "@example.com";
            userModel.MobilePhone = "076309" + randomNumber;

            return userModel;
        }

        protected void verifyUserRegistrationData(UserModel preRegdata, UserModel postRegdata)
        {
            Assert.IsTrue(string.Equals(preRegdata.FirstName, postRegdata.FirstName));
            Assert.IsTrue(string.Equals(preRegdata.LastName, postRegdata.LastName));
            Assert.IsTrue(string.Equals(preRegdata.Email, postRegdata.Email));
            Assert.IsTrue(string.Equals("46" + preRegdata.MobilePhone.Substring(1), postRegdata.MobilePhone));
            Assert.IsNotNull(postRegdata.ExternalId);
            Assert.IsNotNull(postRegdata.Id);
        }
    }
}
