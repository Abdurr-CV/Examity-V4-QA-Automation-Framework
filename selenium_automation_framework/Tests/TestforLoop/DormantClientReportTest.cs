using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System.Collections.Generic;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class DormantClientReportTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void DormantClientTestPage(IWebDriver driver)
        {
            string email = getDataParser().extractDataLoginCredentials("email");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            DormantClientReportPage dormantClientReportPage = new DormantClientReportPage(driver);
            dormantClientReportPage.navigateToDormantClientReportpage(userName, password, adminUserName, adminPassword, LoginAs);
            dormantClientReportPage.selectExport(email);
        }
    }
}
