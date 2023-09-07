using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalApplicationFramework
{
    class ProctorSummaryTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ProctorSummaryTestPage(IWebDriver driver)

        {
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            ProctorSummaryPage proctorSummaryPage = new ProctorSummaryPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            proctorSummaryPage.navigateToProctorSummaryPage(userName, password, adminUserName, adminPassword, LoginAs);
            int x = Int32.Parse(expClient);
            proctorSummaryPage.selectClientDropdown(x);
            proctorSummaryPage.selectFromDate(expFromDate);
            proctorSummaryPage.selectToDate();
            proctorSummaryPage.selectSearch(expError, email);
        }
    }
}
