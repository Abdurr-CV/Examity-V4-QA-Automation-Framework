using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;

namespace PortalApplicationFramework
{
    public class ExamHistoryTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ExamHistoryTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string course = getDataParser().extractDataExamHistory("course");
            string exam = getDataParser().extractDataExamHistory("exam");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string expClient1 = getDataParser().extractDataLoginCredentials("expClient1");

            ExamHistoryPage examHistoryPage = new ExamHistoryPage(driver);
            examHistoryPage.navigateToExamHistorypage(reportTab, LoginpageUrl);
            examHistoryPage.selectClientDropdown(expClient1);
            examHistoryPage.typeCourseName(course);
            examHistoryPage.typeExamName(exam);
            examHistoryPage.selectSearch(expError);
        }
    }
}
