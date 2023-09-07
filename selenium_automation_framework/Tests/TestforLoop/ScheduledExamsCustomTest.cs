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
    class ScheduledExamsCustomTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ScheduledExamsCustomTestPage(IWebDriver driver)

        {
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            ScheduledExamsCustomPage schedulesExamsCustomPagePage = new ScheduledExamsCustomPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            schedulesExamsCustomPagePage.navigateToScheduledExamsPage(userName, password, adminUserName, adminPassword, LoginAs);
            int x = Int32.Parse(expClient);
            schedulesExamsCustomPagePage.selectClientDropdown(x);
            schedulesExamsCustomPagePage.selectFromDate(expFromDate);
            schedulesExamsCustomPagePage.selectToDate();
            schedulesExamsCustomPagePage.selectSearch();
        }
    }
}
