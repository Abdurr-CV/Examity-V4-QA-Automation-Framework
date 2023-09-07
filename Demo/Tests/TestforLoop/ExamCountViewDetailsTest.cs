using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;

namespace PortalApplicationFramework
{
    public class ExamCountViewDetailsTest: TestBase
    {
        private object ExamCountViewDetailsPage;

        [Test, TestCaseSource("AddTestDataConfig")]
        public void ExamCountViewDetailsTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expSecurity = getDataParser().extractDataExamCountViewDetails("expSecurity");
            string expMonth = getDataParser().extractDataMonthlyReportsDateSelection("expMonth");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");

            ExamCountViewDetailsPage examCountVDPage = new ExamCountViewDetailsPage(driver);
            examCountVDPage.navigateToExamCountViewDetails1page(reportTab, LoginpageUrl);
            int x = Int32.Parse(expClient);
            examCountVDPage.selectClientDropdown(x);
            examCountVDPage.selectSecurityLevelDropdown(expSecurity);
            examCountVDPage.selectMonthDropdown(expMonth);
            examCountVDPage.selectYearDropdown(expYear);
            examCountVDPage.selectSearch(expError, email);
        }
    }
}
