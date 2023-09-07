using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;

namespace PortalApplicationFramework
{
    public class BillingSummaryTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void BillingSummaryTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expMonth = getDataParser().extractDataMonthlyReportsDateSelection("expMonth");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");

            BillingSummaryPage billingSummaryPage = new BillingSummaryPage(driver);
            billingSummaryPage.navigateToBillingSummarypage(reportTab, LoginpageUrl);
            billingSummaryPage.selectMonthDropdown(expMonth);
            billingSummaryPage.selectYearDropdown(expYear);
            billingSummaryPage.selectSearch(expError, email, reportTab);
        }
    }
}
