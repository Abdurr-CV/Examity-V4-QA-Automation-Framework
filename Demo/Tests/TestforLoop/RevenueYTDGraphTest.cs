using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;

namespace PortalApplicationFramework
{
    class RevenueYTDGraphTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void RevenueYTDGraphTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string email = getDataParser().extractDataLoginCredentials("email");

            RevenueYTDGraphPage revenueYTDGraphPage = new RevenueYTDGraphPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            revenueYTDGraphPage.navigateToRevenueYTDGraphpage(reportTab, LoginpageUrl);
            /*int x = Int32.Parse(expClient);
            revenueYTDGraphPage.selectClientDropdown(x);*/
            revenueYTDGraphPage.selectYearDropdown(expYear);
            revenueYTDGraphPage.selectSearch(email, reportTab);
        }
    }
}
