using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;

namespace PortalApplicationFramework
{
    public class ExamSummaryCustomTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ExamSummaryCustomTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expSelection = getDataParser().extractDataExamSummaryCustom("expSelection");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");

            ExamSummaryCustomPage examSummaryPage = new ExamSummaryCustomPage(driver);
            examSummaryPage.navigateToExamSummarypage(reportTab, LoginpageUrl);
            examSummaryPage.selectFromDate(expFromDate);
            examSummaryPage.selectToDate();
            int x = Int32.Parse(expClient);
            examSummaryPage.selectClientDropdown(x);
            examSummaryPage.selectStatuses(expSelection);
            examSummaryPage.selectSearch(expError, email, reportTab);
        }
    }
}