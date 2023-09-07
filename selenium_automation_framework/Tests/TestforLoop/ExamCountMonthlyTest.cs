using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;
using System.Collections.Generic;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class ExamCountMonthlyTest : TestBase
    {
        private object examCountmonthlyPage;

        [Test, TestCaseSource("AddTestDataConfig")]
        public void ExamCountMonthlyTestPage(IWebDriver driver)
        {
            string expMonth = getDataParser().extractDataMonthlyReportsDateSelection("expMonth");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expSecurity = getDataParser().extractDataExamCountMonthly("expSecurity");
            string email = getDataParser().extractDataLoginCredentials("email");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            ExamCountMonthlyPage examCountMPage = new ExamCountMonthlyPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            examCountMPage.navigateToExamCountMonthly(userName, password, adminUserName, adminPassword, LoginAs);
            examCountMPage.selectMonthDropdown(expMonth);
            examCountMPage.selectYearDropdown(expYear);
            int x = Int32.Parse(expClient);
            examCountMPage.selectClientDropdown(x);
            examCountMPage.selectSecurityDropdown(expSecurity);
            examCountMPage.selectSearch();
            examCountMPage.selectExport(email);
        }
    }
}
