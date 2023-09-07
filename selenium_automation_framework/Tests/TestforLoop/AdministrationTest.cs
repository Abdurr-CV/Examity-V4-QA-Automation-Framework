using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;
using System.Collections.Generic;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class AdministrationTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void AdministrationTestPage(IWebDriver driver)
        {
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expEmail = getDataParser().extractDataAdministration("expEmail");
            string expUserID = getDataParser().extractDataAdministration("expUserID");
            string fName = getDataParser().extractDataAdministration("fName");
            string lName = getDataParser().extractDataAdministration("lName");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            AdministrationPage administrationPage = new AdministrationPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            administrationPage.navigateToAdministrationpage(userName, password, adminUserName, adminPassword, LoginAs);
            int x = Int32.Parse(expClient);
            administrationPage.selectClientDropdown(x);
            administrationPage.typeEmailAddress(expEmail);
            administrationPage.typeUserID(expUserID);
            administrationPage.typeFirstName(fName);
            administrationPage.typeLastName(lName);
            administrationPage.selectSearch(expError, email);
        }
    }
}
