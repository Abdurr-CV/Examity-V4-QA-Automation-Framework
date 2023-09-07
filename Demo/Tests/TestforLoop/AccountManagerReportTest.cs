using NUnit.Framework;
using OpenQA.Selenium;
using Demo.PageObjects;
using Demo.Utilities;
using System;

namespace Demo
{
    public class AccountManagerReportTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void AccountmanagerReportTestPage(IWebDriver driver)
            
        {
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expAccManager = getDataParser().extractDataLoginCredentials("expAccManager");
            string expYear = getDataParser().extractDataAccountManagerReport("expYear");
            string expFromMonth = getDataParser().extractDataAccountManagerReport("expFromMonth");
            string expToMonth = getDataParser().extractDataAccountManagerReport("expToMonth");
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");

            AccountManagerReportPage AccManagerReportPage = new AccountManagerReportPage(driver);
            AccManagerReportPage.navigateToAccountManagerReportpage(reportTab, LoginpageUrl);
            int x = Int32.Parse(expAccManager);
            AccManagerReportPage.selectAccountManagerDropdown(x);
            AccManagerReportPage.selectYearDropdown(expYear);
            AccManagerReportPage.selectFromMonthDropdown(expFromMonth);
            AccManagerReportPage.selectToMonthDropdown(expToMonth);
            AccManagerReportPage.selectGetReport(reportTab);
        }
    }
}
