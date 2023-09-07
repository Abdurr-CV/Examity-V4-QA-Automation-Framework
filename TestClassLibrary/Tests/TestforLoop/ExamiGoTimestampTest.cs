using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
    using PortalApplicationFramework.Utilities;

namespace PortalApplicationFramework
{
    public class ExamiGoTimestampTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ExamiGoTimestampTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string selectIcon = getDataParser().extractDataExamiGoTimestamp("selectIcon");
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");
            string expError = getDataParser().extractDataLoginCredentials("expError");

            ExamiGoTimestampPage examiGoPage = new ExamiGoTimestampPage(driver);
            examiGoPage.navigateToExamiGoTimestampPage(reportTab, selectIcon, LoginpageUrl);
            examiGoPage.selectFromDate(expFromDate);
            examiGoPage.selectToDate();
            examiGoPage.selectSearch(expError);
        }
    }
}
