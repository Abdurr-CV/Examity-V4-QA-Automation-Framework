using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;
namespace PortalApplicationFramework
{
    class ScheduledExamsMonthlyTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void SceduledExamsMonthlyTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expMonth = getDataParser().extractDataMonthlyReportsDateSelection("expMonth");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");

            ScheduledExamsMonthlyPage scheduledExamsMonthlyPage = new ScheduledExamsMonthlyPage(driver);
            scheduledExamsMonthlyPage.navigateToScheduledExamsPage(reportTab, LoginpageUrl);
            int x = Int32.Parse(expClient);
            scheduledExamsMonthlyPage.selectClientDropdown(x);
            scheduledExamsMonthlyPage.selectMonthDropdown(expMonth);
            scheduledExamsMonthlyPage.selectYearDropdown(expYear);
            scheduledExamsMonthlyPage.selectSearch();
        }
    }
}
