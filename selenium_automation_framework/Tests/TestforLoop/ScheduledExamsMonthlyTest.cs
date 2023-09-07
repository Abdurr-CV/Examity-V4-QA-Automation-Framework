using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalApplicationFramework
{
    class ScheduledExamsMonthlyTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void SceduledExamsMonthlyTestPage(IWebDriver driver)

        {
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expMonth = getDataParser().extractDataMonthlyReportsDateSelection("expMonth");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            ScheduledExamsMonthlyPage scheduledExamsMonthlyPage = new ScheduledExamsMonthlyPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            scheduledExamsMonthlyPage.navigateToScheduledExamsPage(userName, password, adminUserName, adminPassword, LoginAs);
            int x = Int32.Parse(expClient);
            scheduledExamsMonthlyPage.selectClientDropdown(x);
            scheduledExamsMonthlyPage.selectMonthDropdown(expMonth);
            scheduledExamsMonthlyPage.selectYearDropdown(expYear);
            scheduledExamsMonthlyPage.selectSearch();
        }
    }
}
