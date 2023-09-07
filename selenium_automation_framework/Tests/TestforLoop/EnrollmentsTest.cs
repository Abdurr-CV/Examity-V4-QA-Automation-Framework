using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;
using System.Collections.Generic;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class EnrollmentsTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void EnrollmentsTestPage(IWebDriver driver)
        {
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expInstructor = getDataParser().extractDataEnrollments("expInstructor");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            EnrollmentsPage enrollmentsPage = new EnrollmentsPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            enrollmentsPage.navigateToEnrollmentspage(userName, password, adminUserName, adminPassword, LoginAs);
            int x = Int32.Parse(expClient);
            enrollmentsPage.selectClientDropdown(x);
            enrollmentsPage.selectInstructorsDropdown(expInstructor);
            enrollmentsPage.selectSearch(expError, email);
        }
    }
}
