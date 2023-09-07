using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;

namespace PortalApplicationFramework
{
    public class BillingCustomTest : TestBase
    {
        private object BillingCustomPage;

        [Test, TestCaseSource("AddTestDataConfig")]
        public void BillingCustomTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expClient1 = getDataParser().extractDataLoginCredentials("expClient1");
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");


            BillingCustomPage billingCusPage = new BillingCustomPage(driver);
            billingCusPage.navigateToBillingCustomPage(reportTab, LoginpageUrl);
            billingCusPage.selectClientDropdown(expClient1);
            billingCusPage.selectFromDate(expFromDate);
            billingCusPage.selectToDate();
            billingCusPage.selectSearch(expError, email, reportTab);
        }
    }
}
