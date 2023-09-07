using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;

namespace PortalApplicationFramework
{
    public class ExamStatusCountTest : TestBase
    {
        private object examStatCountPage;

        [Test, TestCaseSource("AddTestDataConfig")]
        public void ExamStatusCountTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");

            ExamStatusCountPage examStatCountPage = new ExamStatusCountPage(driver);
            examStatCountPage.navigateToExamStatusCount(reportTab, LoginpageUrl);
            int x = Int32.Parse(expClient);
            examStatCountPage.selectClientDropdown(x);
            examStatCountPage.selectFromDate(expFromDate);
            examStatCountPage.selectToDate();
            examStatCountPage.selectSearch(expError, email, reportTab);
        }
    }
}
