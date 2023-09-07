using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class KPITest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void KPITestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expClient1 = getDataParser().extractDataLoginCredentials("expClient1");
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");

            KPIPage kpiPage = new KPIPage(driver);
            kpiPage.navigateToKPIpage(reportTab, LoginpageUrl);
            kpiPage.selectClientDropdown(expClient1);
            kpiPage.selectFromDate(expFromDate);
            kpiPage.selectToDate();
            kpiPage.selectSearch(expError, email, reportTab);
        }
    }
}
