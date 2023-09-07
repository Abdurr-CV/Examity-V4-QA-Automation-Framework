using AdminDashboard.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace AdminDashboard.PageObjects
{
    class ProctorDashboardPage : BasePage
    {
        public ProctorDashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public IWebDriver driver;
        public IWebDriver driver1;

        // LGOGIN PAGE
        [FindsBy(How = How.Id, Using = "txtUserName")]
        private IWebElement ProctorLoginUsername;
        [FindsBy(How = How.Id, Using = "txtPassword")]
        private IWebElement ProctorLoginPassword;
        [FindsBy(How = How.Id, Using = "btnSignIn")]
        private IWebElement ProctorLoginButton;

        // WORK STATION PAGE
        [FindsBy(How = How.XPath, Using = "//a/u/b[text()='here']")]
        private IWebElement WorkStationPageClickPoint;
        [FindsBy(How = How.ClassName, Using = "rddlIcon")]
        private IWebElement LocationDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='radLocation_DropDown']/div/ul/li")]
        private IList<IWebElement> LocationSelection;
        [FindsBy(How = How.XPath, Using = "//div[@id='radWorkStation_DropDown']/div/ul/li")]
        private IList<IWebElement> WorkStationSelection;
        [FindsBy(How = How.Id, Using = "btnSignIn")]
        private IWebElement WorkStationSignInButton;

        // NAVIGATING TO WAITING EXAMS
        [FindsBy(How = How.XPath, Using = "//div[@id='ui-accordion-accordion-panel-0']/table/tbody/tr/td/div")]
        private IList<IWebElement> FunctionIconSelection;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lnkexams")]
        private IWebElement AllExamsTab;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_txtExamId")]
        private IWebElement AppoinmentIDInput;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnSearch")]
        private IWebElement AppoinmentSearchButton;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_gvExamsList_ctl00_ctl04_pnlExamID")]
        private IWebElement AppoinmentIDClick;
        [FindsBy(How = How.Id, Using = "btnYes")]
        private IWebElement YesCommandClick;

        // EXAM COMMENCEMENT
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_Image4")]
        private IWebElement ZoomImgClick;
        [FindsBy(How = How.XPath, Using = "//a[text()='Start Zoom Meeting']")]
        private IWebElement StartMeetingCommand;
        [FindsBy(How = How.Id, Using = "radWorkStation_Input")]
        private IWebElement WorkStationInput;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_lnkAuthentication")]
        private IWebElement StartAuthenticationLink;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_lnkStudentIDCheck")]
        private IWebElement StudentIdentificationVerification;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_tbcExistingExamDetails_tbpComments_lblHeaderComments")]
        private IWebElement ProctorCommentsTab;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_tbcExistingExamDetails_tbpComments_ddlFlags_Arrow")]
        private IWebElement FlagSelectionDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ProctorContent_tbcExistingExamDetails_tbpComments_ddlFlags_DropDown']/div/ul/li")]
        private IList<IWebElement> FlagSelection;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_tbcExistingExamDetails_tbpComments_ddlHours_Arrow")]
        private IWebElement HoursDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ProctorContent_tbcExistingExamDetails_tbpComments_ddlHours_DropDown']/div/ul/li")]
        private IList<IWebElement> HoursSelection;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_tbcExistingExamDetails_tbpComments_ddlMinutes_Arrow")]
        private IWebElement MinutesDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ProctorContent_tbcExistingExamDetails_tbpComments_ddlMinutes_DropDown']/div/ul/li")]
        private IList<IWebElement> MinutesSelection;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_tbcExistingExamDetails_tbpComments_ddlsec_Arrow")]
        private IWebElement SecondsDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ProctorContent_tbcExistingExamDetails_tbpComments_ddlsec_DropDown']/div/ul/li")]
        private IList<IWebElement> SecondsSelection;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_tbcExistingExamDetails_tbpComments_ddlAlerts_Arrow")]
        private IWebElement DescriptionDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ProctorContent_tbcExistingExamDetails_tbpComments_ddlAlerts_DropDown']/div/ul/li")]
        private IList<IWebElement> DescriptionSelection;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_tbcExistingExamDetails_tbpComments_txtComments")]
        private IWebElement ProctorCommentsAdditional;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_tbcExistingExamDetails_tbpComments_btnAddComments_input")]
        private IWebElement AddButton;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_lnlExamend")]
        private IWebElement ExamCompleteLink;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_rdApprove_0")]
        private IWebElement ExamApprovalButton;
        [FindsBy(How = How.XPath, Using = "//input[@value='Submit']")]
        private IWebElement ProctoringSubmitButton;

        public void ProctorLogin(string ProctorUsername,
                                 string ProctorPassword,
                                 string Location,
                                 string WorkStation)
        {
            try
            {
                EnterValues(ProctorLoginUsername, ProctorUsername);
                ReportLog("Passed", "Entered proctor username as " + ProctorUsername);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter proctor username");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(ProctorLoginPassword, ProctorPassword);
                ReportLog("Passed", "Entered proctor password as " + ProctorPassword);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter proctor password");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ProctorLoginButton);
                ReportLog("Passed", "Clicked on proctor login button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on proctor login button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(WorkStationPageClickPoint);
                ReportLog("Passed", "Clicked on 'click here' link");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on 'click here' link");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(LocationDropdown);
                ReportLog("Passed", "Clicked on location dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on location dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                foreach (IWebElement location in LocationSelection)
                {
                    if (location.Text.Contains(Location))
                    {
                        ClickElement(location);
                        break;
                    }
                }
                ReportLog("Passed", "Selected workstation location as , " + Location);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select workstation location");
                throw ex;
            }
            MediumSleep();
            try
            {
                EnterValues(WorkStationInput, WorkStation);
                ReportLog("Passed", "Entered workstation as " + WorkStation);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter workstation");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(WorkStationSignInButton);
                ReportLog("Passed", "Clicked on workstation sign-in button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on workstation sign-in button");
                throw ex;
            }
            QuickSleep();
        }

        public void NavigationToStartExam(string ExamIcon)
        {
            try
            {
                foreach (IWebElement examIcon in FunctionIconSelection)
                {
                    if (examIcon.Text.Contains(ExamIcon))
                    {
                        ClickElement(examIcon);
                        break;
                    }
                }
                ReportLog("Passed", "Selected function icon , " + ExamIcon);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select function icon");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(AllExamsTab);
                ReportLog("Passed", "Clicked on workstation sign-in button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on workstation sign-in button");
                throw ex;
            }
            HardSleep();
            try
            {
                EnterValues(AppoinmentIDInput, StudentDashboardPage.AppoinmentID);
                ReportLog("Passed", "Entered appoinment ID as " + StudentDashboardPage.AppoinmentID);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter appoinment ID");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(AppoinmentSearchButton);
                ReportLog("Passed", "Clicked on appoinment search button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on appoinment search button");
                throw ex;
            }
            FasterSleep();
            try
            {
                ClickElement(AppoinmentIDClick);
                ReportLog("Passed", "Clicked on appoinment ID");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on appoinment ID");
                throw ex;
            }
            QuickSleep();
            try
            {
                driver1 = TestBase.driver1;
                driver1.SwitchTo().Frame(0);
                MediumSleep();
                ClickElement(YesCommandClick);
                ReportLog("Passed", "Clicked on yes command for exam commencement");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on yes command for exam commencement");
                throw ex;
            }
            MediumSleep();
            try
            {
                driver1 = TestBase.driver1;
                driver1.SwitchTo().Window(driver1.WindowHandles[1]);
                ReportLog("Passed", "driver1 switched to new tab");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "driver1 didn't switch to new tab");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ZoomImgClick);
                ReportLog("Passed", "Clicked on start zoom");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on start zoom");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(StartMeetingCommand);
                FasterSleep();
                ReportLog("Passed", "Clicked on start zoom meeting");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on start zoom meeting");
                throw ex;
            }
            FasterSleep();
            string tabToCloseTitle = "Launch Meeting - Zoom - Profile 1 - Microsoft Edge";
            foreach (string handle in driver.WindowHandles)
            {
                driver.SwitchTo().Window(handle);
                if (driver1.Title.Equals(tabToCloseTitle))
                {
                    Console.WriteLine("Entered if block edge");
                    driver1.Close();
                    break;
                }
            }
            try
            {
                TestBase testBase = new TestBase();
                driver = testBase.getDriver();
                StudentDashboardPage studentDashboardPage = new StudentDashboardPage(driver);
                driver.SwitchTo().Window(driver.WindowHandles[2]);
                studentDashboardPage.ProceedButtonStudent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            QuickSleep();
        }

        public void Authentication()
        {
            MediumSleep();
            try
            {
                ClickElement(StartAuthenticationLink);
                ReportLog("Passed", "Clicked on start authentication link");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on start authentication link");
                throw ex;
            }
            QuickSleep();
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
            QuickSleep();
            try
            {
                ClickElement(StudentIdentificationVerification);
                ReportLog("Passed", "Clicked on student identity verification");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on student identity verification");
                throw ex;
            }
            QuickSleep();
            try
            {
                driver.SwitchTo().Alert().Accept();
                ReportLog("Passed", "Accepted pop-up alert for student identity verification");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't accept pop-up alert for student identity verification");
                throw ex;
            }
            QuickSleep();
            try
            {
                driver.SwitchTo().Alert().Accept();
                ReportLog("Passed", "Accepted pop-up alert for student identity verification");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't accept pop-up alert for student identity verification");
                throw ex;
            }
            MediumSleep();
            try
            {
                string securityAnswer = getDataParser().extractDataLoginCredentials("securityAnswer");
                string examiKEYname = getDataParser().extractDataLoginCredentials("examiKEYname");

                TestBase testBase = new TestBase();
                driver = testBase.getDriver();
                StudentDashboardPage studentDashboardPage = new StudentDashboardPage(driver);
                driver.SwitchTo().Window(driver.WindowHandles[2]);
                studentDashboardPage.ProvidingExamiDetails(securityAnswer,
                                                           examiKEYname);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            QuickSleep();
        }

        public void AuthenticationComments(string Flag,
                                           string AuthHours,
                                           string AuthMinutes,
                                           string AuthSeconds,
                                           string ProctorComment1,
                                           string ExamHours,
                                           string ExamMinutes,
                                           string ExamSeconds,
                                           string ProctorComment2,
                                           string AdditionalComments)
        {
            try
            {
                ClickElement(ProctorCommentsTab);
                ReportLog("Passed", "Clicked on proctor comments tab");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on proctor comments tab");
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
            MediumSleep();
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
                    if (hour.Text.Contains(AuthHours))
                    {
                        ClickElement(hour);
                        break;
                    }
                }
                ReportLog("Passed", "Selected " + AuthHours + " hours");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select hourly time");
                throw ex;
            }
            MediumSleep();
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
                    if (minute.Text.Contains(AuthMinutes))
                    {
                        ClickElement(minute);
                        break;
                    }
                }
                ReportLog("Passed", "Selected " + AuthMinutes + " minutes");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select minutely time");
                throw ex;
            }
            MediumSleep();
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
                    if (seconds.Text.Contains(AuthSeconds))
                    {
                        ClickElement(seconds);
                        break;
                    }
                }
                ReportLog("Passed", "Selected " + AuthSeconds + " seconds");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select seconds");
                throw ex;
            }
            MediumSleep();
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
                    if (description.Text.Contains(ProctorComment1))
                    {
                        ClickElement(description);
                        break;
                    }
                }
                ReportLog("Passed", "Selected description as " + ProctorComment1);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select description");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(AddButton);
                ReportLog("Passed", "Clicked on add button for proctor comments");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on add button for proctor comments");
                throw ex;
            }
            FasterSleep();
           /* if (ExamCompleteLink.Displayed)
            {
                try
                {
                    ClickElement(ExamCompleteLink);
                    ReportLog("Passed", "Clicked on exam complete link");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on exam complete link");
                    throw ex;
                }
                QuickSleep();
                try
                {
                    driver.SwitchTo().Alert().Accept();
                    ReportLog("Passed", "Accepted pop-up alert for 'exam completion' command");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't accept pop-up alert for 'exam completion' command");
                    throw ex;
                }
                MediumSleep();
                string tabToCloseUrl = "https://test.examity.com/ExamitySurvey/Survey.aspx?ClientID=R6l+BYhANQE=&ExamID=cznsw73QGO0MbjLOxVlsfQ==";
                foreach (string handle in driver.WindowHandles)
                {
                    driver.SwitchTo().Window(handle);
                    if (driver.Url.Equals(tabToCloseUrl))
                    {
                        driver.Close();
                        break;
                    }
                }
            }
            MediumSleep();*/
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
            MediumSleep();
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
            MediumSleep();
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
            MediumSleep();
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
            MediumSleep();
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
                EnterValues(ProctorCommentsAdditional, AdditionalComments);
                ReportLog("Passed", "Entered additional proctor comments as " + AdditionalComments);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter additional proctor comments");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(AddButton);
                ReportLog("Passed", "Clicked on add button for proctor comments");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on add button for proctor comments");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ExamApprovalButton);
                ReportLog("Passed", "Clicked on approve button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on approve button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ProctoringSubmitButton);
                ReportLog("Passed", "Clicked on submit button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on submit button");
                throw ex;
            }
            MediumSleep();
            try
            {
                driver.SwitchTo().Alert().Accept();
                ReportLog("Passed", "Accepted pop-up alert for 'submit' command");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't accept pop-up alert for 'submit' command");
                throw ex;
            }
            QuickSleep();
            try
            {
                TestBase testBase = new TestBase();
                driver = testBase.getDriver();
                StudentDashboardPage studentDashboardPage = new StudentDashboardPage(driver);
                driver.SwitchTo().Window(driver.WindowHandles[0]);
                studentDashboardPage.Survey();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            QuickSleep();
        }
    }
}
