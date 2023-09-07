using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;

namespace PortalApplicationFramework
{
    public class ExamCountMonthlyTest : TestBase
    {
        private object examCountmonthlyPage;

        [Test, TestCaseSource("AddTestDataConfig")]
        public void ExamCountMonthlyTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expMonth = getDataParser().extractDataMonthlyReportsDateSelection("expMonth");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expSecurity = getDataParser().extractDataExamCountMonthly("expSecurity");
            string email = getDataParser().extractDataLoginCredentials("email");

            ExamCountMonthlyPage examCountMPage = new ExamCountMonthlyPage(driver);
            examCountMPage.navigateToExamCountMonthly(reportTab, LoginpageUrl);
            examCountMPage.selectMonthDropdown(expMonth);
            examCountMPage.selectYearDropdown(expYear);
            int x = Int32.Parse(expClient);
            examCountMPage.selectClientDropdown(x);
            examCountMPage.selectSecurityDropdown(expSecurity);
            examCountMPage.selectSearch();
            examCountMPage.selectExport(email);
        }
    }
}
