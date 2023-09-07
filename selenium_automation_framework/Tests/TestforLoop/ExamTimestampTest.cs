using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;
using System.Collections.Generic;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class ExamTimestampTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ExamTimestampTestPage(IWebDriver driver)
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

            ExamTimestampPage examTimestampPage = new ExamTimestampPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            examTimestampPage.navigateToExamTimestamppage(userName, password, adminUserName, adminPassword, LoginAs);
            int x = Int32.Parse(expClient);
            examTimestampPage.selectClientDropdown(x);
            examTimestampPage.selectFromDate(expFromDate);
            examTimestampPage.selectToDate();
            examTimestampPage.selectSearch(expError, email);
        }
    }
}
