using AdminDashboard.PageObjects;
using AdminDashboard.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AdminDashboard
{
    class ProctorDashboardTest : TestBase
    {
        [Test]
        public void proctorDashboardTestPage(IWebDriver driver1)
        {
            string ProctorUsername = getDataParser().extractDataLoginCredentials("ProctorUsername");
            string ProctorPassword = getDataParser().extractDataLoginCredentials("ProctorPassword");
            string Location = getDataParser().extractDataLoginCredentials("Location");
            string WorkStation = getDataParser().extractDataLoginCredentials("WorkStation");
            string ExamIcon = getDataParser().extractDataLoginCredentials("ExamIcon");
            string Flag = getDataParser().extractDataLoginCredentials("Flag");
            string AuthHours = getDataParser().extractDataLoginCredentials("AuthHours");
            string AuthMinutes = getDataParser().extractDataLoginCredentials("AuthMinutes");
            string AuthSeconds = getDataParser().extractDataLoginCredentials("AuthSeconds");
            string ProctorComment1 = getDataParser().extractDataLoginCredentials("ProctorComment1");
            string ExamHours = getDataParser().extractDataLoginCredentials("ExamHours");
            string ExamMinutes = getDataParser().extractDataLoginCredentials("ExamMinutes");
            string ExamSeconds = getDataParser().extractDataLoginCredentials("ExamSeconds");
            string ProctorComment2 = getDataParser().extractDataLoginCredentials("ProctorComment2");
            string AdditionalComments = getDataParser().extractDataLoginCredentials("AdditionalComments");

            ProctorDashboardPage proctorDashboardPage = new ProctorDashboardPage(driver1);
            proctorDashboardPage.ProctorLogin(ProctorUsername,
                                              ProctorPassword,
                                              Location,
                                              WorkStation);
            proctorDashboardPage.NavigationToStartExam(ExamIcon);
            proctorDashboardPage.Authentication();
            proctorDashboardPage.AuthenticationComments(Flag,
                                                        AuthHours,
                                                        AuthMinutes,
                                                        AuthSeconds,
                                                        ProctorComment1,
                                                        ExamHours,
                                                        ExamMinutes,
                                                        ExamSeconds,
                                                        ProctorComment2,
                                                        AdditionalComments);
        }
    }
}
