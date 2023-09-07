using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class MonthlyExamCountGraphTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void MonthlyExamCountGraphTestPage(IWebDriver driver)
        {
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string email = getDataParser().extractDataLoginCredentials("email");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            MonthlyExamCountGraphPage monthlyExamCountGraphPage = new MonthlyExamCountGraphPage(driver);
            monthlyExamCountGraphPage.navigateToMonthlyExamCountPage(userName, password, adminUserName, adminPassword, LoginAs);
            monthlyExamCountGraphPage.selectYearDropdown(expYear);
            monthlyExamCountGraphPage.selectSearch(email);
        }
    }
}
