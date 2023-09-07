using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System.Collections.Generic;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class KPITest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void KPITestPage(IWebDriver driver)
        {
            string expClient1 = getDataParser().extractDataLoginCredentials("expClient1");
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            KPIPage kpiPage = new KPIPage(driver);
            kpiPage.navigateToKPIpage(userName, password, adminUserName, adminPassword, LoginAs);
            kpiPage.selectClientDropdown(expClient1);
            kpiPage.selectFromDate(expFromDate);
            kpiPage.selectToDate();
            kpiPage.selectSearch(expError, email);
        }
    }
}
