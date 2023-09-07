using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;

namespace PortalApplicationFramework
{
    public class DormantClientReportTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void DormantClientTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string email = getDataParser().extractDataLoginCredentials("email");

            DormantClientReportPage dormantClientReportPage = new DormantClientReportPage(driver);
            dormantClientReportPage.navigateToDormantClientReportpage(reportTab, LoginpageUrl);
            dormantClientReportPage.selectExport(email, reportTab);
        }
    }
}
