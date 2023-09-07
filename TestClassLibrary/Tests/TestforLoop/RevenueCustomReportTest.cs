using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;

namespace PortalApplicationFramework
{
    class RevenueCustomReportTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void RevenueCustomReportTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string email = getDataParser().extractDataLoginCredentials("email");
            

            RevenueCustomReportPage revenueCustomReportPage = new RevenueCustomReportPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            revenueCustomReportPage.navigateToRevenueCustomReportpage(reportTab, LoginpageUrl);
            /*int x = Int32.Parse(expClient);
            revenueCustomReportPage.selectClientDropdown(x);*/
            revenueCustomReportPage.selectYearDropdown(expYear);
            revenueCustomReportPage.selectSearch(email, reportTab);
        }
    }
}
