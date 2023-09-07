using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System.Collections.Generic;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class ExamHistoryTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ExamHistoryTestPage(IWebDriver driver)
        {
            string course = getDataParser().extractDataExamHistory("course");
            string exam = getDataParser().extractDataExamHistory("exam");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string expClient1 = getDataParser().extractDataLoginCredentials("expClient1");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            ExamHistoryPage examHistoryPage = new ExamHistoryPage(driver);
            examHistoryPage.navigateToExamHistorypage(userName, password, adminUserName, adminPassword, LoginAs);
            examHistoryPage.selectClientDropdown(expClient1);
            examHistoryPage.typeCourseName(course);
            examHistoryPage.typeExamName(exam);
            examHistoryPage.selectSearch(expError);
        }
    }
}
