using AdminDashboard.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace AdminDashboard.PageObjects
{
    class AuditorDashboardPage : BasePage
    {
        public AuditorDashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public IWebDriver driver;

        // LOGIN IN AS AUDITOR
        [FindsBy(How = How.Id, Using = "txtUserName")]
        private IWebElement UserId;
        [FindsBy(How = How.Id, Using = "txtPassword")]
        private IWebElement Password;
        [FindsBy(How = How.Id, Using = "btnLogin_input")]
        private IWebElement LoginButton;
        [FindsBy(How = How.XPath, Using = "//table[@id='rdRoles']/tbody/tr/td/input")]
        private IList<IWebElement> RoleSelection;
        [FindsBy(How = How.Id, Using = "rdRoles_0")]
        private IWebElement AuditorRole;
        [FindsBy(How = How.Id, Using = "btnLogin_input")]
        private IWebElement LoginRole;

        // NAVIGATE TO INBOX
        [FindsBy(How = How.Id, Using = "ctl00_lnkInbox")]
        private IWebElement InboxTab;
        [FindsBy(How = How.Id, Using = "ctl00_AuditorContent_lblprocessedexamlink")]
        private IWebElement ProcessedExamlink;
        [FindsBy(How = How.Id, Using = "ctl00_AuditorContent_gvAuditorInbox_ctl00_ctl02_ctl02_FilterTextBox_TransID")]
        private IWebElement AppoinmentIDSearch;
        [FindsBy(How = How.Id, Using = "ctl00_AuditorContent_gvAuditorInbox_ctl00_ctl02_ctl02_Filter_TransID")]
        private IWebElement FilterButton;
        [FindsBy(How = How.XPath, Using = "//span[text()='EqualTo']")]
        private IWebElement FilterOption;
        [FindsBy(How = How.Id, Using = "ctl00_AuditorContent_gvAuditorInbox_ctl00_ctl04_lnkView")]
        private IWebElement ViewExam;

        // COMMENTS SECTION
        [FindsBy(How = How.Id, Using = "vimg")]
        private IWebElement VideoPlayButton;
        [FindsBy(How = How.Id, Using = "ctl00_AuditorContent_btnDeleteAlerts_input")]
        private IWebElement DeleteFlagsButton;
        [FindsBy(How = How.Id, Using = "ctl00_AuditorContent_ddlFlags_Arrow")]
        private IWebElement FlagSelectionDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_AuditorContent_ddlFlags_DropDown']/div/ul/li")]
        private IList<IWebElement> FlagSelection;
        [FindsBy(How = How.Id, Using = "ctl00_AuditorContent_ddlHours_Arrow")]
        private IWebElement HoursDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_AuditorContent_ddlHours_DropDown']/div/ul/li")]
        private IList<IWebElement> HoursSelection;
        [FindsBy(How = How.Id, Using = "ctl00_AuditorContent_ddlMinutes_Arrow")]
        private IWebElement MinutesDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_AuditorContent_ddlMinutes_DropDown']/div/ul/li")]
        private IList<IWebElement> MinutesSelection;
        [FindsBy(How = How.Id, Using = "ctl00_AuditorContent_ddlsec_Arrow")]
        private IWebElement SecondsDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_AuditorContent_ddlsec_DropDown']/div/ul/li")]
        private IList<IWebElement> SecondsSelection;
        [FindsBy(How = How.Id, Using = "ctl00_AuditorContent_ddlAlerts_Arrow")]
        private IWebElement DescriptionDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_AuditorContent_ddlAlerts_DropDown']/div/ul/li")]
        private IList<IWebElement> DescriptionSelection;
        [FindsBy(How = How.Id, Using = "ctl00_AuditorContent_txtComments")]
        private IWebElement ProctorCommentsAdditional;
        [FindsBy(How = How.Id, Using = "ctl00_AuditorContent_btnAddComments_input")]
        private IWebElement AddButton;
        [FindsBy(How = How.Id, Using = "ctl00_AuditorContent_gvComments_ctl00_ctl04_ClientSelectColumn1SelectCheckBox")]
        private IWebElement CheckboxHandling;
        [FindsBy(How = How.Id, Using = "ctl00_AuditorContent_btnApprove_input")]
        private IWebElement ApproveButton;
        [FindsBy(How = How.Id, Using = "ctl00_AuditorContent_imgConfirm_input")]
        private IWebElement ApproveButton2;
        [FindsBy(How = How.Id, Using = "ctl00_AuditorContent_lblSuccess")]
        private IWebElement ApprovalConfirmationText;
        [FindsBy(How = How.Id, Using = "ctl00_AuditorContent_btnInbox_input")]
        private IWebElement InboxButton;

        //PROCESSED EXAMS VALIDATION
        [FindsBy(How = How.Id, Using = "ctl00_AuditorContent_gvProcessedExamRequest_ctl00_ctl02_ctl02_FilterTextBox_TransID")]
        private IWebElement PEAppointmentIDSearch;
        [FindsBy(How = How.Id, Using = "ctl00_AuditorContent_gvProcessedExamRequest_ctl00_ctl02_ctl02_Filter_TransID")]
        private IWebElement PEFilterButton;
        [FindsBy(How = How.XPath, Using = "//span[text()='EqualTo']")]
        private IWebElement PEFilterOption;

        public void LoginAsAdmin(string AuditorUsername,
                                 string AuditorPassword,
                                 string SwitchRoleUrl,
                                 string Role)
        {
            try
            {
                EnterValues(UserId, AuditorUsername);
                ReportLog("Passed", "Entered the auditor-username as " + AuditorUsername);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the auditor-username");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(Password, AuditorPassword);
                ReportLog("Passed", "Entered auditor-password as " + AuditorPassword);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter auditor-password");
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
                MediumSleep();
                try
                {
                    ClickElement(AuditorRole);
                    ReportLog("Passed", "Selected auditor role");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't select auditor role");
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

        public void NavigateToInbox()
        {
            try
            {
                ClickElement(InboxTab);
                ReportLog("Passed", "Clicked on the inbox tab");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the inbox tab");
                throw ex;
            }
            MediumSleep();
            try
            {
                EnterValues(AppoinmentIDSearch, StudentDashboardPage.AppoinmentID);
                ReportLog("Passed", "Entered appointment ID as " + StudentDashboardPage.AppoinmentID);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter appointment ID");
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
            QuickSleep();
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
                ClickElement(ViewExam);
                ReportLog("Passed", "Clicked on the view exam link");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the view exam link");
                throw ex;
            }
            QuickSleep();
            try
            {
                driver.SwitchTo().Window(driver.WindowHandles[3]);
                ReportLog("Passed", "Opened new window");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't open new window");
                throw ex;
            }
            HardSleep();
            try
            {
                driver.SwitchTo().Alert().Accept();
                ReportLog("Passed", "Accepted pop-up alert");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't accept pop-up alert");
                throw ex;
            }
            MediumSleep();
            ScreenCapture(driver, "Proctor submission for exam appointment ID" + StudentDashboardPage.AppoinmentID);
            try
            {
                VideoPlayButton.Click();
                ReportLog("Passed", "Opened new window");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't open new window");
                throw ex;
            }
            HardSleep();
        }

        public void AuditorComments(string Flag,
                                    string ExamHours,
                                    string ExamMinutes,
                                    string ExamSeconds,
                                    string ProctorComment2,
                                    string AuditorAdditionalComments)
        {
            try
            {
                ClickElement(CheckboxHandling);
                ReportLog("Passed", "Checked on check-box");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't check all comments");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(DeleteFlagsButton);
                ReportLog("Passed", "Clicked on delete button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on delete button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(FlagSelectionDropdown);
                ReportLog("Passed", "Clicked on flag selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on flag selection dropdown");
                throw ex;
            }
            MediumSleep();
            try
            {
                foreach (IWebElement flag in FlagSelection)
                {
                    if (flag.Text.Contains(Flag))
                    {
                        ClickElement(flag);
                        break;
                    }
                }
                ReportLog("Passed", "Selected " + Flag + " flag");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select flag");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(HoursDropdown);
                ReportLog("Passed", "Clicked on hours dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on hours dropdown");
                throw ex;
            }
            MediumSleep();
            try
            {
                foreach (IWebElement hour in HoursSelection)
                {
                    if (hour.Text.Contains(ExamHours))
                    {
                        ClickElement(hour);
                        break;
                    }
                }
                ReportLog("Passed", "Selected " + ExamHours + " hours");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select hourly time");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(MinutesDropdown);
                ReportLog("Passed", "Clicked on minutes dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on minutes dropdown");
                throw ex;
            }
            MediumSleep();
            try
            {
                foreach (IWebElement minute in MinutesSelection)
                {
                    if (minute.Text.Contains(ExamMinutes))
                    {
                        ClickElement(minute);
                        break;
                    }
                }
                ReportLog("Passed", "Selected " + ExamMinutes + " minutes");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select minutely time");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SecondsDropdown);
                ReportLog("Passed", "Clicked on seconds dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on seconds dropdown");
                throw ex;
            }
            MediumSleep();
            try
            {
                foreach (IWebElement seconds in SecondsSelection)
                {
                    if (seconds.Text.Contains(ExamSeconds))
                    {
                        ClickElement(seconds);
                        break;
                    }
                }
                ReportLog("Passed", "Selected " + ExamSeconds + " seconds");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select seconds");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(DescriptionDropdown);
                ReportLog("Passed", "Clicked on description dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on description dropdown");
                throw ex;
            }
            MediumSleep();
            try
            {
                foreach (IWebElement description in DescriptionSelection)
                {
                    if (description.Text.Contains(ProctorComment2))
                    {
                        ClickElement(description);
                        break;
                    }
                }
                ReportLog("Passed", "Selected description as " + ProctorComment2);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select description");
                throw ex;
            }
            MediumSleep();
            try
            {
                EnterValues(ProctorCommentsAdditional, AuditorAdditionalComments);
                ReportLog("Passed", "Entered additional auditor comments as " + AuditorAdditionalComments);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter additional auditor comments");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(AddButton);
                ReportLog("Passed", "Clicked on add button for auditor comments");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on add button for auditor comments");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ApproveButton);
                ReportLog("Passed", "Clicked on the approve button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on approve button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ApproveButton2);
                ReportLog("Passed", "Clicked on the second approve button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the second approve button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(InboxButton);
                ReportLog("Passed", "Clicked on inbox button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on inbox button");
                throw ex;
            }
            QuickSleep();
        }

        public void ProcessedExamsValidation()
        {
            try
            {
                ClickElement(ProcessedExamlink);
                ReportLog("Passed", "Clicked on processed exams link");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on processed exams link");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(PEAppointmentIDSearch, StudentDashboardPage.AppoinmentID);
                ReportLog("Passed", "Entered appointment ID in processed exams link as " + StudentDashboardPage.AppoinmentID);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter appointment ID in processed exams link");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(PEFilterButton);
                ReportLog("Passed", "Clicked on the filter button in processed exams link");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the filter button in processed exams link");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(PEFilterOption);
                ReportLog("Passed", "Clicked on the filter option in processed exams link");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the filter option in processed exams link");
                throw ex;
            }
            HardSleep();
            ScreenCapture(driver, "Processed exam validation for appointment ID" + StudentDashboardPage.AppoinmentID);
        }
    }
}
