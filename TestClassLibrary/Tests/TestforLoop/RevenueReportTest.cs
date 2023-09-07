using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;

namespace PortalApplicationFramework
{
    public class RevenueReportTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void RevenueReportTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expMonth = getDataParser().extractDataMonthlyReportsDateSelection("expMonth");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");

            RevenueReportPage revenueReportPage = new RevenueReportPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            string randomclient = clientSelectionPage.ClientSelectionrandomly();
            TestContext.Progress.WriteLine(randomclient);
            revenueReportPage.navigateToRevenueReportpage(reportTab, LoginpageUrl);
            /*int x = Int32.Parse(expClient);
            revenueReportPage.selectClientDropdown(x);*/
            revenueReportPage.selectMonthDropdown(expMonth);
            revenueReportPage.selectYearDropdown(expYear);
            revenueReportPage.selectSearch(expError, email, reportTab);
        }
    }
}
