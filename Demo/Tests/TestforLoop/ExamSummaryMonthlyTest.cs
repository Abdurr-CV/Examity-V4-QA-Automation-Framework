using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;

namespace PortalApplicationFramework
{
    public class ExamSummaryMonthlyTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ExamSummaryMonthlyTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expMonth = getDataParser().extractDataMonthlyReportsDateSelection("expMonth");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expStatus = getDataParser().extractDataExamSummaryMonthly("expStatus");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");

            ExamSummaryMonthlyPage examSummary1Page = new ExamSummaryMonthlyPage(driver);
            examSummary1Page.navigateToExamSummary1page(reportTab, LoginpageUrl);
            examSummary1Page.selectMonthDropdown(expMonth);
            examSummary1Page.selectYearDropdown(expYear);
            int x = Int32.Parse(expClient);
            examSummary1Page.selectClientDropdown(x);
            examSummary1Page.selectStatusDropdown(expStatus);
            examSummary1Page.selectSearch(expError, email);
        }
    }
}
