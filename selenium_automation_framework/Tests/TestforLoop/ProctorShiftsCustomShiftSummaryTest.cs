using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    class ProctorShiftsCustomShiftSummaryTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ProctorShiftsCustomShiftSummaryTestPage(IWebDriver driver)
        {
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            ProctorShiftsCustomShiftSummaryPage proctorShiftsCustomShiftSummaryPage = new ProctorShiftsCustomShiftSummaryPage(driver);
            proctorShiftsCustomShiftSummaryPage.navigateToProctorShiftsPage(userName, password, adminUserName, adminPassword, LoginAs);
            proctorShiftsCustomShiftSummaryPage.selectFromDate(expFromDate);
            proctorShiftsCustomShiftSummaryPage.selectToDate();
            proctorShiftsCustomShiftSummaryPage.selectSearch(expError, email);
        }
    }
}
