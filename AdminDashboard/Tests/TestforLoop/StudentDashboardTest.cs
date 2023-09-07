using AdminDashboard.PageObjects;
using AdminDashboard.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AdminDashboard
{
    class StudentDashboardTest : TestBase
    {
        [Test]
        public void StudentDashboardTestPage(IWebDriver driver)
        {
            string instructorPassword = getDataParser().extractDataLoginCredentials("instructorPassword");
            string timeZone = getDataParser().extractDataLoginCredentials("timeZone");
            string question1 = getDataParser().extractDataLoginCredentials("question1");
            string question2 = getDataParser().extractDataLoginCredentials("question2");
            string question3 = getDataParser().extractDataLoginCredentials("question3");
            string securityAnswer = getDataParser().extractDataLoginCredentials("securityAnswer");
            string examiKEYname = getDataParser().extractDataLoginCredentials("examiKEYname");
            string Currency = getDataParser().extractDataLoginCredentials("Currency");
            string studentEmail = getDataParser().extractDataLoginCredentials("studentEmail");
            string Company = getDataParser().extractDataLoginCredentials("Company");
            string Address = getDataParser().extractDataLoginCredentials("Address");
            string City = getDataParser().extractDataLoginCredentials("City");
            string PostalCode = getDataParser().extractDataLoginCredentials("PostalCode");
            string CCNumber = getDataParser().extractDataLoginCredentials("CCNumber");
            string CSV = getDataParser().extractDataLoginCredentials("CSV");
            string ExpiryMonth = getDataParser().extractDataLoginCredentials("ExpiryMonth");
            string ExpiryYear = getDataParser().extractDataLoginCredentials("ExpiryYear");

            StudentDashboardPage studentDashboardPage = new StudentDashboardPage(driver);
            studentDashboardPage.LoginAsStudent(instructorPassword);
            studentDashboardPage.ProfileUpdation();
            studentDashboardPage.AccountInformation(timeZone);
            studentDashboardPage.examiSHOW();
            studentDashboardPage.examiKNOW(question1,
                                           question2,
                                           question3,
                                           securityAnswer);
            studentDashboardPage.examiKEY(examiKEYname);
            studentDashboardPage.ScheduleExam(Currency,
                                             studentEmail,
                                             Company,
                                             Address,
                                             City,
                                             PostalCode,
                                             CCNumber,
                                             CSV,
                                             ExpiryMonth,
                                             ExpiryYear);
            studentDashboardPage.RescheduleExam(Currency,
                                             studentEmail,
                                             Company,
                                             Address,
                                             City,
                                             PostalCode,
                                             CCNumber,
                                             CSV,
                                             ExpiryMonth,
                                             ExpiryYear);
            studentDashboardPage.CancelExam();
            studentDashboardPage.ScheduleExamAgain(Currency,
                                             studentEmail,
                                             Company,
                                             Address,
                                             City,
                                             PostalCode,
                                             CCNumber,
                                             CSV,
                                             ExpiryMonth,
                                             ExpiryYear);
            studentDashboardPage.WFMRole();
            studentDashboardPage.ProctorStudentFlow();
            studentDashboardPage.ProceedButtonStudent();
            studentDashboardPage.ProvidingExamiDetails(securityAnswer,
                                                       examiKEYname);
            studentDashboardPage.Survey();
        }
    }
}