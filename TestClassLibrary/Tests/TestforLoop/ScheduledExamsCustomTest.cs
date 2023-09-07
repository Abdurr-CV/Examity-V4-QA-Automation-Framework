using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;

namespace PortalApplicationFramework
{
    class ScheduledExamsCustomTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ScheduledExamsCustomTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");

            ScheduledExamsCustomPage schedulesExamsCustomPagePage = new ScheduledExamsCustomPage(driver);
            schedulesExamsCustomPagePage.navigateToScheduledExamsPage(reportTab, LoginpageUrl);
            int x = Int32.Parse(expClient);
            schedulesExamsCustomPagePage.selectClientDropdown(x);
            schedulesExamsCustomPagePage.selectFromDate(expFromDate);
            schedulesExamsCustomPagePage.selectToDate();
            schedulesExamsCustomPagePage.selectSearch();
        }
    }
}
