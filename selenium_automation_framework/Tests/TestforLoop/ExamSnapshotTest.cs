using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;
using System.Collections.Generic;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class ExamSnapshotTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ExamSnapshotTestPage(IWebDriver driver)
        {
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expAccountManager = getDataParser().extractDataExamSnapshot("expAccountManager");
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");
            string expToDate = getDataParser().extractDataCustomReportsDateSelection("expToDate");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            ExamSnapshotPage examSnapshotPage = new ExamSnapshotPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            examSnapshotPage.navigateToExamSnapshotpage(userName, password, adminUserName, adminPassword, LoginAs);
            int x = Int32.Parse(expClient);
            examSnapshotPage.selectClientDropdown(x);
            examSnapshotPage.selectAccountManagerDropdown(expAccountManager);
            /*examSnapshotPage.selectCourseDropdown();*/
            examSnapshotPage.selectFromDate(expFromDate);
            examSnapshotPage.selectToDate(expToDate);
            examSnapshotPage.selectSearch(expError);
        }
    }
}
