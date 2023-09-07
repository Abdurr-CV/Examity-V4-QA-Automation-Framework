using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.PageObjects.BillingSummaryPage;
using PortalApplicationFramework.Utilities;
using System;
using System.Collections.Generic;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class BillingSummaryTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void BillingSummaryTestPage(IWebDriver driver)

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

            BillingSummaryPage billingSummaryPage = new BillingSummaryPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            billingSummaryPage.navigateToRevenueReportpage(userName, password, adminUserName, adminPassword, LoginAs);
            /*int x = Int32.Parse(expClient);
            billingSummaryPage.selectClientDropdown(x);*/
            billingSummaryPage.selectMonthDropdown(expMonth);
            billingSummaryPage.selectYearDropdown(expYear);
            billingSummaryPage.selectSearch(expError, email);
        }
    }
}
