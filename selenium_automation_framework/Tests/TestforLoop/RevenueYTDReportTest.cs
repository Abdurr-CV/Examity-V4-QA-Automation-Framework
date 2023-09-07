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
    class RevenueYTDReportTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void RevenueYTDReportTestPage(IWebDriver driver)

        {
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            RevenueYTDReportPage revenueYTDReportPage = new RevenueYTDReportPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            revenueYTDReportPage.navigateToRevenueYTDReportpage(userName, password, adminUserName, adminPassword, LoginAs);
            /*int x = Int32.Parse(expClient);
            revenueYTDReportPage.selectClientDropdown(x);*/
            revenueYTDReportPage.selectYearDropdown(expYear);
            revenueYTDReportPage.selectSearch(expError, email);
        }
    }
}
