

using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;

namespace PortalApplicationFramework
{
    class EvaluationsSurveyGraphTest : TestBase
    {
        //[Parallelizable(ParallelScope.Self)]
        [Test, TestCaseSource("AddTestDataConfig")]
        public void EvaluationsSurveyGraphTestPage(IWebDriver driver)

        {
            string expClient1 = getDataParser().extractDataLoginCredentials("expClient1");
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");


            EvaluationsSurveyGraphPage evaluationsSurveyGraphPage = new EvaluationsSurveyGraphPage(driver);
            evaluationsSurveyGraphPage.navigateToEvaluationsPage(userName, password, adminUserName, adminPassword, LoginAs);
            evaluationsSurveyGraphPage.selectClientDropdown(expClient1);
            evaluationsSurveyGraphPage.selectFromDate(expFromDate);
            evaluationsSurveyGraphPage.selectToDate();
            evaluationsSurveyGraphPage.selectSearch();
        }
    }
}
