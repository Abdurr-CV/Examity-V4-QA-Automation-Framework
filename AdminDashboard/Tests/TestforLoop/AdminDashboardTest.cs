using NUnit.Framework;
using OpenQA.Selenium;
using AdminDashboard.PageObjects;
using AdminDashboard.Utilities;

namespace AdminDashboard
{
    public class AdminDashboardTest : TestBase
    {
        [Test]
        public void AdminDashboardTestPage(IWebDriver driver)
        {
            string AdminUsername = getDataParser().extractDataLoginCredentials(("AdminUsername"));
            string AdminPassword = getDataParser().extractDataLoginCredentials("AdminPassword");
            string SwitchRoleUrl = getDataParser().extractDataLoginCredentials("SwitchRoleUrl");
            string Role = getDataParser().extractDataLoginCredentials("Role");
            string InstructorFName = getDataParser().extractDataLoginCredentials("InstructorFName");
            string InstructorLName = getDataParser().extractDataLoginCredentials("InstructorLName");
            string instructorEmail = getDataParser().extractDataLoginCredentials("instructorEmail");
            string toEmail = getDataParser().extractDataLoginCredentials("toEmail");

            AdminDashboardLoginPage adminDashboardLoginPage = new AdminDashboardLoginPage(driver);
            adminDashboardLoginPage.LoginAsAdmin(AdminUsername, 
                                                 AdminPassword,
                                                 SwitchRoleUrl,
                                                 Role);
            adminDashboardLoginPage.AddingInstructor(InstructorFName,
                                                     InstructorLName,
                                                     instructorEmail);
            adminDashboardLoginPage.ScheduleStatusReport(toEmail);
            adminDashboardLoginPage.ScheduleDetailsReport(toEmail);
            adminDashboardLoginPage.ExamStatusReport(toEmail);
        }
    }
}
