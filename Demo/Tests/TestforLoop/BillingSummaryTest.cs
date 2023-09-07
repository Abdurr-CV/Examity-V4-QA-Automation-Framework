using NUnit.Framework;
using OpenQA.Selenium;
using Demo.PageObjects;
using Demo.Utilities;

namespace Demo
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
