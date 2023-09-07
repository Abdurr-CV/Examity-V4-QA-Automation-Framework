using NUnit.Framework;
using OpenQA.Selenium;
using AdminDashboard.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace AdminDashboard.PageObjects
{
    public class InstructorDashboardPage : BasePage
    {
        public InstructorDashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public IWebDriver driver;
        public static string EXAMNAME;
        public static string LastNameStudent;
        public string CourseIDRandom;
        public static string COURSEid;
        public static string studentUserID;
        public static string studentFName = "automation";
        public static string StudentLastName = "student";

        // LOGIN IN AS ADMIN
        [FindsBy(How = How.Id, Using = "txtUserName")]
        private IWebElement InstructorUserName;
        [FindsBy(How = How.Id, Using = "txtPassword")]
        private IWebElement InstructorPassword;
        [FindsBy(How = How.Id, Using = "btnLogin_input")]
        private IWebElement LoginButton;
        [FindsBy(How = How.Id, Using = "lblConfirmNewPassword")]
        private IWebElement AssertPasswordSet;
        [FindsBy(How = How.Id, Using = "txtCurrentPassword")]
        private IWebElement CurrentPW;
        [FindsBy(How = How.Id, Using = "txtNewPassword")]
        private IWebElement NewPW;
        [FindsBy(How = How.Id, Using = "txtConfirmNewPassword")]
        private IWebElement ConfirmNewPW;
        [FindsBy(How = How.Id, Using = "btnSave_input")]
        private IWebElement SavePWSet;
        [FindsBy(How = How.XPath, Using = "//font[text()='New password has been updated successfully.']")]
        private IWebElement AssertPWSet;
        [FindsBy(How = How.Id, Using = "imgOK_input")]
        private IWebElement PWSetOkayButton;
        [FindsBy(How = How.Id, Using = "lblTimeZone")]
        private IWebElement AssertTimeZone;
        [FindsBy(How = How.Id, Using = "ddlTimeZone_Arrow")]
        private IWebElement TimeZoneDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ddlTimeZone_DropDown']/div/ul/li")]
        private IList<IWebElement> TimeZoneSelection;
        [FindsBy(How = How.Id, Using = "btnSubmit_input")]
        private IWebElement TimeZoneSubmmit;

        // COURSE CREATION
        [FindsBy(How = How.Id, Using = "ctl00_lnkCourseDetails")]
        private IWebElement CoursesnExamTab;
        [FindsBy(How = How.Id, Using = "ctl00_ExamProviderContent_gvCourseDetails_ctl00_ctl02_ctl00_lnkAddCourse")]
        private IWebElement CourseAddition;
        [FindsBy(How = How.Id, Using = "trAddCourse")]
        private IWebElement CourseAdditionMsgBox;
        [FindsBy(How = How.Id, Using = "txtCourseID")]
        private IWebElement CourseID;
        [FindsBy(How = How.Id, Using = "txtCourseName")]
        private IWebElement CourseName;
        [FindsBy(How = How.Id, Using = "btnAdd_input")]
        private IWebElement CourseSaveButton;
        [FindsBy(How = How.Id, Using = "lblInfo")]
        private IWebElement CourseAddConfirmation;
        [FindsBy(How = How.XPath, Using = "//div/table/tbody/tr/td//ul[@class='rwControlButtons']")]
        private IWebElement CloseCourseAddMsgBox;

        // EXAM CREATION
        [FindsBy(How = How.ClassName, Using = "rgFilterBox")]
        private IWebElement CourseIDSearch;
        [FindsBy(How = How.Id, Using = "ctl00_ExamProviderContent_gvCourseDetails_ctl00_ctl02_ctl03_Filter_Course_ID")]
        private IWebElement FilterButton;
        [FindsBy(How = How.XPath, Using = "//span[text()='EqualTo']")]
        private IWebElement FilterOption;
        [FindsBy(How = How.Id, Using = "ctl00_ExamProviderContent_gvCourseDetails_ctl00_ctl04_BtnAddExam")]
        private IWebElement AddExam;
        [FindsBy(How = How.Id, Using = "trAddExam")]
        private IWebElement AddExamMsgBox;
        [FindsBy(How = How.Id, Using = "txtExam")]
        private IWebElement ExamName;
        [FindsBy(How = How.Id, Using = "ddlSecurityLevel_Arrow")]
        private IWebElement ExamLevelDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ddlSecurityLevel_DropDown']/div/ul/li")]
        private IList<IWebElement> ExamLevelOptions;
        [FindsBy(How = How.Id, Using = "ddlHours_Arrow")]
        private IWebElement HoursDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ddlHours_DropDown']/div/ul/li")]
        private IList<IWebElement> HourSelection;
        [FindsBy(How = How.Id, Using = "ddlMinutes_Arrow")]
        private IWebElement MinuteDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ddlMinutes_DropDown']/div/ul/li")]
        private IList<IWebElement> MinuteSelection;
        [FindsBy(How = How.Id, Using = "txtAccessExam")]
        private IWebElement TextBox;
        [FindsBy(How = How.Id, Using = "ExamStartRadDatePicker_dateInput")]
        private IWebElement StartDate;
        [FindsBy(How = How.Id, Using = "ExamStartRadTimePicker_timePopupLink")]
        private IWebElement StartTimeDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ExamStartRadTimePicker_timeView']//tbody/tr/td/a")]
        private IList<IWebElement> ExamStartTime;
        [FindsBy(How = How.Id, Using = "ExamEndRadDatePicker_dateInput")]
        private IWebElement EndDate;
        [FindsBy(How = How.Id, Using = "ExamEndRadTimePicker_timePopupLink")]
        private IWebElement EndTimeDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ExamEndRadTimePicker_timeView']//tbody/tr/td/a")]
        private IList<IWebElement> ExamEndTime;
        [FindsBy(How = How.Id, Using = "txtExamUserName")]
        private IWebElement ExamUserName;
        [FindsBy(How = How.Id, Using = "txtExamPassword")]
        private IWebElement ExamPassword;
        [FindsBy(How = How.Id, Using = "ddlSpecialNeeds_Arrow")]
        private IWebElement ExamTimeExtension;
        [FindsBy(How = How.XPath, Using = "//div[@id='ddlSpecialNeeds_DropDown']/div/ul/li")]
        private IList<IWebElement> TimeExtensionOption;
        [FindsBy(How = How.Id, Using = "rcbStudentUpload_Arrow")]
        private IWebElement StudentUploadFile;
        [FindsBy(How = How.XPath, Using = "//div[@id='rcbStudentUpload_DropDown']/div/ul/li")]
        private IList<IWebElement> StudentUploadOption;
        [FindsBy(How = How.Id, Using = "ddlreusespecialinstructions_Arrow")]
        private IWebElement AdditionalRules;
        [FindsBy(How = How.XPath, Using = "//div[@id='ddlreusespecialinstructions_DropDown']/div/ul/li")]
        private IList<IWebElement> AdditionalRulesOption;
        [FindsBy(How = How.Id, Using = "chkStudent")]
        private IWebElement InstructionForStudent;
        [FindsBy(How = How.Id, Using = "chkProctor")]
        private IWebElement InstructionForProctor;
        [FindsBy(How = How.Id, Using = "chkStudentAndProctor")]
        private IWebElement CommonInstruction;
        [FindsBy(How = How.Id, Using = "taAdditionalRules")]
        private IWebElement SpecialInstructions;
        [FindsBy(How = How.Id, Using = "rdRulesSave_input")]
        private IWebElement SavingInstruction;
        [FindsBy(How = How.Id, Using = "BtnSaveExam_input")]
        private IWebElement SaveExam;
        [FindsBy(How = How.Id, Using = "lblInfo")]
        private IWebElement ExamCreationAssert;
        [FindsBy(How = How.XPath, Using = "//div/table/tbody/tr/td//ul[@class='rwControlButtons']")]
        private IWebElement CloseExamCreation;

        // STUDENT ENROLLMENT
        [FindsBy(How = How.Id, Using = "ctl00_LnkStudentRegistration")]
        private IWebElement StudentTab;
        [FindsBy(How = How.ClassName, Using = "rgFilterBox")]
        private IWebElement CourseIDforStudentEnrollment;
        [FindsBy(How = How.ClassName, Using = "rgFilter")]
        private IWebElement FilterButtonforStudentEnrollment;
        [FindsBy(How = How.XPath, Using = "//span[text()='EqualTo']")]
        private IWebElement FilterOption1;
        [FindsBy(How = How.Id, Using = "ctl00_ExamProviderContent_gvCourseDetails_ctl00_ctl04_BtnAddStudent")]
        private IWebElement EnrollmentofStudent;
        [FindsBy(How = How.Id, Using = "ctl00_ExamProviderContent_gvCourseDetails_ctl00_ctl02_ctl00_lnkAddStudent")]
        private IWebElement AddStudentIcon;
        [FindsBy(How = How.Id, Using = "trEnrollStudent")]
        private IWebElement AddStudentMsgBox;
        [FindsBy(How = How.XPath, Using = "//body/form/table/tbody/tr/td/div/table/tbody/tr/td//a[text()='Add New Student']")]
        private IWebElement AddNewStudent;
        [FindsBy(How = How.Id, Using = "txtFirstName")]
        private IWebElement StudentFName;
        [FindsBy(How = How.Id, Using = "txtLastName")]
        private IWebElement StudentLName;
        [FindsBy(How = How.Id, Using = "txtUserID")]
        private IWebElement StudentUserID;
        [FindsBy(How = How.Id, Using = "txtEmailAddress")]
        private IWebElement StudentEmail;
        [FindsBy(How = How.Id, Using = "rcbNewCourses_Arrow")]
        private IWebElement CoursesSelectionDropDown;
        [FindsBy(How = How.XPath, Using = "//div[@id='rcbNewCourses_DropDown']/div/ul/li")]
        private IList<IWebElement> SelectionofCourseforStudent;
        [FindsBy(How = How.Id, Using = "ChkSpecialNeeds")]
        private IWebElement SpecialAccomodation;
        [FindsBy(How = How.Id, Using = "txtcomments")]
        private IWebElement CommentsBox;
        [FindsBy(How = How.Id, Using = "btnAdd_input")]
        private IWebElement OkayButton;
        [FindsBy(How = How.ClassName, Using = "rwCloseButton")]
        private IWebElement StudentAddClose;
        [FindsBy(How = How.Id, Using = "ctl00_lnlLogout")]
        private IWebElement LogoutButton;

        // ENROLL STUDENT FOR COURSE
        [FindsBy(How = How.Id, Using = "ctl00_ExamProviderContent_gvCourseDetails_ctl00_ctl04_BtnAddStudent")]
        private IWebElement StudentEnrollmentforCourse;
        [FindsBy(How = How.Id, Using = "rcbStudents_Arrow")]
        private IWebElement StudentSelectionDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='rcbStudents_DropDown']/div/ul/li")]
        private IList<IWebElement> StudentSelection;
        [FindsBy(How = How.Id, Using = "btnAdd_input")]
        private IWebElement StudentSelectionSaveButton;
        [FindsBy(How = How.ClassName, Using = "rwCloseButton")]
        private IWebElement StudentCourseEnrollmentClose;

        public void LoginAsInstructor(string instructorPassword,
                                      string timeZone)
        {
            try
            {
                EnterValues(InstructorUserName, AdminDashboardLoginPage.InstructorUID);
                ReportLog("Passed", "Entered instructor username as " + AdminDashboardLoginPage.InstructorUID);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter instructor username");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(InstructorPassword, instructorPassword);
                ReportLog("Passed", "Entered instructor password as " + instructorPassword);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter instructor password");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(LoginButton);
                ReportLog("Passed", "Clicked on login button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on login button");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(AssertPasswordSet.Displayed);
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
                EnterValues(CurrentPW, instructorPassword);
                ReportLog("Passed", "Entered current password as " + instructorPassword);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter current password");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(NewPW, instructorPassword);
                ReportLog("Passed", "Entered new password as " + instructorPassword);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter new password");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(ConfirmNewPW, instructorPassword);
                ReportLog("Passed", "Re-entered new password as " + instructorPassword);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't re-enter new password");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SavePWSet);
                ReportLog("Passed", "Clicked on PW save button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on PW save button");
                throw ex;
            }
            HardSleep();
            try
            {
                Assert.True(AssertPWSet.Displayed);
                ReportLog("Passed", "Asserted password reset confirmation text");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert password reset confirmation text");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(PWSetOkayButton);
                ReportLog("Passed", "Clicked on password reset confirmation okay button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on password reset confirmation okay button");
                throw ex;
            }
            HardSleep();
            try
            {
                Assert.True(AssertTimeZone.Displayed);
                ReportLog("Passed", "Asserted time zone selection page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert time zone selection page");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(TimeZoneDropdown);
                ReportLog("Passed", "Clicked on time zone selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on time zone selection dropdown");
                throw ex;
            }
            HardSleep();
            try
            {
                foreach (IWebElement TimeZone in TimeZoneSelection)
                {
                    if (TimeZone.Text.Contains(timeZone))
                    {
                        ClickElement(TimeZone);
                        break;
                    }
                }
                ReportLog("Passed", "Selected a time zone as " + timeZone);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select a time zone");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(TimeZoneSubmmit);
                ReportLog("Passed", "Clicked on time zone submit button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on time zone submit button");
                throw ex;
            }
            MediumSleep();
        }

        public void CourseCreation(string courseID)
        {
            try
            {
                ClickElement(CoursesnExamTab);
                ReportLog("Passed", "Clicked on courses tab");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on courses tab");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(CourseAddition);
                ReportLog("Passed", "Clicked on add course");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on add course");
                throw ex;
            }
            HardSleep();
            try
            {
                driver.SwitchTo().Frame(0);
                Assert.True(CourseAdditionMsgBox.Displayed);
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
                string CourseIDRandom = GenerateRandomNumber(5);
                COURSEid = courseID + CourseIDRandom;
                EnterValues(CourseID, COURSEid);
                ReportLog("Passed", "Entered course ID as " + COURSEid);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter course ID");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(CourseName, COURSEid);
                ReportLog("Passed", "Entered course name as " + COURSEid);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter course name");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(CourseSaveButton);
                ReportLog("Passed", "Clicked on save button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on save button");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(CourseAddConfirmation.Displayed);
                ReportLog("Passed", "Asserted course creation confirmation");
                HardSleep();
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert course creation confirmation");
                throw ex;
            }
            ScreenCapture(driver, "Course creation");
            QuickSleep();
            try
            {
                driver.SwitchTo().DefaultContent();
                ClickElement(CloseCourseAddMsgBox);
                ReportLog("Passed", "Clicked on close button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on close button");
                throw ex;
            }
            MediumSleep();
        }

        public void ExamCreation(string examLevel,
                                 string hourlyTime,
                                 string minutelyTime,
                                 string ExamAccessLink,
                                 string examStartTime,
                                 string examEndTime,
                                 string extendTime,
                                 string studentFile,
                                 string addRules,
                                 string InstructionStudent,
                                 string InstructionProctor,
                                 string InstructionCommon)
        {
            try
            {
                EnterValues(CourseIDSearch, COURSEid);
                ReportLog("Passed", "Entered the course ID as " + COURSEid);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the course ID");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(FilterButton);
                ReportLog("Passed", "Clicked on the filter button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the filter button");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(FilterOption);
                ReportLog("Passed", "Clicked on the filter option");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the filter option");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(AddExam);
                ReportLog("Passed", "Clicked on add exam icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on add exam icon");
                throw ex;
            }
            HardSleep();
            try
            {
                driver.SwitchTo().Frame(0);
                Assert.True(AddExamMsgBox.Displayed);
                ReportLog("Passed", "Asserted");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(ExamLevelDropdown);
                ReportLog("Passed", "Clicked on exam level dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on exam level dropdown");
                throw ex;
            }
            MediumSleep();
            try
            {
                foreach (IWebElement ELOption in ExamLevelOptions)
                {
                    if (ELOption.Text.Contains(examLevel))
                    {
                        ClickElement(ELOption);
                        break;
                    }
                }
                ReportLog("Passed", "Selected exam level as " + examLevel);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select exam level");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(HoursDropdown);
                ReportLog("Passed", "Clicked on hours time set-up dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on hours time set-up dropdown");
                throw ex;
            }
            MediumSleep();
            try
            {
                foreach (IWebElement Hours in HourSelection)
                {
                    QuickSleep();
                    if (Hours.Text.Equals(hourlyTime))
                    {
                        ClickElement(Hours);
                        break;
                    }
                }
                ReportLog("Passed", "Selected hourly time as " + hourlyTime);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select hourly time");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(MinuteDropdown);
                ReportLog("Passed", "Clicked on minutes time set-up dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on minute time set-up dropdown");
                throw ex;
            }
            MediumSleep();
            try
            {
                foreach (IWebElement Minutes in MinuteSelection)
                {
                    if (Minutes.Text.Contains(minutelyTime))
                    {
                        ClickElement(Minutes);
                        break;
                    }
                }
                ReportLog("Passed", "Selected minutely time as " + minutelyTime);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select minutely time");
                throw ex;
            }
            QuickSleep();
            try
            {
                EXAMNAME = examLevel + "_" + hourlyTime + "Hours";
                EnterValues(ExamName, EXAMNAME);
                ReportLog("Passed", "Entered exam name as " + EXAMNAME);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter exam name");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(TextBox, ExamAccessLink);
                ReportLog("Passed", "Entered exam access link as " + ExamAccessLink);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter exam access link");
                throw ex;
            }
            QuickSleep();
            try
            {
                string startDate = DateTime.Now.ToString("M/d/yyyy");
                EnterValues(StartDate, startDate);
                ReportLog("Passed", "Entered start date as " + startDate);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter start date");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(StartTimeDropdown);
                ReportLog("Passed", "Clicked on the start time dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the start time dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                foreach (IWebElement ExamStartTime in ExamStartTime)
                {
                    if (ExamStartTime.Text.Contains(examStartTime))
                    {
                        ClickElement(ExamStartTime);
                        break;
                    }
                }
                ReportLog("Passed", "Selected the start time as " + examStartTime);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select the start time");
                throw ex;
            }
            QuickSleep();
            try
            {
                string ENDDATE = DateTime.Today.AddDays(365).ToString("M/d/yyyy");
                EnterValues(EndDate, ENDDATE);
                ReportLog("Passed", "Entered end date as " + ENDDATE);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter end date");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(EndTimeDropdown);
                ReportLog("Passed", "Clicked on the end time dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the end time dropdown");
                throw ex;
            }
            MediumSleep();
            try
            {
                foreach (IWebElement ExamEndTime in ExamEndTime)
                {
                    if (ExamEndTime.Text.Contains(examEndTime))
                    {
                        ClickElement(ExamEndTime);
                        break;
                    }
                }
                ReportLog("Passed", "Selected the end time as " + examEndTime);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select the end time");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(ExamUserName, EXAMNAME);
                ReportLog("Passed", "Entered exam username as " + EXAMNAME);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter exam username");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(ExamPassword, EXAMNAME);
                ReportLog("Passed", "Entered exam password as " + EXAMNAME);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter exam password");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ExamTimeExtension);
                ReportLog("Passed", "Clicked on time extension dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on time extension dropdown");
                throw ex;
            }
            MediumSleep();
            try
            {
                foreach (IWebElement ExtendTime in TimeExtensionOption)
                {
                    if (ExtendTime.Text.Contains(extendTime))
                    {
                        ClickElement(ExtendTime);
                        break;
                    }
                }
                ReportLog("Passed", "Selected time extension option as " + extendTime);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select time extension option");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(StudentUploadFile);
                ReportLog("Passed", "Clicked on student upload file");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on student upload file");
                throw ex;
            }
            MediumSleep();
            try
            {
                foreach (IWebElement StudentFile in StudentUploadOption)
                {
                    if (StudentFile.Text.Contains(studentFile))
                    {
                        ClickElement(StudentFile);
                        break;
                    }
                }
                ReportLog("Passed", "Selected student uploading file option as " + studentFile);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select student uploading file option");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(AdditionalRules);
                ReportLog("Passed", "Clicked on additional rules dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on additional rules dropdown");
                throw ex;
            }
            MediumSleep();
            try
            {
                foreach (IWebElement AddRules in AdditionalRulesOption)
                {
                    if (AddRules.Text.Contains(addRules))
                    {
                        ClickElement(AddRules);
                        break;
                    }
                }
                ReportLog("Passed", "Selected additional rules option 1 as " + addRules);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select additional rules option 1");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(InstructionForStudent);
                ReportLog("Passed", "Checked student option");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't check student option");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(SpecialInstructions, InstructionStudent);
                ReportLog("Passed", "Entered additional instructions for student only as " + InstructionStudent);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter additional instructions for student only");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SavingInstruction);
                ReportLog("Passed", "Clicked on save button after entering additional instructions");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on save button after entering additional instructions");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(InstructionForProctor);
                ReportLog("Passed", "Checked proctor option");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't check proctor option");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(SpecialInstructions, InstructionProctor);
                ReportLog("Passed", "Entered additional instructions for proctor only as " + InstructionProctor);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter additional instructions for proctor only");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SavingInstruction);
                ReportLog("Passed", "Clicked on save button after entering additional instructions");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on save button after entering additional instructions");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(CommonInstruction);
                ReportLog("Passed", "Checked student & proctor option");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't check student & proctor option");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(SpecialInstructions, InstructionCommon);
                ReportLog("Passed", "Entered additional instructions common for both student & proctor as " + InstructionCommon);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter additional instructions common for both student & proctor");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SavingInstruction);
                ReportLog("Passed", "Clicked on save button after entering additional instructions");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on save button after entering additional instructions");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(SaveExam);
                ReportLog("Passed", "Clicked on save button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on save button");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(ExamCreationAssert.Displayed);
                ReportLog("Passed", "Asserted successful exam creation");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't asserted exam creation");
                throw ex;
            }
            ScreenCapture(driver, "Exam creation");
            HardSleep();
            try
            {
                driver.SwitchTo().DefaultContent();
                ClickElement(CloseExamCreation);
                ReportLog("Passed", "Clicked on exam creation close button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on exam creation close button");
                throw ex;
            }
            QuickSleep();
        }

        public void StudentEnrollment(string studentFName,
                                      string studentLName,
                                      string studentEmail,
                                      string commentsBox)
        {
            try
            {
                ClickElement(StudentTab);
                ReportLog("Passed", "Clicked on students tab");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on studenst tab");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(CourseIDforStudentEnrollment, COURSEid);
                ReportLog("Passed", "Entered the course-ID for student enrollment as " + COURSEid);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the course-ID for student enrollment");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(FilterButtonforStudentEnrollment);
                ReportLog("Passed", "Clicked on filter button for student enrollment");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on filter button for student enrollment");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(FilterOption1);
                ReportLog("Passed", "Clicked on the filter option");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the filter option");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(AddStudentIcon);
                ReportLog("Passed", "Clicked on add student icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on add student icon");
                throw ex;
            }
            HardSleep();
            driver.SwitchTo().Frame(0);
            try
            {
                Assert.True(AddStudentMsgBox.Displayed);
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
                ClickElement(AddNewStudent);
                ReportLog("Passed", "Clicked on add new student");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on add new student");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(StudentFName, studentFName);
                ReportLog("Passed", "Entered the student first name as " + studentFName);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the student first name");
                throw ex;
            }
            QuickSleep();
            try
            {
                LastNameStudent = GenerateRandomNumber(5);
                StudentLastName = studentLName + LastNameStudent;
                EnterValues(StudentLName, StudentLastName);
                ReportLog("Passed", "Entered the student last name as " + StudentLastName);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the student last name");
                throw ex;
            }
            QuickSleep();
            try
            {
                studentUserID = studentFName + studentLName + LastNameStudent ;
                EnterValues(StudentUserID, studentUserID);
                ReportLog("Passed", "Entered the student user ID as " + studentUserID);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the student user ID");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(StudentEmail, studentEmail);
                ReportLog("Passed", "Entered the student email as " + studentEmail);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the student email");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(CoursesSelectionDropDown);
                ReportLog("Passed", "Clicked on courses selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on courses selection dropdown");
                throw ex;
            }
            MediumSleep();
            try
            {
                foreach (IWebElement CoursesOp in SelectionofCourseforStudent)
                {
                    if (CoursesOp.Text.EndsWith(COURSEid))
                    {
                        HardSleep();
                        ClickElement(CoursesOp);
                        break;
                    }
                }
                ReportLog("Passed", "Selected a filter option as " + COURSEid);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select a filter option");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SpecialAccomodation);
                ReportLog("Passed", "Clicked on special accomodation checkbox");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on special accomodation checkbox");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(CommentsBox, commentsBox);
                ReportLog("Passed", "Entered comments as " + commentsBox);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter comments");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(OkayButton);
                ReportLog("Passed", "Clicked on okay button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on okay button");
                throw ex;
            }
            HardSleep();
            ScreenCapture(driver, "Student creation");
            try
            {
                driver.SwitchTo().DefaultContent();
                ClickElement(StudentAddClose);
                ReportLog("Passed", "Clicked on exam creation close button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on exam creation close button");
                throw ex;
            }
            HardSleep();
            try
            {
                ClickElement(LogoutButton);
                ReportLog("Passed", "Clicked on logout button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on logout button");
                throw ex;
            }
            QuickSleep();
        }

        public void StudentEnrollmentForCourse()
        {
            try
            {
                ClickElement(StudentEnrollmentforCourse);
                ReportLog("Passed", "Clicked on add student enroll icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on add student enroll icon");
                throw ex;
            }
            driver.SwitchTo().Frame(0);
            QuickSleep();
            try
            {
                ClickElement(StudentSelectionDropdown);
                ReportLog("Passed", "Clicked on student selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on student selection dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                foreach (IWebElement Student in StudentSelection)
                {
                    if (Student.Text.Equals(studentUserID))
                    {
                        ClickElement(Student);
                        break;
                    }
                }
                ReportLog("Passed", "Selected a student as " + studentUserID);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select a student");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(StudentSelectionSaveButton);
                ReportLog("Passed", "Clicked on student enrollment for course save button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on student enrollment for course save button");
                throw ex;
            }
            HardSleep();
            ScreenCapture(driver, "Student enrollment");
            try
            {
                driver.SwitchTo().DefaultContent();
                ClickElement(StudentCourseEnrollmentClose);
                ReportLog("Passed", "Clicked on student enrollment for course close button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on student enrollment for course close button");
                throw ex;
            }
            HardSleep();
            try
            {
                ClickElement(LogoutButton);
                ReportLog("Passed", "Clicked on logout button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on logout button");
                throw ex;
            }
            QuickSleep();
        }
    }
}

