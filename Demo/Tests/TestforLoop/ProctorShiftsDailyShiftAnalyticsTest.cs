using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;

namespace PortalApplicationFramework
{
    class ProctorShiftsDailyShiftAnalyticsTest : TestBase

    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ProctorShiftsDailyShiftAnalyticsTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");

            ProctorShiftsDailyShiftAnalyticsPage proctorShiftsDailyShiftAnalyticsPage = new ProctorShiftsDailyShiftAnalyticsPage(driver);
            proctorShiftsDailyShiftAnalyticsPage.navigateToProctorShiftsPage(reportTab, LoginpageUrl);
            proctorShiftsDailyShiftAnalyticsPage.selectToDate();
            proctorShiftsDailyShiftAnalyticsPage.selectSearch();
        }
    }
}
