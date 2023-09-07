using NUnit.Framework;
using OpenQA.Selenium;
using AdminDashboard.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace AdminDashboard.PageObjects
{
    public class AdminDashboardLoginPage : BasePage
    {
        public AdminDashboardLoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public IWebDriver driver;
        public string InstructorFName;
        public string InstructorLastName;
        public static string InstructorUID = "AutomationInstructor";
        public string LName;

        // LOGIN IN AS ADMIN
        [FindsBy(How = How.Id, Using = "txtUserName")]
        private IWebElement UserId;
        [FindsBy(How = How.Id, Using = "txtPassword")]
        private IWebElement Password;
        [FindsBy(How = How.Id, Using = "btnLogin_input")]
        private IWebElement LoginButton;
        [FindsBy(How = How.XPath, Using = "//table[@id='rdRoles']/tbody/tr/td/input")]
        private IList<IWebElement> RoleSelection;
        [FindsBy(How = How.Id, Using = "rdRoles_0")]
        private IWebElement AdminRole;
        [FindsBy(How = How.Id, Using = "btnLogin_input")]
        private IWebElement LoginRole;

        // INSTRUCTOR CREATION
        [FindsBy(How = How.Id, Using = "ctl00_lnkCourses")]
        private IWebElement CoursesnExamTab;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_gvCourseDetails_ctl00_ctl02_ctl00_lnkAddInstructor")]
        private IWebElement InstructorAddition;
        [FindsBy(How = How.Id, Using = "lblAddStudent")]
        private IWebElement InstructorAdditionMsgBox;
        [FindsBy(How = How.Id, Using = "txtFirstName")]
        private IWebElement InstructorFname;
        [FindsBy(How = How.Id, Using = "txtLastName")]
        private IWebElement InstructotLname;
        [FindsBy(How = How.Id, Using = "txtUserID")]
        private IWebElement InstructorUserID;
        [FindsBy(How = How.Id, Using = "txtEmailAddress")]
        private IWebElement InstructorEmail;
        [FindsBy(How = How.Id, Using = "chkConfirmEmail")]
        private IWebElement InstructorConfirmationEmail;
        [FindsBy(How = How.Id, Using = "btnAdd_input")]
        private IWebElement AddInstructorButton;
        [FindsBy(How = How.Id, Using = "lblInfo")]
        private IWebElement InstructorAddConfirmation;
        [FindsBy(How = How.ClassName, Using = "rwCloseButton")]
        private IWebElement CloseInstructorCreation;

        // SCHEDULE STATUS
        [FindsBy(How = How.Id, Using = "ctl00_lnkReports")]
        private IWebElement ReportsTab;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_divTestSummaryReport")]
        private IWebElement ScheduleStatus;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_rcbCourses_Arrow")]
        private IWebElement CourseDropdown;
        [FindsBy(How = How.ClassName, Using = "rcbCheckAllItemsCheckBox")]
        private IWebElement CheckAllCourses;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_btnSearch_input")]
        private IWebElement SearchCourses;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_btnExportOptions")]
        private IWebElement EmailButton;
        [FindsBy(How = How.Id, Using = "txtEmail")]
        private IWebElement EmailTextbox;
        [FindsBy(How = How.Id, Using = "btnSendMail")]
        private IWebElement SendMailButton;
        [FindsBy(How = How.XPath, Using = "//font[text()='Report emailed sucessfully.']")]
        private IWebElement EmailAssert;
        [FindsBy(How = How.ClassName, Using = "rwCloseButton")]
        private IWebElement CloseEmailButton;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_BtnExportToExcel")]
        private IWebElement ExportButton;

        // SCHEDULE DETAILS
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_divAppointmentScheduleReport")]
        private IWebElement ScheduleDetails;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_rcbCourses_Arrow")]
        private IWebElement CourseDropdownScheduleDetails;
        [FindsBy(How = How.ClassName, Using = "rcbCheckAllItemsCheckBox")]
        private IWebElement CheckAllCoursesScheduleDetails;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_btnSearch_input")]
        private IWebElement SearchCoursesScheduleDetails;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_btnExportOptions")]
        private IWebElement EmailButtonScheduleDetails;
        [FindsBy(How = How.Id, Using = "txtEmail")]
        private IWebElement EmailTextboxScheduleDetails;
        [FindsBy(How = How.Id, Using = "btnSendMail")]
        private IWebElement SendMailButtonScheduleDetails;
        [FindsBy(How = How.XPath, Using = "//font[text()='Report emailed sucessfully.']")]
        private IWebElement EmailAssertScheduleDetails;
        [FindsBy(How = How.ClassName, Using = "rwCloseButton")]
        private IWebElement CloseEmailButtonScheduleDetails;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_BtnExportToExcel")]
        private IWebElement ExportButtonScheduleDetails;

        // EXAM STATUS
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_divTestResultReport")]
        private IWebElement ExamStatus;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_rcbCourses_Arrow")]
        private IWebElement CourseDropdownExamStatus;
        [FindsBy(How = How.ClassName, Using = "rcbCheckAllItemsCheckBox")]
        private IWebElement CheckAllCoursesExamStatus;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_ExamStartRadDatePicker_dateInput")]
        private IWebElement StartDateExamStatus;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_ExamEndRadDatePicker_popupButton")]
        private IWebElement EndDateExamStatus;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_btnSearch_input")]
        private IWebElement SearchCoursesExamStatus;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_btnExportOptions")]
        private IWebElement EmailButtonExamStatus;
        [FindsBy(How = How.Id, Using = "txtEmail")]
        private IWebElement EmailTextboxExamStatus;
        [FindsBy(How = How.Id, Using = "btnSendMail")]
        private IWebElement SendMailButtonExamStatus;
        [FindsBy(How = How.XPath, Using = "//font[text()='Report emailed sucessfully.']")]
        private IWebElement EmailAssertExamStatus;
        [FindsBy(How = How.ClassName, Using = "rwCloseButton")]
        private IWebElement CloseEmailButtonExamStatus;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_BtnExportToExcel")]
        private IWebElement ExportButtonExamStatus;

        // EVALUATION
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_Div1")]
        private IWebElement Evaluations;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_btnExport")]
        private IWebElement ExportSurveyGraph;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_lnkIndividual")]
        private IWebElement SurveyDetailsTab;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_btnExport")]
        private IWebElement ExportSurveyDetails;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_lnkAll")]
        private IWebElement IndividualResponsesTab;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_txtStudentName")]
        private IWebElement EvaluationsStudentName;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_txtExamID")]
        private IWebElement EvaluationsExamID;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_rdpFromDate_dateInput")]
        private IWebElement FromDateEvaluations;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_rdpToDate_dateInput")]
        private IWebElement ToDateEvaluations;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_btnSearch")]
        private IWebElement EvaluationsSearch;
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_btnExport")]
        private IWebElement ExportIndividualResponses;
        
        [FindsBy(How = How.Id, Using = "ctl00_AdminContent_DivLaunch")]
        private IWebElement LaunchTime;

        // LOGGING OUT
        [FindsBy(How = How.Id, Using = "ctl00_lnkLogout")]
        private IWebElement LogoutButton;

        public void LoginAsAdmin(string AdminUsername, 
                                 string AdminPassword,
                                 string SwitchRoleUrl,
                                 string Role)
        {
            try
            {
                EnterValues(UserId, AdminUsername);
                ReportLog("Passed", "Entered the admin-username as " + AdminUsername);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the admin-username");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(Password, AdminPassword);
                ReportLog("Passed", "Entered admin-password as " + AdminPassword);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter admin-password");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(LoginButton);
                ReportLog("Passed", "Clicked on the Login button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the Login button");
                throw ex;
            }
            QuickSleep();
            if (driver.Url.Contains(SwitchRoleUrl) || driver.Title.Contains("Examity :: Login"))
            {
                HardSleep();
                try
                {
                    ClickElement(AdminRole);
                    ReportLog("Passed", "Selected admin role");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't select admin role");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    ClickElement(LoginRole);
                    ReportLog("Passed", "Clicked on the Login button");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on the Login button");
                    throw ex;
                }
                QuickSleep();
            }
        }

        public void AddingInstructor(string InstructorFName,
                                     string InstructorLName,
                                     string instructorEmail)
        {
            try
            {
                ClickElement(CoursesnExamTab);
                ReportLog("Passed", "Clicked on the exam tab");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the exam tab");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(InstructorAddition);
                ReportLog("Passed", "Clicked on the add instructor button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the add instructor button");
                throw ex;
            }
            HardSleep();
            try
            {
                driver.SwitchTo().Frame(0);
                Assert.IsTrue(InstructorAdditionMsgBox.Displayed);
                ReportLog("Passed", "Asserted");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(InstructorFname, InstructorFName);
                ReportLog("Passed", "Entered instructor first name as " + InstructorFName);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter instructor first name");
                throw ex;
            }
            QuickSleep();
            try
            {
                LName = GenerateRandomNumber(5);
                string InstructorLastName = InstructorLName + LName;
                EnterValues(InstructotLname, InstructorLastName);
                ReportLog("Passed", "Entered instructor last name as " + InstructorLastName);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter instructor last name");
                throw ex;
            }
            QuickSleep();
            try
            {
                InstructorUID = InstructorFName + InstructorLName + LName;
                EnterValues(InstructorUserID, InstructorUID);
                ReportLog("Passed", "Entered instructor user-ID as " + InstructorUID);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter instructor user-ID");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(InstructorEmail, instructorEmail);
                ReportLog("Passed", "Entered instructor email as " + instructorEmail);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter instructor email");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(InstructorConfirmationEmail);
                ReportLog("Passed", "Clicked on the instructor confirm email");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the instructor confirm email");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(AddInstructorButton);
                ReportLog("Passed", "Clicked on the add instrcutor key");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the add instructor key");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.IsTrue(InstructorAddConfirmation.Displayed);
                ReportLog("Passed", "Asserted instructor creation");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert instructor creation");
                throw ex;
            }
            MediumSleep();
            ScreenCapture(driver, "Instructor creation");
            try
            {
                driver.SwitchTo().DefaultContent();
                ReportLog("Passed", "Clicked on the instructor creation close button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the instructor creation close button");
                throw ex;
            }
            MediumSleep();
            try
            {
                driver.SwitchTo().DefaultContent();
                ReportLog("Passed", "Clicked on the logout button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the logout button");
                throw ex;
            }
            QuickSleep();
        }

        public void ScheduleStatusReport(string toEmail)
        {
            try
            {
                ClickElement(ReportsTab);
                ReportLog("Passed", "Clicked on the reports tab");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the reports tab");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ScheduleStatus);
                ReportLog("Passed", "Clicked on the Schedule status icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the Schedule status icon");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(CourseDropdown);
                ReportLog("Passed", "Clicked on the course selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the course selection dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(CheckAllCourses);
                ReportLog("Passed", "Clicked on the check-all courses");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the check-all courses");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SearchCourses);
                ReportLog("Passed", "Clicked on the search button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the search button");
                throw ex;
            }
            HardSleep();
            ScreenCapture(driver, "Schedule status report");
            try
            {
                ClickElement(EmailButton);
                ReportLog("Passed", "Clicked on the email button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the email button");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(EmailTextbox, toEmail);
                ReportLog("Passed", "Entered the email address as " + toEmail);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the email address");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SendMailButton);
                ReportLog("Passed", "Clicked on the send email button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the send email button");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.IsTrue(EmailAssert.Displayed);
                ReportLog("Passed", "Asserted sent email");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert email");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(CloseEmailButton);
                ReportLog("Passed", "Clicked on the close email button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the close email button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ExportButton);
                ReportLog("Passed", "Clicked on the export button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the export button");
                throw ex;
            }
            QuickSleep();
        }

        public void ScheduleDetailsReport(string toEmail)
        {
            try
            {
                ClickElement(ReportsTab);
                ReportLog("Passed", "Clicked on the reports tab");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the reports tab");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ScheduleDetails);
                ReportLog("Passed", "Clicked on the Schedule details icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the Schedule details icon");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(CourseDropdownScheduleDetails);
                ReportLog("Passed", "Clicked on the course selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the course selection dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(CheckAllCoursesScheduleDetails);
                ReportLog("Passed", "Clicked on the check-all courses");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the check-all courses");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SearchCoursesScheduleDetails);
                ReportLog("Passed", "Clicked on the search button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the search button");
                throw ex;
            }
            HardSleep();
            ScreenCapture(driver, "Schedule details report");
            try
            {
                ClickElement(EmailButtonScheduleDetails);
                ReportLog("Passed", "Clicked on the email button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the email button");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(EmailTextboxScheduleDetails, toEmail);
                ReportLog("Passed", "Entered the email address as " + toEmail);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the email address");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SendMailButtonScheduleDetails);
                ReportLog("Passed", "Clicked on the send email button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the send email button");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.IsTrue(EmailAssertScheduleDetails.Displayed);
                ReportLog("Passed", "Asserted sent email");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert email");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(CloseEmailButtonScheduleDetails);
                ReportLog("Passed", "Clicked on the close email button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the close email button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ExportButtonScheduleDetails);
                ReportLog("Passed", "Clicked on the export button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the export button");
                throw ex;
            }
            QuickSleep();
        }

        public void ExamStatusReport(string toEmail)
        {
            try
            {
                ClickElement(ReportsTab);
                ReportLog("Passed", "Clicked on the reports tab");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the reports tab");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ExamStatus);
                ReportLog("Passed", "Clicked on the exam status icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the exam status icon");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(CourseDropdownExamStatus);
                ReportLog("Passed", "Clicked on the course selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the course selection dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(CheckAllCoursesExamStatus);
                ReportLog("Passed", "Clicked on the check-all courses");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the check-all courses");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(StartDateExamStatus);
                MediumSleep();
                StartDateExamStatus.Clear();
                string StartDate = DateTime.Today.AddDays(-1095).ToString("M/d/yyyy");
                EnterValues(StartDateExamStatus, StartDate);
                ReportLog("Passed", "Entered start date as " + StartDate);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter start date");
                throw ex;
            }
            QuickSleep();
            try
            {
                string EndDate = DateTime.Today.ToString("M/d/yyyy");
                EnterValues(EndDateExamStatus, EndDate);
                ReportLog("Passed", "Entered end date as " + EndDate);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter end date");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SearchCoursesExamStatus);
                ReportLog("Passed", "Clicked on the search button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the search button");
                throw ex;
            }
            HardSleep();
            ScreenCapture(driver, "Exam status report");
            try
            {
                ClickElement(EmailButtonExamStatus);
                ReportLog("Passed", "Clicked on the email button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the email button");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(EmailTextboxExamStatus, toEmail);
                ReportLog("Passed", "Entered the email address as " + toEmail);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the email address");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SendMailButtonExamStatus);
                ReportLog("Passed", "Clicked on the send email button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the send email button");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.IsTrue(EmailAssertExamStatus.Displayed);
                ReportLog("Passed", "Asserted sent email");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert email");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(CloseEmailButtonExamStatus);
                ReportLog("Passed", "Clicked on the close email button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the close email button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ExportButtonExamStatus);
                ReportLog("Passed", "Clicked on the export button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the export button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(LogoutButton);
                ReportLog("Passed", "Clicked on the logout button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the logout button");
                throw ex;
            }
            QuickSleep();
        }
    }
}

       