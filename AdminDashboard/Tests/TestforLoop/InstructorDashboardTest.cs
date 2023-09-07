using NUnit.Framework;
using OpenQA.Selenium;
using AdminDashboard.PageObjects;
using AdminDashboard.Utilities;

namespace AdminDashboard
{
    public class InstructorDashboardTest : TestBase
    {
        [Test]
        public void InstructorDashboardTestPage(IWebDriver driver)
        {
            string timeZone = getDataParser().extractDataLoginCredentials("timeZone");
            string instructorPassword = getDataParser().extractDataLoginCredentials("instructorPassword");
            string courseID = getDataParser().extractDataLoginCredentials("courseID");
            string examLevel = getDataParser().extractDataLoginCredentials("examLevel");
            string hourlyTime = getDataParser().extractDataLoginCredentials("hourlyTime");
            string minutelyTime = getDataParser().extractDataLoginCredentials("minutelyTime");
            string ExamAccessLink = getDataParser().extractDataLoginCredentials("ExamAccessLink");
            string examStartTime = getDataParser().extractDataLoginCredentials("examStartTime");
            string examEndTime = getDataParser().extractDataLoginCredentials("examEndTime");
            string extendTime = getDataParser().extractDataLoginCredentials("extendTime");
            string studentFile = getDataParser().extractDataLoginCredentials("studentFile");
            string addRules = getDataParser().extractDataLoginCredentials("addRules");
            string InstructionStudent = getDataParser().extractDataLoginCredentials("InstructionStudent");
            string InstructionProctor = getDataParser().extractDataLoginCredentials("InstructionProctor");
            string InstructionCommon = getDataParser().extractDataLoginCredentials("InstructionCommon");
            string studentFName = getDataParser().extractDataLoginCredentials("studentFName");
            string studentLName = getDataParser().extractDataLoginCredentials("studentLName");
            string studentEmail = getDataParser().extractDataLoginCredentials("studentEmail");
            string commentsBox = getDataParser().extractDataLoginCredentials("commentsBox");
            
            InstructorDashboardPage instructorDashboardPage = new InstructorDashboardPage(driver);
            instructorDashboardPage.LoginAsInstructor(instructorPassword, 
                                                      timeZone);
            instructorDashboardPage.CourseCreation(courseID);
            instructorDashboardPage.ExamCreation(examLevel,
                                                 hourlyTime,
                                                 minutelyTime,
                                                 ExamAccessLink,
                                                 examStartTime,
                                                 examEndTime,
                                                 extendTime,
                                                 studentFile,
                                                 addRules,
                                                 InstructionStudent,
                                                 InstructionProctor,
                                                 InstructionCommon);
            instructorDashboardPage.StudentEnrollment(studentFName,
                                                      studentLName,
                                                      studentEmail,
                                                      commentsBox);
        }
    }
}
