using NUnit.Framework;
using RevideWorkTest.Tests.Resources;
using RevideWorkTest.Tests.Resources.Models;
using RevideWorkTest.Tests.Resources.PageObjects;
using System;

namespace RevideWorkTest.Tests.Tests
{
    [TestFixture]
    public class UserRegistrationTests : TestBase
    {
        RestClientHelper restRequest = new RestClientHelper();

        [TestCase]
        public void CreateUserAccount_Successfull()
        {
            UserModel userRegData = createRandomUserData();

            RegistrationPage regPage = new RegistrationPage(driver, baseURL);
            regPage.goToPage();
            regPage.addFirstName(userRegData.FirstName);
            regPage.addLastName(userRegData.LastName);
            regPage.addEmail(userRegData.Email);
            regPage.addmobilePhone(userRegData.MobilePhone);
            regPage.submitRegistrationForm();

            RegistrationCompletedPage regCompletedPage = new RegistrationCompletedPage(driver);
            regCompletedPage.verifyRegistrationSuccessMessage();

            var regCompletedData = restRequest.verifyRegistration(userRegData.Email);
            Assert.IsTrue(regCompletedData.TotalResults == 1);

            verifyUserRegistrationData(userRegData, regCompletedData.Results[0]);
        }

        [TestCase("", "E-post är obligatoriskt")]
        [TestCase("testemail", "Inte en giltig e-postadress")]
        public void CreateUserAccount_EmailFieldValidationError(string email, string errorMessage)
        {
            UserModel userRegData = createRandomUserData();
            userRegData.Email = email;

            RegistrationPage regPage = new RegistrationPage(driver, baseURL);
            regPage.goToPage();
            regPage.addFirstName(userRegData.FirstName);
            regPage.addLastName(userRegData.LastName);
            regPage.addEmail(userRegData.Email);
            regPage.addmobilePhone(userRegData.MobilePhone);
            regPage.submitRegistrationForm();

            regPage.VerifyValidationErrorMessage(errorMessage);

            var regCompletedData = restRequest.verifyRegistration(userRegData.Email);
            Assert.IsTrue(regCompletedData.TotalResults == 0);
        }

        [TestCase("", "Förnamn är obligatoriskt")]
        public void CreateUserAccount_FirstNameFieldValidationError(string firstName, string errorMessage)
        {
            UserModel userRegData = createRandomUserData();
            userRegData.FirstName = firstName;

            RegistrationPage regPage = new RegistrationPage(driver, baseURL);
            regPage.goToPage();
            regPage.addFirstName(userRegData.FirstName);
            regPage.addLastName(userRegData.LastName);
            regPage.addEmail(userRegData.Email);
            regPage.addmobilePhone(userRegData.MobilePhone);
            regPage.submitRegistrationForm();

            regPage.VerifyValidationErrorMessage(errorMessage);

            var regCompletedData = restRequest.verifyRegistration(userRegData.Email);
            Assert.IsTrue(regCompletedData.TotalResults == 0);
        }

        [TestCase]
        public void CreateUserAccount_VerifyDuplicateRegistration()
        {
            UserModel userRegData = createRandomUserData();

            for (int i = 0; i < 3; i++)
            {

                RegistrationPage regPage = new RegistrationPage(driver, baseURL);
                regPage.goToPage();
                regPage.addFirstName(userRegData.FirstName);
                regPage.addLastName(userRegData.LastName);
                regPage.addEmail(userRegData.Email);
                regPage.addmobilePhone(userRegData.MobilePhone);
                regPage.submitRegistrationForm();

                if (i == 0)
                {
                    RegistrationCompletedPage regCompletedPage = new RegistrationCompletedPage(driver);
                    regCompletedPage.verifyRegistrationSuccessMessage();

                }
                else if (i > 0)
                {
                    regPage.VerifyValidationErrorMessage("Du finns redan registrerad");
                }

                var regCompletedData = restRequest.verifyRegistration(userRegData.Email);
                Assert.IsTrue(regCompletedData.TotalResults == 1);

                verifyUserRegistrationData(userRegData, regCompletedData.Results[0]);
            }
        }


    }
}
