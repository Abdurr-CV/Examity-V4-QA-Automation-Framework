using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class MonthlyExamCountDetailsTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void MonthlyExamCountDetailsTestPage(IWebDriver driver)
        {
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            MonthlyExamCountDeatilsPage monthlyExamCountDeatilsPage = new MonthlyExamCountDeatilsPage(driver);
            monthlyExamCountDeatilsPage.navigateToMonthlyExamCountPage(userName, password, adminUserName, adminPassword, LoginAs);
            monthlyExamCountDeatilsPage.selectYearDropdown(expYear);
            monthlyExamCountDeatilsPage.selectSearch(expError, email);
        }
    }
}
