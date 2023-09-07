using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;

namespace PortalApplicationFramework
{
    public class ExamSnapshotTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ExamSnapshotTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expAccountManager = getDataParser().extractDataExamSnapshot("expAccountManager");
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");
            string expToDate = getDataParser().extractDataCustomReportsDateSelection("expToDate");
            string expError = getDataParser().extractDataLoginCredentials("expError");

            ExamSnapshotPage examSnapshotPage = new ExamSnapshotPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            examSnapshotPage.navigateToExamSnapshotpage(reportTab, LoginpageUrl);
            int x = Int32.Parse(expClient);
            examSnapshotPage.selectClientDropdown(x);
            examSnapshotPage.selectAccountManagerDropdown(expAccountManager);
            /*examSnapshotPage.selectCourseDropdown();*/
            examSnapshotPage.selectFromDate(expFromDate);
            examSnapshotPage.selectToDate(expToDate);
            examSnapshotPage.selectSearch(expError, reportTab);
        }
    }
}
