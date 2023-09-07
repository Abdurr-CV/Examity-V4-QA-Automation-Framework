using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class RevenueReportTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void RevenueReportTestPage(IWebDriver driver)
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

            RevenueReportPage revenueReportPage = new RevenueReportPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            string randomclient = clientSelectionPage.ClientSelectionrandomly();
            TestContext.Progress.WriteLine(randomclient);
            revenueReportPage.navigateToRevenueReportpage(userName, password, adminUserName, adminPassword, LoginAs);
            /*int x = Int32.Parse(expClient);
            revenueReportPage.selectClientDropdown(x);*/
            revenueReportPage.selectMonthDropdown(expMonth);
            revenueReportPage.selectYearDropdown(expYear);
            revenueReportPage.selectSearch(expError, email);
        }
    }
}
