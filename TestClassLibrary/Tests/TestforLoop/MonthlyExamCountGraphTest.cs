using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;

namespace PortalApplicationFramework
{
    public class MonthlyExamCountGraphTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void MonthlyExamCountGraphTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string email = getDataParser().extractDataLoginCredentials("email");

            MonthlyExamCountGraphPage monthlyExamCountGraphPage = new MonthlyExamCountGraphPage(driver);
            monthlyExamCountGraphPage.navigateToMonthlyExamCountPage(reportTab, LoginpageUrl);
            monthlyExamCountGraphPage.selectYearDropdown(expYear);
            monthlyExamCountGraphPage.selectSearch(email);
        }
    }
}
