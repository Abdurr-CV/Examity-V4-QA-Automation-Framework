using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;

namespace PortalApplicationFramework
{
    public class MonthlyExamCountDetailsTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void MonthlyExamCountDetailsTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");

            MonthlyExamCountDeatilsPage monthlyExamCountDeatilsPage = new MonthlyExamCountDeatilsPage(driver);
            monthlyExamCountDeatilsPage.navigateToMonthlyExamCountPage(reportTab, LoginpageUrl);
            monthlyExamCountDeatilsPage.selectYearDropdown(expYear);
            monthlyExamCountDeatilsPage.selectSearch(expError, email);
        }
    }
}
