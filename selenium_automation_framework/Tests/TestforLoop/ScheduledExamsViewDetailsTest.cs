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
    class ScheduledExamsViewDetailsTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ScheduledExamsViewDetailsTestPage(IWebDriver driver)

        {
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expMonth = getDataParser().extractDataMonthlyReportsDateSelection("expMonth");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            ScheduledExamsViewDetailsPage scheduledExamsViewDetailsPage = new ScheduledExamsViewDetailsPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            scheduledExamsViewDetailsPage.navigateToScheduledExamsPage(userName, password, adminUserName, adminPassword, LoginAs);
            int x = Int32.Parse(expClient);
            scheduledExamsViewDetailsPage.selectClientDropdown(x);
            scheduledExamsViewDetailsPage.selectMonthDropdown(expMonth);
            scheduledExamsViewDetailsPage.selectYearDropdown(expYear);
            scheduledExamsViewDetailsPage.selectSearch(expError, email);
        }
    }
}
