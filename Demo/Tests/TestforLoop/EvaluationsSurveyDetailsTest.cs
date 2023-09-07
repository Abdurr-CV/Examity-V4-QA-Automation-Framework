using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;

namespace PortalApplicationFramework
{
    class EvaluationsSurveyDetailsTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void EvaluationsSurveyDetailsTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string expClient1 = getDataParser().extractDataLoginCredentials("expClient1");
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");

            EvaluationsSurveyDetailsPage evaluationsSurveyDetailsPage = new EvaluationsSurveyDetailsPage(driver);
            evaluationsSurveyDetailsPage.navigateToEvaluationsPage(LoginpageUrl);
            evaluationsSurveyDetailsPage.selectClientDropdown(expClient1);
            evaluationsSurveyDetailsPage.selectFromDate(expFromDate);
            evaluationsSurveyDetailsPage.selectToDate();
            evaluationsSurveyDetailsPage.selectSearch();
        }
    }
}
