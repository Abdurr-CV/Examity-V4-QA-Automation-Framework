using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;
using System.Collections.Generic;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class ExamSummaryCustomTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ExamSummaryCustomTestPage(IWebDriver driver)
        {
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expSelection = getDataParser().extractDataExamSummaryCustom("expSelection");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            ExamSummaryCustomPage examSummaryPage = new ExamSummaryCustomPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            examSummaryPage.navigateToExamSummarypage(userName, password, adminUserName, adminPassword, LoginAs);
            examSummaryPage.selectFromDate(expFromDate);
            examSummaryPage.selectToDate();
            int x = Int32.Parse(expClient);
            examSummaryPage.selectClientDropdown(x);
            examSummaryPage.selectStatuses(expSelection);
            examSummaryPage.selectSearch(expError, email);
        }
    }
}