using NUnit.Framework;
using OpenQA.Selenium;
using Demo.PageObjects;
using Demo.Utilities;
using System;

namespace Demo
{
    public class AuditDetailsTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void AuditTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");

            AuditDetailsPage auditDetailsPage = new AuditDetailsPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            auditDetailsPage.navigateToAuditdetailspage(LoginpageUrl);
            int x = Int32.Parse(expClient);
            auditDetailsPage.selectClientDropdown(x);
            /*auditDetailsPage.selectFromDate(expFromDate);*/
            auditDetailsPage.selectToDate();
            auditDetailsPage.selectSearch(expError, email);
        }
    }
}
