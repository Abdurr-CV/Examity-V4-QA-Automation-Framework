using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;

namespace PortalApplicationFramework
{
    class ProctorShiftsCustomShiftSummaryTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ProctorShiftsCustomShiftSummaryTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");

            ProctorShiftsCustomShiftSummaryPage proctorShiftsCustomShiftSummaryPage = new ProctorShiftsCustomShiftSummaryPage(driver);
            proctorShiftsCustomShiftSummaryPage.navigateToProctorShiftsPage(reportTab, LoginpageUrl);
            proctorShiftsCustomShiftSummaryPage.selectFromDate(expFromDate);
            proctorShiftsCustomShiftSummaryPage.selectToDate();
            proctorShiftsCustomShiftSummaryPage.selectSearch(expError, email, reportTab);
        }
    }
}
