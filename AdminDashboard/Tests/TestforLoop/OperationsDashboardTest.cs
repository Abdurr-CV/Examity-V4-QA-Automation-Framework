using AdminDashboard.PageObjects;
using AdminDashboard.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace AdminDashboard
{
    class OperationsDashboardTest : TestBase
    {
        [Test]
        public void OperationsDashboardTestPage(IWebDriver driver)
        {
            string OperatorUsername = getDataParser().extractDataLoginCredentials("OperatorUsername");
            string OperatorPassword = getDataParser().extractDataLoginCredentials("OperatorPassword");
            string UnassignedRandomClients = getDataParser().extractDataLoginCredentials("UnassignedRandomClients");
            string ClientCategory = getDataParser().extractDataLoginCredentials("ClientCategory");
            string SearchByName = getDataParser().extractDataLoginCredentials("SearchByName");
            string ProctorEmployeeID = getDataParser().extractDataLoginCredentials("ProctorEmployeeID");
            string ProctorFirstName = getDataParser().extractDataLoginCredentials("ProctorFirstName");
            string ProctorLastName = getDataParser().extractDataLoginCredentials("ProctorLastName");
            string SpeechLevel = getDataParser().extractDataLoginCredentials("SpeechLevel");
            string AttentivenessLevel = getDataParser().extractDataLoginCredentials("AttentivenessLevel");
            string TechnicalKnowledgeLevel = getDataParser().extractDataLoginCredentials("TechnicalKnowledgeLevel");
            string QualityLevel = getDataParser().extractDataLoginCredentials("QualityLevel");
            string FlexibilityLevel = getDataParser().extractDataLoginCredentials("FlexibilityLevel");
            string Platform = getDataParser().extractDataLoginCredentials("Platform");
            string Category = getDataParser().extractDataLoginCredentials("Category");
            string ClientCategoryByException = getDataParser().extractDataLoginCredentials("ClientCategoryByException");
            string Client = getDataParser().extractDataLoginCredentials("Client");
            string Language = getDataParser().extractDataLoginCredentials("Language");
            string Industry = getDataParser().extractDataLoginCredentials("Industry");
            string TeamLead = getDataParser().extractDataLoginCredentials("TeamLead");
            string vMUsername = getDataParser().extractDataLoginCredentials("vMUsername");

            OperationsDashboardPage operationsDashboardPage = new OperationsDashboardPage(driver);
            operationsDashboardPage.OperationsLogin(OperatorUsername,
                                                    OperatorPassword);
            operationsDashboardPage.DashboardPage();
            int x = Int32.Parse(UnassignedRandomClients);
            operationsDashboardPage.ClientGroupingPageRandomSelection(x,
            ClientCategory);
            operationsDashboardPage.RemoveAutoCategorisedClients(ClientCategory);
            //operationsDashboardPage.ClientGroupingPageManualSearch(SearchByName);
            //operationsDashboardPage.RemoveManuallyCategorisedClient(SearchByName);
            operationsDashboardPage.ProctorMappingPageCategoryTab();
            operationsDashboardPage.ProctorMappingPageProctorsTab(ProctorEmployeeID,
                                                                  ProctorFirstName,
                                                                  ProctorLastName);
            operationsDashboardPage.ProctorProfile(SpeechLevel,
                                                   AttentivenessLevel,
                                                   TechnicalKnowledgeLevel,
                                                   QualityLevel,
                                                   FlexibilityLevel);
            operationsDashboardPage.Platform(Platform);
            operationsDashboardPage.Category(Category);
            operationsDashboardPage.ExceptionsByCategory(ClientCategoryByException,
                                                         Client);
            operationsDashboardPage.Language(Language);
            operationsDashboardPage.AccomodationsReady();
            operationsDashboardPage.Industry(Industry);
            operationsDashboardPage.ProctorAvailability();
            operationsDashboardPage.OperationsAndProctorFlowSTEP1();
            operationsDashboardPage.OperationsAndProctorFlowSTEP2();
            operationsDashboardPage.OperationsAndProctorFlowSTEP3();
            operationsDashboardPage.OperationsAndProctorFlowSTEP4();
            operationsDashboardPage.OperationsAndProctorFlowSTEP5();
            operationsDashboardPage.OperationsAndProctorFlowSTEP6();
            operationsDashboardPage.ReportsTabRosterPage(ProctorEmployeeID,
                                                         ProctorFirstName,
                                                         ProctorLastName);
            operationsDashboardPage.ReportsCheckInCheckOutPage(ProctorEmployeeID,
                                                               ProctorFirstName,
                                                               ProctorLastName);
            operationsDashboardPage.ReportsBreakTime(ProctorLastName,
                                                     TeamLead);
            operationsDashboardPage.ReportsExamRequestPage(ProctorLastName,
                                                           TeamLead);
            operationsDashboardPage.ReportsVMPage(vMUsername,
                                                  ProctorFirstName,
                                                  ProctorLastName);
            operationsDashboardPage.ReportsExamAssignmentPage(ProctorLastName);
            operationsDashboardPage.ReportsEODPage(ProctorLastName,
                                                   TeamLead);
        }
    }
}
