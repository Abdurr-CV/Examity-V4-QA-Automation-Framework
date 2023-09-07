using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;
using System.Collections.Generic;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class AccountManagerReportTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void AccountmanagerReportTestPage(IWebDriver driver)
            
        {
            string expAccManager = getDataParser().extractDataLoginCredentials("expAccManager");
            string expYear = getDataParser().extractDataAccountManagerReport("expYear");
            string expFromMonth = getDataParser().extractDataAccountManagerReport("expFromMonth");
            string expToMonth = getDataParser().extractDataAccountManagerReport("expToMonth");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            AccountManagerReportPage AccManagerReportPage = new AccountManagerReportPage(driver);
            AccManagerReportPage.navigateToAccountManagerReportpage(userName,password,adminUserName,adminPassword,LoginAs);
            int x = Int32.Parse(expAccManager);
            AccManagerReportPage.selectAccountManagerDropdown(x);
            AccManagerReportPage.selectYearDropdown(expYear);
            AccManagerReportPage.selectFromMonthDropdown(expFromMonth);
            AccManagerReportPage.selectToMonthDropdown(expToMonth);
            AccManagerReportPage.selectGetReport();
        }
    }
}
