using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;

namespace PortalApplicationFramework
{
    class RevenueYTDReportTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void RevenueYTDReportTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");

            RevenueYTDReportPage revenueYTDReportPage = new RevenueYTDReportPage(driver);
            revenueYTDReportPage.navigateToRevenueYTDReportpage(reportTab, LoginpageUrl);
            /*int x = Int32.Parse(expClient);
            revenueYTDReportPage.selectClientDropdown(x);*/
            revenueYTDReportPage.selectYearDropdown(expYear);
            revenueYTDReportPage.selectSearch(expError, email, reportTab);
        }
    }
}
