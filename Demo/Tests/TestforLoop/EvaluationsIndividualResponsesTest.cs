using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;

namespace PortalApplicationFramework
{
    class EvaluationsIndividualResponsesTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void EvaluationsIndividualResponsesTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");
            string expStudentName = getDataParser().extractDataEvaluations("expStudentName");
            string expExamID = getDataParser().extractDataEvaluations("expExamID");


            EvaluationsIndividualResponsesPage evaluationsIndividualResponsesPage = new EvaluationsIndividualResponsesPage(driver);
            evaluationsIndividualResponsesPage.navigateToEvaluationsPage(LoginpageUrl);
            int x = Int32.Parse(expClient);
            evaluationsIndividualResponsesPage.selectClientDropdown(x);
            evaluationsIndividualResponsesPage.selectFromDate(expFromDate);
            evaluationsIndividualResponsesPage.selectToDate();
            evaluationsIndividualResponsesPage.typeStudentName(expStudentName);
            evaluationsIndividualResponsesPage.typeExamID(expExamID);
            evaluationsIndividualResponsesPage.selectSearch();
        }
    }
}
