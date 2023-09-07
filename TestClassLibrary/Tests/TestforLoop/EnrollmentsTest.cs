using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;

namespace PortalApplicationFramework
{
    public class EnrollmentsTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void EnrollmentsTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expInstructor = getDataParser().extractDataEnrollments("expInstructor");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");

            EnrollmentsPage enrollmentsPage = new EnrollmentsPage(driver);
            enrollmentsPage.navigateToEnrollmentspage(reportTab, LoginpageUrl);
            int x = Int32.Parse(expClient);
            enrollmentsPage.selectClientDropdown(x);
            enrollmentsPage.selectInstructorsDropdown(expInstructor);
            enrollmentsPage.selectSearch(expError, email, reportTab);
        }
    }
}
