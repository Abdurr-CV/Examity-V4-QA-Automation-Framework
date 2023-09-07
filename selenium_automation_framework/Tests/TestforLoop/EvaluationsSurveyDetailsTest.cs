using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    class EvaluationsSurveyDetailsTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void EvaluationsSurveyDetailsTestPage(IWebDriver driver)

        {
            string expClient1 = getDataParser().extractDataLoginCredentials("expClient1");
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            EvaluationsSurveyDetailsPage evaluationsSurveyDetailsPage = new EvaluationsSurveyDetailsPage(driver);
            evaluationsSurveyDetailsPage.navigateToEvaluationsPage(userName, password, adminUserName, adminPassword, LoginAs);
            evaluationsSurveyDetailsPage.selectClientDropdown(expClient1);
            evaluationsSurveyDetailsPage.selectFromDate(expFromDate);
            evaluationsSurveyDetailsPage.selectToDate();
            evaluationsSurveyDetailsPage.selectSearch();
        }
    }
}
