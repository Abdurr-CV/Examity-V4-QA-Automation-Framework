using AdminDashboard.PageObjects;
using AdminDashboard.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AdminDashboard
{
    class AuditorDashboardTest : TestBase
    {
        [Test]
        public void AuditorDashboardTestPage(IWebDriver driver)
        {
            string AuditorUsername = getDataParser().extractDataLoginCredentials("AuditorUsername");
            string AuditorPassword = getDataParser().extractDataLoginCredentials("AuditorPassword");
            string SwitchRoleUrl = getDataParser().extractDataLoginCredentials("SwitchRoleUrl");
            string Role = getDataParser().extractDataLoginCredentials("Role");
            string Flag = getDataParser().extractDataLoginCredentials("Flag");
            string ExamHours = getDataParser().extractDataLoginCredentials("ExamHours");
            string ExamMinutes = getDataParser().extractDataLoginCredentials("ExamMinutes");
            string ExamSeconds = getDataParser().extractDataLoginCredentials("ExamSeconds");
            string ProctorComment2 = getDataParser().extractDataLoginCredentials("ProctorComment2");
            string AuditorAdditionalComments = getDataParser().extractDataLoginCredentials("AuditorAdditionalComments");

            AuditorDashboardPage auditorDashboardPage = new AuditorDashboardPage(driver);
            auditorDashboardPage.LoginAsAdmin(AuditorUsername,
                                              AuditorPassword,
                                              SwitchRoleUrl,
                                              Role);
            auditorDashboardPage.NavigateToInbox();
            auditorDashboardPage.AuditorComments(Flag,
                                                 ExamHours,
                                                 ExamMinutes,
                                                 ExamSeconds,
                                                 ProctorComment2,
                                                 AuditorAdditionalComments);
            auditorDashboardPage.ProcessedExamsValidation();

        }
    }
}
