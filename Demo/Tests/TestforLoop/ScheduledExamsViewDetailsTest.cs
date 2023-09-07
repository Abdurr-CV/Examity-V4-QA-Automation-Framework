using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;

namespace PortalApplicationFramework
{
    class ScheduledExamsViewDetailsTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ScheduledExamsViewDetailsTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expMonth = getDataParser().extractDataMonthlyReportsDateSelection("expMonth");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");

            ScheduledExamsViewDetailsPage scheduledExamsViewDetailsPage = new ScheduledExamsViewDetailsPage(driver);
            scheduledExamsViewDetailsPage.navigateToScheduledExamsPage(reportTab, LoginpageUrl);
            int x = Int32.Parse(expClient);
            scheduledExamsViewDetailsPage.selectClientDropdown(x);
            scheduledExamsViewDetailsPage.selectMonthDropdown(expMonth);
            scheduledExamsViewDetailsPage.selectYearDropdown(expYear);
            scheduledExamsViewDetailsPage.selectSearch(expError, email, reportTab);
        }
    }
}
