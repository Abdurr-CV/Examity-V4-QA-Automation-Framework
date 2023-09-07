using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using System;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class AuditDetailsTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void AuditTestPage(IWebDriver driver)

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

            AuditDetailsPage auditDetailsPage = new AuditDetailsPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            auditDetailsPage.navigateToAuditdetailspage(userName, password, adminUserName, adminPassword, LoginAs);
            int x = Int32.Parse(expClient);
            auditDetailsPage.selectClientDropdown(x);
            auditDetailsPage.selectFromDate(expFromDate);
            auditDetailsPage.selectToDate();
            auditDetailsPage.selectSearch(expError, email);
        }
    }
}
