using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;

namespace PortalApplicationFramework
{
    public class ExamTimestampTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ExamTimestampTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");

            ExamTimestampPage examTimestampPage = new ExamTimestampPage(driver);
            examTimestampPage.navigateToExamTimestamppage(reportTab, LoginpageUrl);
            int x = Int32.Parse(expClient);
            examTimestampPage.selectClientDropdown(x);
            examTimestampPage.selectFromDate(expFromDate);
            examTimestampPage.selectToDate();
            examTimestampPage.selectSearch(expError, email, reportTab);
        }
    }
}
