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
    class RevenueCustomReportTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void RevenueCustomReportTestPage(IWebDriver driver)

        {
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string email = getDataParser().extractDataLoginCredentials("email");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");
            

            RevenueCustomReportPage revenueCustomReportPage = new RevenueCustomReportPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            revenueCustomReportPage.navigateToRevenueCustomReportpage(userName, password, adminUserName, adminPassword, LoginAs);
            /*int x = Int32.Parse(expClient);
            revenueCustomReportPage.selectClientDropdown(x);*/
            revenueCustomReportPage.selectYearDropdown(expYear);
            revenueCustomReportPage.selectSearch(email);
        }
    }
}
