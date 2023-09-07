using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;
using System.Collections.Generic;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class ExamStatusCountTest : TestBase
    {
        private object examStatCountPage;

        [Test, TestCaseSource("AddTestDataConfig")]
        public void ExamStatusCountTestPage(IWebDriver driver)
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

            ExamStatusCountPage examStatCountPage = new ExamStatusCountPage(driver);
            examStatCountPage.navigateToExamStatusCount(userName, password, adminUserName, adminPassword, LoginAs);
            int x = Int32.Parse(expClient);
            examStatCountPage.selectClientDropdown(x);
            examStatCountPage.selectFromDate(expFromDate);
            examStatCountPage.selectToDate();
            examStatCountPage.selectSearch(expError, email);
        }
    }
}
