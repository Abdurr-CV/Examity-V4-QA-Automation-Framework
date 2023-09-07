using AdminDashboard.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace AdminDashboard.PageObjects
{
    class WFMPortalPage : BasePage
    {
        public WFMPortalPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public IWebDriver driver;

        // LOGIN IN AS WFM
        [FindsBy(How = How.Id, Using = "txtUserName")]
        private IWebElement WFMUsername1;
        [FindsBy(How = How.Id, Using = "txtPassword")]
        private IWebElement WFMPassword1;
        [FindsBy(How = How.Id, Using = "btnSignIn")]
        private IWebElement LoginSignInButton;

        // WFM DASHBOARD TAB
        [FindsBy(How = How.XPath, Using = "//a[text()='Series']")]
        private IWebElement SeriesColumn;
        [FindsBy(How = How.XPath, Using = "//a[text()='Client']")]
        private IWebElement ClientColumn;
        [FindsBy(How = How.XPath, Using = "//a[text()='Client Category']")]
        private IWebElement ClientCategoryColumn;
        [FindsBy(How = How.XPath, Using = "//a[text()='Platform']")]
        private IWebElement PlatformColumn;
        [FindsBy(How = How.XPath, Using = "//a[text()='Platform']")]
        private IWebElement PPMExamColumn;
        [FindsBy(How = How.XPath, Using = "//a[text()='Language']")]
        private IWebElement LanguageColumn;
        [FindsBy(How = How.XPath, Using = "//a[text()='Test-taker Name']")]
        private IWebElement TestTakerColumn;
        [FindsBy(How = How.XPath, Using = "//a[text()='Exam Duration']")]
        private IWebElement ExamDurationColumn;
        [FindsBy(How = How.XPath, Using = "//a[text()='Proctoring Level']")]
        private IWebElement ProctoringLevelColumn;
        [FindsBy(How = How.XPath, Using = "//a[text()='Test-taker Arrival Time(EST)']")]
        private IWebElement ArrivalTimeESTColumn;
        [FindsBy(How = How.XPath, Using = "//a[text()='Test-taker Arrival Time(IST)']")]
        private IWebElement ArrivalTimeISTColumn;
        [FindsBy(How = How.XPath, Using = "//a[text()='Proctor']")]
        private IWebElement ProctorColumn;
        [FindsBy(How = How.XPath, Using = "//a[text()='Appointment ID']")]
        private IWebElement AppointmentIDColumn;
        [FindsBy(How = How.XPath, Using = "//a[text()='BrowserName']")]
        private IWebElement BrowserNameColumn;
        [FindsBy(How = How.XPath, Using = "//label[@for='ctl00_ContentPlaceHolder1_ctl00_ddlClients_Input']")]
        private IWebElement SelectClientDropdown;
        [FindsBy(How = How.XPath, Using = "//label[@for='ctl00_ContentPlaceHolder1_ctl00_rcbSeries_Input']")]
        private IWebElement SelectSeriesDropdown;

        // HOURLY EXAM BY CATEGORY TAB
        [FindsBy(How = How.XPath, Using = "//label[text()='Platform']")]
        private IWebElement AssertPlatform;
        [FindsBy(How = How.XPath, Using = "//label[text()='Select Client']")]
        private IWebElement AssertSelectClient;
        [FindsBy(How = How.XPath, Using = "//label[text()='Proctoring Level']")]
        private IWebElement AssertProctoringLevel;
        [FindsBy(How = How.XPath, Using = "//label[text()='Time Slot']")]
        private IWebElement AssertTimeSlot;
        [FindsBy(How = How.XPath, Using = "//label[text()='From']")]
        private IWebElement AssertFromDate;
        [FindsBy(How = How.XPath, Using = "//label[text()='To']")]
        private IWebElement AssertToDate;
        [FindsBy(How = How.Id, Using = "//td[@title='Friday, February 01, 2019']")]
        private IWebElement FromDateSelection;
        [FindsBy(How = How.XPath, Using = "ctl00_ContentPlaceHolder1_txtFromDate_popupButton")]
        private IWebElement FromDatePopUpButton;
        [FindsBy(How = How.XPath, Using = "ctl00_ContentPlaceHolder1_btnSearch")]
        private IWebElement SearchHourlyExamButton;

        // ASSIGN PROCTOR
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_linkParentPage")]
        private IWebElement AssignProctorTab;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_txtExamId")]
        private IWebElement AppointmentIDAssignProctor;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnSearch")]
        private IWebElement SearchButtonAppointmentID;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_gvExamsList_ctl00_ctl04_chkselect")]
        private IWebElement SelectExam;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddlLanguages_Arrow")]
        private IWebElement SelectLanguageDropdown;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddlCategory_Arrow")]
        private IWebElement SelectCategoryDropdown;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddlProctors_Arrow")]
        private IWebElement SelectProctorDropdown;
        [FindsBy(How = How.XPath, Using = "//li[text()='English']")]
        private IWebElement SelectEnglish;
        [FindsBy(How = How.XPath, Using = "//li[text()='3']")]
        private IWebElement SelectCategory;
        [FindsBy(How = How.XPath, Using = "//li[text()='Admin - Proctor 2 lang']")]
        private IWebElement SelectProctor;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_addbtn")]
        private IWebElement AssignButton;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lblwaiting")]
        private IWebElement WaitingForProctorText;

        public void LoginAsWFM(string WFMUsername,
                                string WFMPassword)
        {
            try
            {
                EnterValues(WFMUsername1, WFMUsername);
                ReportLog("Passed", "Entered the WFM-username as " + WFMUsername);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the WFM-username");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(WFMPassword1, WFMPassword);
                ReportLog("Passed", "Entered WFM-password as " + WFMPassword);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter WFM-password");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(LoginSignInButton);
                ReportLog("Passed", "Clicked on the Login button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the Login button");
                throw ex;
            }
            QuickSleep();
        }

        public void AssignProctor()
        {
            try
            {
                ClickElement(AssignProctorTab);
                ReportLog("Passed", "Clicked on the assign proctor tab");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the assign proctor tab");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(AppointmentIDAssignProctor, StudentDashboardPage.AppoinmentID);
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
                ClickElement(SearchButtonAppointmentID);
                ReportLog("Passed", "Clicked on the search button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the search button");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(SelectExam);
                ReportLog("Passed", "Clicked on the exam checkbox");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the exam checkbox");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SelectLanguageDropdown);
                ReportLog("Passed", "Clicked on the language selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the language selection dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SelectEnglish);
                ReportLog("Passed", "Selected English language");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select English language");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SelectCategoryDropdown);
                ReportLog("Passed", "Clicked on the category selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the category selection dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SelectCategory);
                ReportLog("Passed", "Selected category 3");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select category 3");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SelectProctorDropdown);
                ReportLog("Passed", "Clicked on the proctor selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the proctor selection dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SelectProctor);
                ReportLog("Passed", "Selected Admin proctor 2 language");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select Admin proctor 2 language");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(AssignButton);
                ReportLog("Passed", "Clicked on the Assign button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the Assign button");
                throw ex;
            }
            QuickSleep();
        }

        public void FlowOfStudentAndProctor()

        {
            try
            {
                TestBase testBase = new TestBase();
                driver = testBase.getDriver();
                StudentDashboardPage studentDashboardPage = new StudentDashboardPage(driver);
                driver.SwitchTo().Window(driver.WindowHandles[2]);
                studentDashboardPage.ProctorStudentFlow();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            QuickSleep();
        }
    }
}
