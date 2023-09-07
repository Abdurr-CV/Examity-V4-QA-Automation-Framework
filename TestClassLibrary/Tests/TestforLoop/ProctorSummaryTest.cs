using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;

namespace PortalApplicationFramework
{
    class ProctorSummaryTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ProctorSummaryTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");

            ProctorSummaryPage proctorSummaryPage = new ProctorSummaryPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            proctorSummaryPage.navigateToProctorSummaryPage(reportTab, LoginpageUrl);
            int x = Int32.Parse(expClient);
            proctorSummaryPage.selectClientDropdown(x);
            proctorSummaryPage.selectFromDate(expFromDate);
            proctorSummaryPage.selectToDate();
            proctorSummaryPage.selectSearch(expError, email, reportTab);
        }
    }
}
