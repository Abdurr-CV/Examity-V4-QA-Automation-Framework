using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;

namespace PortalApplicationFramework
{
    class EvaluationsSurveyGraphTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void EvaluationsSurveyGraphTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string expClient1 = getDataParser().extractDataLoginCredentials("expClient1");
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");

            EvaluationsSurveyGraphPage evaluationsSurveyGraphPage = new EvaluationsSurveyGraphPage(driver);
            evaluationsSurveyGraphPage.navigateToEvaluationsPage(LoginpageUrl);
            evaluationsSurveyGraphPage.selectClientDropdown(expClient1);
            evaluationsSurveyGraphPage.selectFromDate(expFromDate);
            evaluationsSurveyGraphPage.selectToDate();
            evaluationsSurveyGraphPage.selectSearch();
        }
    }
}
