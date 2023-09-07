using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using System;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    class EvaluationsIndividualResponsesTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void EvaluationsIndividualResponsesTestPage(IWebDriver driver)

        {
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");
            string expStudentName = getDataParser().extractDataEvaluations("expStudentName");
            string expExamID = getDataParser().extractDataEvaluations("expExamID");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");


            EvaluationsIndividualResponsesPage evaluationsIndividualResponsesPage = new EvaluationsIndividualResponsesPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            evaluationsIndividualResponsesPage.navigateToEvaluationsPage(userName, password, adminUserName, adminPassword, LoginAs);
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
