using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    class ProctorShiftsDailyShiftAnalyticsTest : TestBase

    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ProctorShiftsDailyShiftAnalyticsTestPage(IWebDriver driver)
        {
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            ProctorShiftsDailyShiftAnalyticsPage proctorShiftsDailyShiftAnalyticsPage = new ProctorShiftsDailyShiftAnalyticsPage(driver);
            proctorShiftsDailyShiftAnalyticsPage.navigateToProctorShiftsPage(userName, password, adminUserName, adminPassword, LoginAs);
            proctorShiftsDailyShiftAnalyticsPage.selectToDate();
            proctorShiftsDailyShiftAnalyticsPage.selectSearch();
        }
    }
}
