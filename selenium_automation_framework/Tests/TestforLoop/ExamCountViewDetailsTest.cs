using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;
using System.Collections.Generic;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class ExamCountViewDetailsTest: TestBase
    {
        private object ExamCountViewDetailsPage;

        [Test, TestCaseSource("AddTestDataConfig")]
        public void ExamCountViewDetailsTestPage(IWebDriver driver)

        {
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expSecurity = getDataParser().extractDataExamCountViewDetails("expSecurity");
            string expMonth = getDataParser().extractDataMonthlyReportsDateSelection("expMonth");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            ExamCountViewDetailsPage examCountVDPage = new ExamCountViewDetailsPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            examCountVDPage.navigateToExamCountViewDetails1page(userName, password, adminUserName, adminPassword, LoginAs);
            int x = Int32.Parse(expClient);
            examCountVDPage.selectClientDropdown(x);
            examCountVDPage.selectSecurityLevelDropdown(expSecurity);
            examCountVDPage.selectMonthDropdown(expMonth);
            examCountVDPage.selectYearDropdown(expYear);
            examCountVDPage.selectSearch(expError, email);
        }
    }
}
