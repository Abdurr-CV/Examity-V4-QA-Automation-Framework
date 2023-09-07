using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;
using System.Collections.Generic;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class ExamSummaryMonthlyTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ExamSummaryMonthlyTestPage(IWebDriver driver)
        {
            string expMonth = getDataParser().extractDataMonthlyReportsDateSelection("expMonth");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expStatus = getDataParser().extractDataExamSummaryMonthly("expStatus");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            ExamSummaryMonthlyPage examSummary1Page = new ExamSummaryMonthlyPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            examSummary1Page.navigateToExamSummary1page(userName, password, adminUserName, adminPassword, LoginAs);
            examSummary1Page.selectMonthDropdown(expMonth);
            examSummary1Page.selectYearDropdown(expYear);
            int x = Int32.Parse(expClient);
            examSummary1Page.selectClientDropdown(x);
            examSummary1Page.selectStatusDropdown(expStatus);
            examSummary1Page.selectSearch(expError, email);
        }
    }
}
