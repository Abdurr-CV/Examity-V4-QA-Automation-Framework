using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.PageObjects.ExamiGoTimestampPage;
using PortalApplicationFramework.Utilities;
using System.Collections.Generic;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class ExamiGoTimestampTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ExamiGoTimestampTestPage(IWebDriver driver)
        {
            string selectIcon = getDataParser().extractDataExamiGoTimestamp("selectIcon");
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            ExamiGoTimestampPage examiGoPage = new ExamiGoTimestampPage(driver);
            examiGoPage.navigateToExamiGoTimestampPage(selectIcon, userName, password, adminUserName, adminPassword, LoginAs);
            examiGoPage.selectFromDate(expFromDate);
            examiGoPage.selectToDate();
            examiGoPage.selectSearch(expError);
        }
    }
}
