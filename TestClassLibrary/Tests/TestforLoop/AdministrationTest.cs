using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;

namespace PortalApplicationFramework
{
    public class AdministrationTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void AdministrationTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expEmail = getDataParser().extractDataAdministration("expEmail");
            string expUserID = getDataParser().extractDataAdministration("expUserID");
            string fName = getDataParser().extractDataAdministration("fName");
            string lName = getDataParser().extractDataAdministration("lName");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");

            AdministrationPage administrationPage = new AdministrationPage(driver);
            administrationPage.navigateToAdministrationpage(LoginpageUrl);
            int x = Int32.Parse(expClient);
            administrationPage.selectClientDropdown(x);
            administrationPage.typeEmailAddress(expEmail);
            administrationPage.typeUserID(expUserID);
            administrationPage.typeFirstName(fName);
            administrationPage.typeLastName(lName);
            administrationPage.selectSearch(expError, email, reportTab);
        }
    }
}
