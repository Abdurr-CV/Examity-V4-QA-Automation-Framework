using AdminDashboard.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace AdminDashboard.PageObjects
{
    class OperationsDashboardPage : BasePage
    {
        public OperationsDashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public IWebDriver driver;

        // LGOGIN PAGE
        [FindsBy(How = How.Id, Using = "UserName")]
        private IWebElement OperationsLoginUsername;
        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement OperationsLoginPassword;
        [FindsBy(How = How.Id, Using = "btnLogin")]
        private IWebElement OperationsLoginButton;

        // DASHBOARD PAGE
        [FindsBy(How = How.XPath, Using = "//div[@class='container-fluid']/div/div/div/a/div/h4")]
        private IList<IWebElement> DashboardPageValidation;
        [FindsBy(How = How.XPath, Using = "//h4[text()='Dashboard']")]
        private IWebElement DashboardIcon;
        [FindsBy(How = How.XPath, Using = "//h4[text()='Client Grouping']")]
        private IWebElement ClientGroupingIcon;
        [FindsBy(How = How.XPath, Using = "//h4[text()='Proctor Mapping']")]
        private IWebElement ProctorMappingIcon;
        [FindsBy(How = How.XPath, Using = "//h4[text()='Proctor Availability']")]
        private IWebElement ProctorAvailabilityIcon;
        [FindsBy(How = How.XPath, Using = "//h4[text()='Exam Queue']")]
        private IWebElement ExamQueueIcon;
        [FindsBy(How = How.XPath, Using = "//h4[text()='Assign Proctor']")]
        private IWebElement AssignProctorIcon;
        [FindsBy(How = How.XPath, Using = "//h4[text()='Unassigned Exams']")]
        private IWebElement UnassignedExamsIcon;
        [FindsBy(How = How.XPath, Using = "//h4[text()='Reports']")]
        private IWebElement ReportsIcon;
        [FindsBy(How = How.Id, Using = "lnkHome")]
        private IWebElement DashboardTab;

        // CLIENT GROUPING
        [FindsBy(How = How.XPath, Using = "//div[@class='fs1-dropdown']/div/div/div[@class='fs1-option-label']")]
        private IList<IWebElement> UnassignedClientsList;
        [FindsBy(How = How.XPath, Using = "//button[text()='Ok']")]
        private IWebElement ClientAssigningConfirmation;
        [FindsBy(How = How.Id, Using = "ddlCategorie")]
        private IWebElement CategoryDropdown;
        [FindsBy(How = How.XPath, Using = "//select[@id='ddlCategorie']/option")]
        private IList<IWebElement> CategoryList;
        [FindsBy(How = How.Id, Using = "btnAssign")]
        private IWebElement AssignButton;

        // CLIENT CATEGORYASSIGNING FROM SEARCH
        [FindsBy(How = How.ClassName, Using = "fs1-search")]
        private IWebElement UnassignedClientSearch;
        [FindsBy(How = How.XPath, Using = "//div/div/div[@class='fs1-options']//div[text()='QuestionMark - ATSQA']")]
        private IWebElement ClientSelectionFromSearch;

        // SEARCH BY CLIENT NAME
        [FindsBy(How = How.ClassName, Using = "fs-arrow")]
        private IWebElement ClientSearchDropdown;
        [FindsBy(How = How.ClassName, Using = "fs-search")]
        private IWebElement ClientSearchBar;
        [FindsBy(How = How.XPath, Using = "//div[@class='fs-dropdown']/div//div[text()='QuestionMark - ATSQA']")]
        private IWebElement SearchedClientName;
        [FindsBy(How = How.XPath, Using = "//button[text()='Search']")]
        private IWebElement SearchButton;
        [FindsBy(How = How.ClassName, Using = "option-input")]
        private IWebElement SearchedClientCheckbox;
        [FindsBy(How = How.XPath, Using = "//button[text()='Remove']")]
        private IWebElement RemoveButton;
        [FindsBy(How = How.XPath, Using = "//button[text()='Yes']")]
        private IWebElement RemoveConfirmation;
        [FindsBy(How = How.XPath, Using = "//button[text()='Ok']")]
        private IWebElement OkayButton;
        
        // SEARCH BY ASSIGNED GROUP
        [FindsBy(How = How.Id, Using = "ddlCategorie1")]
        private IWebElement CategorySearchDropdown;
        [FindsBy(How = How.Id, Using = "select_all")]
        private IWebElement SelectAllCheckBoxes;
        [FindsBy(How = How.XPath, Using = "//select[@id='ddlCategorie1']/option")]
        private IList<IWebElement> Category1List;

        // PROCTOR MAPPING (CATEGORY TAB)
        [FindsBy(How = How.XPath, Using = "//ul/li/a[text()='Category']")]
        private IWebElement CategoryTab;
        [FindsBy(How = How.XPath, Using = "//tr/th/a[text()='Category']")]
        private IWebElement CategoryColumnAssert;
        [FindsBy(How = How.XPath, Using = "//tr/th/a[text()='Category Clients']")]
        private IWebElement CategoryClientsColumnAssert;
        [FindsBy(How = How.XPath, Using = "//tr/th/a[text()='Category Proctors']")]
        private IWebElement CategoryProctorsColumnAssert;

        // PROCTOR MAPPING (PROCTORS TAB)
        [FindsBy(How = How.XPath, Using = "//p[text()='Proctor Mapping']")]
        private IWebElement ProctorMappingIcon1;
        [FindsBy(How = How.Id, Using = "imgUDExportToExcel")]
        private IWebElement ExportDocument;
        [FindsBy(How = How.XPath, Using = "//ul/li/a[text()='Proctors']")]
        private IWebElement ProctorsTab;
        [FindsBy(How = How.Id, Using = "EmployeeId")]
        private IWebElement EmployeeID;
        [FindsBy(How = How.Id, Using = "FirstName")]
        private IWebElement ProcFirstname;
        [FindsBy(How = How.Id, Using = "LastName")]
        private IWebElement ProcLastname;
        [FindsBy(How = How.Id, Using = "btnUDSearch")]
        private IWebElement SaerchButtonProctor;
        [FindsBy(How = How.XPath, Using = "//td/a/i[@title='Skill Mapping']")]
        private IWebElement ActionButton;
        
        // PROCTOR PROFILE
        [FindsBy(How = How.Id, Using = "proctorprofile")]
        private IWebElement ProctorProfileIcon;
        [FindsBy(How = How.Id, Using = "btnEditProfile")]
        private IWebElement ProctorProfileEditButton;
        [FindsBy(How = How.Id, Using = "ddlRateofSpeech")]
        private IWebElement RateOfSpeechDropdown;
        [FindsBy(How = How.XPath, Using = "//select[@id='ddlRateofSpeech']/option")]
        private IList<IWebElement> RateOfSpeechLevels;
        [FindsBy(How = How.Id, Using = "ddlAttentiveness")]
        private IWebElement AttentivenessDropdown;
        [FindsBy(How = How.XPath, Using = "//select[@id='ddlAttentiveness']/option")]
        private IList<IWebElement> AttentivenessLevels;
        [FindsBy(How = How.Id, Using = "ddlTechnicalKnowledge")]
        private IWebElement TechnicalKnowledgeDropdown;
        [FindsBy(How = How.XPath, Using = "//select[@id='ddlTechnicalKnowledge']/option")]
        private IList<IWebElement> TechnicalKnowledgeLevels;
        [FindsBy(How = How.Id, Using = "ddlQuality")]
        private IWebElement QualityDropdown;
        [FindsBy(How = How.XPath, Using = "//select[@id='ddlQuality']/option")]
        private IList<IWebElement> QualityLevels;
        [FindsBy(How = How.Id, Using = "ddlFlexibility")]
        private IWebElement FlexibilityDropdown;
        [FindsBy(How = How.XPath, Using = "//select[@id='ddlFlexibility']/option")]
        private IList<IWebElement> FlexibilityLevels;
        [FindsBy(How = How.Id, Using = "btnSaveProctor")]
        private IWebElement ProctorProfileSaveButton;

        // PLATFORM
        [FindsBy(How = How.XPath, Using = "//a[text()='Platform']")]
        private IWebElement PlatformIcon;
        [FindsBy(How = How.XPath, Using = "//div[text()='---Select Platform---']")]
        private IWebElement PlatformSelectionDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@class='fs-option-label']")]
        private IList<IWebElement> PlatformChoices;
        [FindsBy(How = How.ClassName, Using = "form-group")]
        private IWebElement Click1;
        [FindsBy(How = How.Id, Using = "btnSavePlatform")]
        private IWebElement AssignPlatformButton;
        [FindsBy(How = How.XPath, Using = "//button[text()='Ok']")]
        private IWebElement PlatformAssigningConfirmation;
        [FindsBy(How = How.XPath, Using = "//input[@id='2']")]
        private IWebElement PlatformCheckbox;
        [FindsBy(How = How.Id, Using = "btnDeletePlatform")]
        private IWebElement PlatformRemoveButton;
        [FindsBy(How = How.XPath, Using = "//button[text()='Yes']")]
        private IWebElement ConfirmRemove;

        // CATEGORY
        [FindsBy(How = How.XPath, Using = "//a[text()='Category']")]
        private IWebElement CategoryIcon;
        [FindsBy(How = How.XPath, Using = "//div[text()='---Select Category---']")]
        private IWebElement CategorySelectionDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@class='fs-dropdown']/div/div")]
        private IList<IWebElement> CategorySelectionList;
        [FindsBy(How = How.ClassName, Using = "form-group")]
        private IWebElement Click5;
        [FindsBy(How = How.Id, Using = "btnSaveCategory")]
        private IWebElement AssignCategory;
        [FindsBy(How = How.XPath, Using = "//button[text()='Ok']")]
        private IWebElement ConfrimCategory;
        [FindsBy(How = How.Id, Using = "2")]
        private IWebElement AssignedCategoryList;
        [FindsBy(How = How.Id, Using = "btnDeleteCategory")]
        private IWebElement RemoveCategory;
        [FindsBy(How = How.XPath, Using = "//button[text()='Yes']")]
        private IWebElement ConfirmCategoryRemove;
        [FindsBy(How = How.XPath, Using = "//button[text()='Ok']")]
        private IWebElement CategoryRemovalConfirmation;

        // EXCEPTIONS BY CATEGORY
        [FindsBy(How = How.XPath, Using = "//a[text()='Exceptions By Category']")]
        private IWebElement ExceptionsByCategoryIcon;
        [FindsBy(How = How.XPath, Using = "//input[@value='136$1']")]
        private IWebElement ClientExceptionCheckbox;
        [FindsBy(How = How.Id, Using = "btnDeleteException")]
        private IWebElement RemoveClientException;
        [FindsBy(How = How.XPath, Using = "//button[text()='Yes']")]
        private IWebElement ConfirmClientExceptionRemove;
        [FindsBy(How = How.XPath, Using = "//button[text()='Ok']")]
        private IWebElement ClientExceptionRemovalConfirmation;
        [FindsBy(How = How.Id, Using = "ddlClientCategory")]
        private IWebElement ClientCategoryDropdown;
        [FindsBy(How = How.XPath, Using = "//select[@id='ddlClientCategory']/option")]
        private IList<IWebElement> ClientCategoryList;
        [FindsBy(How = How.ClassName, Using = "fs-label")]
        private IWebElement ClientDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@class='fs-dropdown']/div/div")]
        private IList<IWebElement> ClientList;
        [FindsBy(How = How.ClassName, Using = "form-group")]
        private IWebElement Click2;
        [FindsBy(How = How.Id, Using = "btnSaveException")]
        private IWebElement AddClientExceptionButton;
        [FindsBy(How = How.XPath, Using = "//button[text()='Ok']")]
        private IWebElement ConfirmClientEXceptionAddition;

        // LANGUAGE
        [FindsBy(How = How.XPath, Using = "//a[text()='Language']")]
        private IWebElement LanguageIcon;
        [FindsBy(How = How.Id, Using = "2")]
        private IWebElement GermanLanguage;
        [FindsBy(How = How.Id, Using = "btnDeleteLanguage")]
        private IWebElement RemoveLanguageButton;
        [FindsBy(How = How.XPath, Using = "//button[text()='Yes']")]
        private IWebElement ConfirmLanguageRemove;
        [FindsBy(How = How.XPath, Using = "//button[text()='Ok']")]
        private IWebElement LanguageRemovalConfirmation;
        [FindsBy(How = How.ClassName, Using = "fs-label")]
        private IWebElement LanguageDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@class='fs-option-label']")]
        private IList<IWebElement> LanguageList;
        [FindsBy(How = How.ClassName, Using = "form-group")]
        private IWebElement Click3;
        [FindsBy(How = How.Id, Using = "btnSaveLanguage")]
        private IWebElement AssignLanguageButton;
        [FindsBy(How = How.XPath, Using = "//button[text()='Ok']")]
        private IWebElement LanguageAdditionConfirmation;

        // ACCOMODATIONS READY
        [FindsBy(How = How.XPath, Using = "//a[text()='Accommodations Ready?']")]
        private IWebElement AccomodationReadyIcon;
        [FindsBy(How = How.Id, Using = "1")]
        private IWebElement AccomodationCheckbox;
        [FindsBy(How = How.Id, Using = "btnDeleteAccomodation")]
        private IWebElement DeleteAccomodation;
        [FindsBy(How = How.XPath, Using = "//button[text()='Yes']")]
        private IWebElement ConfirmAccomodationRemove;
        [FindsBy(How = How.XPath, Using = "//button[text()='Ok']")]
        private IWebElement AccomodationRemovalConfirmation;
        [FindsBy(How = How.ClassName, Using = "fs-label")]
        private IWebElement AccomodationDropdown;
        [FindsBy(How = How.XPath, Using = "//div[text()='Yes']")]
        private IWebElement YesOption;
        [FindsBy(How = How.Id, Using = "btnAccomodation")]
        private IWebElement AssignAccomodation;
        [FindsBy(How = How.XPath, Using = "//button[text()='Ok']")]
        private IWebElement AccomodationConfirmation;

        // INDUSTRY
        [FindsBy(How = How.XPath, Using = "//a[text()='Industry']")]
        private IWebElement IndustryIcon;
        [FindsBy(How = How.Id, Using = "3")]
        private IWebElement IndustryCheckbox;
        [FindsBy(How = How.Id, Using = "btnDeleteIndustry")]
        private IWebElement RemoveIndustry;
        [FindsBy(How = How.XPath, Using = "//button[text()='Yes']")]
        private IWebElement ConfirmIndustryRemove;
        [FindsBy(How = How.XPath, Using = "//button[text()='Ok']")]
        private IWebElement IndustryRemovalConfirmation;
        [FindsBy(How = How.ClassName, Using = "fs-label")]
        private IWebElement IndustryDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@class='fs-dropdown']/div/div")]
        private IList<IWebElement> IndustryList;
        [FindsBy(How = How.ClassName, Using = "form-group")]
        private IWebElement Click4;
        [FindsBy(How = How.Id, Using = "btnSaveIndustry")]
        private IWebElement AssignIndustry;
        [FindsBy(How = How.XPath, Using = "//button[text()='Ok']")]
        private IWebElement IndustryConfirmation;

        // PROCTOR AVAILABILITY
        [FindsBy(How = How.XPath, Using = "//div[text()='Scheduled']")]
        private IWebElement AssertScheduledStatus;
        [FindsBy(How = How.XPath, Using = "//div[text()='Waiting For Proctor']")]
        private IWebElement AssertWaitingForProctorStatus;
        [FindsBy(How = How.XPath, Using = "//div[text()='Verification In Progress']")]
        private IWebElement AssertVerificationInProgresStatus;
        [FindsBy(How = How.XPath, Using = "//div[text()='In Progress']")]
        private IWebElement AsssertInProgressStatus;
        [FindsBy(How = How.XPath, Using = "//div[text()='Actual Logout']")]
        private IWebElement AssertActualLogoutStatus;
        [FindsBy(How = How.XPath, Using = "//p[text()='Proctor Availability']")]
        private IWebElement ProctorAvailabilityTab;

        // PROCTOR-OPERATOR FLOW
        [FindsBy(How = How.XPath, Using = "//span[@title='Scheduled Logout']")]
        private IWebElement ShiftLoginAssert;
        [FindsBy(How = How.XPath, Using = "//img[@src='/operations/Content/images/imgInactiveTag.png']")]
        private IWebElement BreakIcon;
        [FindsBy(How = How.XPath, Using = "//img[@src='/operations/Content/images/tick.png']")]
        private IWebElement AvailableIcon;
        [FindsBy(How = How.XPath, Using = "//span[@title='Actual Logout']")]
        private IWebElement ToTime;
        [FindsBy(How = How.XPath, Using = "//div[@id='background']")]
        private IWebElement HighlightedToTimeTable;
        [FindsBy(How = How.XPath, Using = "//img[@title='Do Not Disturb']")]
        private IWebElement BreakTimeStart;
        [FindsBy(How = How.XPath, Using = "//img[@title='Available']")]
        private IWebElement BreakTimeOver;
        [FindsBy(How = How.XPath, Using = "//img[@title='Yes']")]
        private IWebElement ActiveRequestStatus;

        // REPORTS PAGE
        [FindsBy(How = How.XPath, Using = "//i[@class='pe-7s-news-paper']")]
        private IWebElement ReportsTab;

        // REPORTS - ROSTER PAGE
        [FindsBy(How = How.Id, Using = "EmployeeId")]
        private IWebElement ReportsEmployeeID;
        [FindsBy(How = How.Id, Using = "FirstName")]
        private IWebElement ReportsProctorFName;
        [FindsBy(How = How.Id, Using = "LastName")]
        private IWebElement ReportsProctorLName;
        [FindsBy(How = How.Id, Using = "txtERFromDate")]
        private IWebElement rosterFromDate;
        [FindsBy(How = How.Id, Using = "txtERToDate")]
        private IWebElement rosterToDate;
        [FindsBy(How = How.Id, Using = "btnSearchLogin")]
        private IWebElement RosterSearchButton;
        [FindsBy(How = How.Id, Using = "imgExportToExcel")]
        private IWebElement RosterResultsExportButton;

        // REPORTS - CHECK-IN/ CHECK OUT PAGE
        [FindsBy(How = How.XPath, Using = "//a[text()='Check-in/Check-out']")]
        private IWebElement CheckINCheckOutPage;
        [FindsBy(How = How.Id, Using = "EmployeeId")]
        private IWebElement CheckEmployeeID;
        [FindsBy(How = How.Id, Using = "FirstName")]
        private IWebElement CheckProctorFName;
        [FindsBy(How = How.Id, Using = "LastName")]
        private IWebElement CheckProctorLName;
        [FindsBy(How = How.Id, Using = "txtFromDate")]
        private IWebElement CheckFromDate;
        [FindsBy(How = How.Id, Using = "txtToDate")]
        private IWebElement CheckToDate;
        [FindsBy(How = How.Id, Using = "btnSearchCheckin")]
        private IWebElement CheckSearchButton;
        [FindsBy(How = How.Id, Using = "imgCheckinExportToExcel")]
        private IWebElement CheckResultsExportButton;

        // REPORTS - BREAK TIME PAGE
        [FindsBy(How = How.XPath, Using = "//a[text()='Breaktime']")]
        private IWebElement ReportsBreakTimeIcon;
        [FindsBy(How = How.Id, Using = "ProctorName")]
        private IWebElement BreakTimeProctorName;
        [FindsBy(How = How.Id, Using = "TeamLead")]
        private IWebElement BreakTimeTeamLead;
        [FindsBy(How = How.Id, Using = "txtFromDate")]
        private IWebElement BreakTimeFromDate;
        [FindsBy(How = How.Id, Using = "txtToDate")]
        private IWebElement BreakTimeToDate;
        [FindsBy(How = How.Id, Using = "btnBreakTimeSearch")]
        private IWebElement BreakTimeSearchButton;
        [FindsBy(How = How.Id, Using = "imgBreakTimeExportToExcel")]
        private IWebElement BreakTimeResultsExportButton;

        // REPORTS - EXAM REQUEST PAGE
        [FindsBy(How = How.XPath, Using = "//a[text()='Exam Request']")]
        private IWebElement ReportsExamRequestIcon;
        [FindsBy(How = How.Id, Using = "ProctorName")]
        private IWebElement ExamRequestProctorName;
        [FindsBy(How = How.Id, Using = "TeamLead")]
        private IWebElement ExamRequestTeamLead;
        [FindsBy(How = How.Id, Using = "txtFromDate")]
        private IWebElement ExamRequestFromDate;
        [FindsBy(How = How.Id, Using = "txtToDate")]
        private IWebElement ExamRequestToDate;
        [FindsBy(How = How.Id, Using = "btnExamRequestSearch")]
        private IWebElement ExamRequestSearchButton;
        [FindsBy(How = How.Id, Using = "imgExamRequestExportToExcel")]
        private IWebElement ExamRequestResultsExportButton;

        // REPORTS - VM PAGE
        [FindsBy(How = How.XPath, Using = "//a[text()='VM']")]
        private IWebElement ReportsVMIcon;
        [FindsBy(How = How.Id, Using = "VMUserName")]
        private IWebElement VMUsername;
        [FindsBy(How = How.Id, Using = "FirstName")]
        private IWebElement VMProctorFName;
        [FindsBy(How = How.Id, Using = "LastName")]
        private IWebElement VMProctorLName;
        [FindsBy(How = How.Id, Using = "txtFromDate")]
        private IWebElement VMFromDate;
        [FindsBy(How = How.Id, Using = "txtToDate")]
        private IWebElement VMToDate;
        [FindsBy(How = How.Id, Using = "btnSearchVM")]
        private IWebElement VMSearchButton;
        [FindsBy(How = How.Id, Using = "imgVMExportToExcel")]
        private IWebElement VMResultsExportButton;

        // REPORTS - EXAM ASSIGNMENT
        [FindsBy(How = How.XPath, Using = "//a[text()='Exam Assignment']")]
        private IWebElement ReportsExamAssignmentIcon;
        [FindsBy(How = How.Id, Using = "ProctorName")]
        private IWebElement ExamAssignmentProctorName;
        [FindsBy(How = How.Id, Using = "ExamID")]
        private IWebElement ExamAssignmentExamID;
        [FindsBy(How = How.Id, Using = "txtFromDate")]
        private IWebElement ExamAssignmentFromDate;
        [FindsBy(How = How.Id, Using = "txtToDate")]
        private IWebElement ExamAssignmentToDate;
        [FindsBy(How = How.Id, Using = "btnExamAssignmentSearch")]
        private IWebElement ExamAssignmentSearchButton;
        [FindsBy(How = How.Id, Using = "imgExamAssignmentExportToExcel")]
        private IWebElement ExamAssignmentExaportButton;

        // REPORTS - EOD
        [FindsBy(How = How.Id, Using = "ExamID")]
        private IWebElement EODExamID;
        [FindsBy(How = How.Id, Using = "ProctorName")]
        private IWebElement EODProctorName;
        [FindsBy(How = How.Id, Using = "TeamLead")]
        private IWebElement EODTeamLead;
        [FindsBy(How = How.Id, Using = "txtFromDate")]
        private IWebElement EODFromDate;
        [FindsBy(How = How.Id, Using = "txtToDate")]
        private IWebElement EODToDate;
        [FindsBy(How = How.Id, Using = "btnEODSearch")]
        private IWebElement EODSearchButton;
        [FindsBy(How = How.Id, Using = "imgEODExportToExcel")]
        private IWebElement EODResultExportButton;

        /*[FindsBy(How = How.Id, Using = "")]
        private IWebElement ;
        [FindsBy(How = How.Id, Using = "")]
        private IWebElement ;
        [FindsBy(How = How.Id, Using = "")]
        private IWebElement ;
        [FindsBy(How = How.Id, Using = "")]
        private IWebElement ;
        [FindsBy(How = How.Id, Using = "")]
        private IWebElement ;
        [FindsBy(How = How.Id, Using = "")]
        private IWebElement ;
        [FindsBy(How = How.Id, Using = "")]
        private IWebElement ;
        [FindsBy(How = How.Id, Using = "")]
        private IWebElement ;
        [FindsBy(How = How.Id, Using = "")]
        private IWebElement ;*/

        public void OperationsLogin(string OperatorUsername,
                                    string OperatorPassword)
        {
            try
            {
                EnterValues(OperationsLoginUsername, OperatorUsername);
                ReportLog("Passed", "Entered operator username as " + OperatorUsername);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter operator username");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(OperationsLoginPassword, OperatorPassword);
                ReportLog("Passed", "Entered operator password as " + OperatorPassword);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter operator password");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(OperationsLoginButton);
                ReportLog("Passed", "Clicked on operator login button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on operator login button");
                throw ex;
            }
            QuickSleep();
        }

        public void DashboardPage()
        {
            try
            {
                Assert.True(DashboardIcon.Displayed);
                ReportLog("Passed", "Asserted Dashboard component visibility");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert Dashboard component visibility");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(ClientGroupingIcon.Displayed);
                ReportLog("Passed", "Asserted Client Grouping component visibility");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert Client Grouping component visibility");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ClientGroupingIcon);
                ReportLog("Passed", "Clicked on Client grouping icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Client grouping icon");
                throw ex;
            }
            QuickSleep();
            ScreenCapture(driver, "Client grouping page");
            QuickSleep();
            try
            {
                ClickElement(DashboardTab);
                ReportLog("Passed", "Clicked on Dashboard tab to navigate to home page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Dashboard tab to navigate to home page");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(ProctorMappingIcon.Displayed);
                ReportLog("Passed", "Asserted Proctor Mapping component visibility");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert Proctor Mapping component visibility");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ProctorMappingIcon);
                ReportLog("Passed", "Clicked on Proctor mapping icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Proctor mapping icon");
                throw ex;
            }
            QuickSleep();
            ScreenCapture(driver, "Proctor mapping page");
            QuickSleep();
            try
            {
                ClickElement(DashboardTab);
                ReportLog("Passed", "Clicked on Dashboard tab to navigate to home page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Dashboard tab to navigate to home page");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(ProctorAvailabilityIcon.Displayed);
                ReportLog("Passed", "Asserted Proctor Availability component visibility");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert Proctor Availability component visibility");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ProctorAvailabilityIcon);
                ReportLog("Passed", "Clicked on Proctor availability icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Proctor availability icon");
                throw ex;
            }
            QuickSleep();
            ScreenCapture(driver, "Proctor availability page");
            QuickSleep();
            try
            {
                ClickElement(DashboardTab);
                ReportLog("Passed", "Clicked on Dashboard tab to navigate to home page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Dashboard tab to navigate to home page");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(ExamQueueIcon.Displayed);
                ReportLog("Passed", "Asserted Exam queue component visibility");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert Exam queue component visibility");
                throw ex;
            }
            QuickSleep();
           /* try
            {
                ClickElement(ExamQueueIcon);
                ReportLog("Passed", "Clicked on Exam queue icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Exam queue icon");
                throw ex;
            }
            QuickSleep();*/
            try
            {
                ClickElement(DashboardTab);
                ReportLog("Passed", "Clicked on Dashboard tab to navigate to home page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Dashboard tab to navigate to home page");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(AssignProctorIcon.Displayed);
                ReportLog("Passed", "Asserted Assign proctor component visibility");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert Assign proctor component visibility");
                throw ex;
            }
            QuickSleep();
           /* try
            {
                ClickElement(AssignProctorIcon);
                ReportLog("Passed", "Clicked on Assign proctor icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Assign proctor icon");
                throw ex;
            }
            QuickSleep();*/
            try
            {
                ClickElement(DashboardTab);
                ReportLog("Passed", "Clicked on Dashboard tab to navigate to home page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Dashboard tab to navigate to home page");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(UnassignedExamsIcon.Displayed);
                ReportLog("Passed", "Asserted Unassigned exams component visibility");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert Unassigned exams component visibility");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(UnassignedExamsIcon);
                ReportLog("Passed", "Clicked on Unaasigned exams icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Unaasigned exams icon");
                throw ex;
            }
            QuickSleep();
            ScreenCapture(driver, "Unaasigned exams page");
            QuickSleep();
            try
            {
                ClickElement(DashboardTab);
                ReportLog("Passed", "Clicked on Dashboard tab to navigate to home page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Dashboard tab to navigate to home page");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(ReportsIcon.Displayed);
                ReportLog("Passed", "Asserted Reports component visibility");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert Reports component visibility");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ReportsIcon);
                ReportLog("Passed", "Clicked on Reports icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Reports icon");
                throw ex;
            }
            QuickSleep();
            ScreenCapture(driver, "Reports page");
            QuickSleep();
            try
            {
                ClickElement(DashboardTab);
                ReportLog("Passed", "Clicked on Dashboard tab to navigate to home page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Dashboard tab to navigate to home page");
                throw ex;
            }
            QuickSleep();
        }

        public void ClientGroupingPageRandomSelection(int UnassignedRandomClients,
                                                      string ClientCategory)
        {
            try
            {
                ClickElement(ClientGroupingIcon);
                ReportLog("Passed", "Clicked on Client grouping icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Client grouping icon");
                throw ex;
            }
            QuickSleep();
            for (int i = 0; i < UnassignedRandomClients; i++)
            {
                Random r = new Random();
                int rInt = r.Next(1, UnassignedClientsList.Count);
                try
                {
                    UnassignedClientsList[rInt].Click();
                    ReportLog("Passed", "Selected " + rInt + " unassigned clients");

                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't select unassigned clients");
                    throw ex;
                }
            }
            QuickSleep();
            try
            {
                ClickElement(CategoryDropdown);
                ReportLog("Passed", "Clicked on the category dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the category dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                foreach (IWebElement Category in CategoryList)
                {
                    if (Category.Text.Contains(ClientCategory))
                    {
                        ClickElement(Category);
                        break;
                    }
                }
                ReportLog("Passed", "Selected " + ClientCategory + " category");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select a category");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(AssignButton);
                ReportLog("Passed", "Clicked on assign button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on assign button");
                throw ex;
            }
            HardSleep();
            try
            {
                ClickElement(ClientAssigningConfirmation);
                ReportLog("Passed", "Clicked on assign confirmation button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on assign confirmation button");
                throw ex;
            }
            HardSleep();
        }

        public void RemoveAutoCategorisedClients(string ClientCategory)
        {
            try
            {
                ClickElement(CategorySearchDropdown);
                ReportLog("Passed", "Clicked on the category dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the category dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                foreach (IWebElement Category in Category1List)
                {
                    if (Category.Text.Contains(ClientCategory))
                    {
                        ClickElement(Category);
                        break;
                    }
                }
                ReportLog("Passed", "Selected " + ClientCategory + " category");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select a category");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SearchButton);
                ReportLog("Passed", "Clicked on search button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on search button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SelectAllCheckBoxes);
                ReportLog("Passed", "Clicked on check-all check box");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the check-all check box");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(RemoveButton);
                ReportLog("Passed", "Clicked on remove button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on remove button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(RemoveConfirmation);
                ReportLog("Passed", "Clicked on remove confirmation button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on remove confirmation button");
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
            QuickSleep();
        }

        public void ClientGroupingPageManualSearch(string SearchByName)
        {
            FasterSleep();
            try
            {
                EnterValues(UnassignedClientSearch, SearchByName);
                ReportLog("Passed", "Entered the client name as " + SearchByName + " in the search bar");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the client name in the search bar");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ClientSelectionFromSearch);
                ReportLog("Passed", "Selected the searched client");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select the searched client");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(AssignButton);
                ReportLog("Passed", "Clicked on assign button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on assign button");
                throw ex;
            }
            HardSleep();
            try
            {
                ClickElement(ClientAssigningConfirmation);
                ReportLog("Passed", "Clicked on assign confirmation button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on assign confirmation button");
                throw ex;
            }
            MediumSleep();
        }

        public void RemoveManuallyCategorisedClient(string SearchByName)
        {
            try
            {
                ClickElement(ClientSearchDropdown);
                ReportLog("Passed", "Clicked on client search dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on client search dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(ClientSearchBar, SearchByName);
                ReportLog("Passed", "Entered the client name as " + SearchByName + " in the search bar");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the client name in the search bar");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SearchedClientName);
                ReportLog("Passed", "Selected the searched client name");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select the searched client name");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SearchButton);
                ReportLog("Passed", "Clicked on search button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on search button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SearchedClientCheckbox);
                ReportLog("Passed", "Selected the manually caategorised client");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select the manually caategorised client");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(RemoveButton);
                ReportLog("Passed", "Clicked on remove button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on remove button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(RemoveConfirmation);
                ReportLog("Passed", "Clicked on remove confirmation button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on remove confirmation button");
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
            QuickSleep();
        }

        public void ProctorMappingPageCategoryTab()
        {
            try
            {
                ClickElement(ProctorMappingIcon1);
                ReportLog("Passed", "Clicked on Proctor mapping icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Proctor mapping icon");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(CategoryTab);
                ReportLog("Passed", "Clicked on category tab");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on category tab");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(CategoryColumnAssert.Displayed);
                ReportLog("Passed", "Asserted category column");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert category column");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(CategoryClientsColumnAssert.Displayed);
                ReportLog("Passed", "Asserted category clients column");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert category clients column");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(CategoryProctorsColumnAssert.Displayed);
                ReportLog("Passed", "Asserted category proctors column");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert category proctors column");
                throw ex;
            }
            QuickSleep();
            ScreenCapture(driver, "Proctor mapping category tab");
        }

        public void ProctorMappingPageProctorsTab(string ProctorEmployeeID,
                                                  string ProctorFirstName,
                                                  string ProctorLastName)
        {
            try
            {
                ClickElement(ProctorsTab);
                ReportLog("Passed", "Clicked on proctors tab");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on proctors tab");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ExportDocument);
                ReportLog("Passed", "Clicked on export icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on export icon");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(EmployeeID, ProctorEmployeeID);
                ReportLog("Passed", "Entered the proctor employee ID as " + ProctorEmployeeID);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the proctor employee ID");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(ProcFirstname, ProctorFirstName);
                ReportLog("Passed", "Entered the proctor first name as " + ProctorFirstName);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the proctor employee ID");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(ProcLastname, ProctorLastName);
                ReportLog("Passed", "Entered the proctor last name as " + ProctorLastName);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter the proctor employee ID");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(SaerchButtonProctor);
                ReportLog("Passed", "Clicked on search button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on search button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ActionButton);
                ReportLog("Passed", "Clicked on action button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on action button");
                throw ex;
            }
            QuickSleep();
        }

        public void ProctorProfile(string SpeechLevel,
                                   string AttentivenessLevel,
                                   string TechnicalKnowledgeLevel,
                                   string QualityLevel,
                                   string FlexibilityLevel)
        {
            try
            {
                ClickElement(ProctorProfileEditButton);
                ReportLog("Passed", "Clicked on edit button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on edit button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(RateOfSpeechDropdown);
                ReportLog("Passed", "Clicked on speech level dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on speech level dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                foreach (IWebElement speech in RateOfSpeechLevels)
                {
                    if (speech.Text.Contains(SpeechLevel))
                    {
                        ClickElement(speech);
                        break;
                    }
                }
                ReportLog("Passed", "Selected " + SpeechLevel + " level");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select speech level");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(AttentivenessDropdown);
                ReportLog("Passed", "Clicked on attentiveness level dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on attentiveness level dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                foreach (IWebElement attentiveness in AttentivenessLevels)
                {
                    if (attentiveness.Text.Contains(AttentivenessLevel))
                    {
                        ClickElement(attentiveness);
                        break;
                    }
                }
                ReportLog("Passed", "Selected " + AttentivenessLevel + " level");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select attentiveness level");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(TechnicalKnowledgeDropdown);
                ReportLog("Passed", "Clicked on technical knowledge level dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on technical knowledge level dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                foreach (IWebElement TechKnowledge in TechnicalKnowledgeLevels)
                {
                    if (TechKnowledge.Text.Contains(TechnicalKnowledgeLevel))
                    {
                        ClickElement(TechKnowledge);
                        break;
                    }
                }
                ReportLog("Passed", "Selected " + TechnicalKnowledgeLevel + " level");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select Tech skill level");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(QualityDropdown);
                ReportLog("Passed", "Clicked on quality level dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on quality level dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                foreach (IWebElement Quality in QualityLevels)
                {
                    if (Quality.Text.Contains(QualityLevel))
                    {
                        ClickElement(Quality);
                        break;
                    }
                }
                ReportLog("Passed", "Selected " + QualityLevel + " level");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select quality level");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(FlexibilityDropdown);
                ReportLog("Passed", "Clicked on flexibility level dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on flexibility level dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                foreach (IWebElement flexibility in FlexibilityLevels)
                {
                    if (flexibility.Text.Contains(FlexibilityLevel))
                    {
                        ClickElement(flexibility);
                        break;
                    }
                }
                ReportLog("Passed", "Selected " + FlexibilityLevel + " level");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select flexibility level");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(ProctorProfileSaveButton);
                ReportLog("Passed", "Clicked on proctor profile info save button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on proctor profile info save button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(PlatformAssigningConfirmation);
                ReportLog("Passed", "Clicked on ok button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on ok button");
                throw ex;
            }
            QuickSleep();
        }

        public void Platform(string Platform)
        {
            try
            {
                ClickElement(PlatformIcon);
                ReportLog("Passed", "Clicked on platform link");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on platform link");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(PlatformSelectionDropdown);
                ReportLog("Passed", "Clicked on platform selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on platform selection dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                foreach (IWebElement platform in PlatformChoices)
                {
                    if (platform.Text.Contains(Platform))
                    {
                        ClickElement(platform);
                        break;
                    }
                }
                ReportLog("Passed", "Selected " + Platform + " platform");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select platform");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(Click1);
                ReportLog("Passed", "Clicked on platform selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on platform selection dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(AssignPlatformButton);
                ReportLog("Passed", "Clicked on platform assign button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on platform assign button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(PlatformAssigningConfirmation);
                ReportLog("Passed", "Clicked on platform assign confirmation");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on platform assign confirmation");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(PlatformCheckbox);
                ReportLog("Passed", "Selected " + Platform + " platform for removal");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select the platform for removal");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(PlatformRemoveButton);
                ReportLog("Passed", "Clicked on platform remove button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on platform remove button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ConfirmRemove);
                ReportLog("Passed", "Clicked on removal confirmation command");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on removal confirmation command");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(PlatformAssigningConfirmation);
                ReportLog("Passed", "Clicked on removal confirmation ok button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on removal confirmation ok button");
                throw ex;
            }
            QuickSleep();
        }

        public void Category(string Category)
        {
            try
            {
                ClickElement(CategoryIcon);
                ReportLog("Passed", "Clicked on category link");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on category link");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(CategorySelectionDropdown);
                ReportLog("Passed", "Clicked on category selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on category selection dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                foreach (IWebElement category in CategorySelectionList)
                {
                    if (category.Text.Contains(Category))
                    {
                        ClickElement(category);
                        break;
                    }
                }
                ReportLog("Passed", "Selected " + Category + " category");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select category");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(Click5);
                ReportLog("Passed", "Clicked on pre assign button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on pre assign button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(AssignCategory);
                ReportLog("Passed", "Clicked on category assign button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on category assign button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ConfrimCategory);
                ReportLog("Passed", "Clicked on category assign confirmation");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on category assign confirmation");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(AssignedCategoryList);
                ReportLog("Passed", "Selected assigned category");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select the assigned category");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(RemoveCategory);
                ReportLog("Passed", "Clicked on category remove button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on category remove button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ConfirmCategoryRemove);
                ReportLog("Passed", "Clicked on removal confirmation command");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on removal confirmation command");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(CategoryRemovalConfirmation);
                ReportLog("Passed", "Clicked on removal confirmation ok button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on removal confirmation ok button");
                throw ex;
            }
            QuickSleep();
        }

        public void ExceptionsByCategory(string ClientCategoryByException,
                                         string Client)
        {
            try
            {
                ClickElement(ExceptionsByCategoryIcon);
                ReportLog("Passed", "Clicked on category link");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on category link");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ClientExceptionCheckbox);
                ReportLog("Passed", "Selected exception checkbox");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select exception checkbox");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(RemoveClientException);
                ReportLog("Passed", "Clicked on exception category remove button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on exception category remove button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ConfirmClientExceptionRemove);
                ReportLog("Passed", "Clicked on removal confirmation command");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on removal confirmation command");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ClientExceptionRemovalConfirmation);
                ReportLog("Passed", "Clicked on removal confirmation ok button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on removal confirmation ok button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ClientCategoryDropdown);
                ReportLog("Passed", "Clicked on category selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on category selection dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                foreach (IWebElement category in ClientCategoryList)
                {
                    if (category.Text.Contains(ClientCategoryByException))
                    {
                        ClickElement(category);
                        break;
                    }
                }
                ReportLog("Passed", "Selected " + ClientCategoryByException + " category");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select category");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(ClientDropdown);
                ReportLog("Passed", "Clicked on client selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on client selection dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                foreach (IWebElement client in ClientList)
                {
                    if (client.Text.Contains(Client))
                    {
                        ClickElement(client);
                        break;
                    }
                }
                ReportLog("Passed", "Selected " + ClientCategoryByException + " client");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select client");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(Click2);
                ReportLog("Passed", "Clicked on pre assign button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on pre assign button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(AddClientExceptionButton);
                ReportLog("Passed", "Clicked on assign button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on assign button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ConfirmClientEXceptionAddition);
                ReportLog("Passed", "Clicked on category assign confirmation");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on category assign confirmation");
                throw ex;
            }
            QuickSleep();
        }

        public void Language(string Language)
        {
            try
            {
                ClickElement(LanguageIcon);
                ReportLog("Passed", "Clicked on language link");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on language link");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(GermanLanguage);
                ReportLog("Passed", "Selected German language checkbox");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select German language checkbox");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(RemoveLanguageButton);
                ReportLog("Passed", "Clicked on language remove button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on language remove button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ConfirmLanguageRemove);
                ReportLog("Passed", "Clicked on removal confirmation command");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on removal confirmation command");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(LanguageRemovalConfirmation);
                ReportLog("Passed", "Clicked on removal confirmation ok button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on removal confirmation ok button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(LanguageDropdown);
                ReportLog("Passed", "Clicked on language selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on language selection dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                foreach (IWebElement language in LanguageList)
                {
                    if (language.Text.Contains(Language))
                    {
                        ClickElement(language);
                        break;
                    }
                }
                ReportLog("Passed", "Selected " + Language + " language");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select language");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(Click3);
                ReportLog("Passed", "Clicked on pre assign button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on pre assign button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(AssignLanguageButton);
                ReportLog("Passed", "Clicked on assign button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on assign button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(LanguageAdditionConfirmation);
                ReportLog("Passed", "Clicked on language assign confirmation");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on language assign confirmation");
                throw ex;
            }
            QuickSleep();
        }

        public void AccomodationsReady()
        {
            try
            {
                ClickElement(AccomodationReadyIcon);
                ReportLog("Passed", "Clicked on Accomodation link");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Accomodation link");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(AccomodationCheckbox);
                ReportLog("Passed", "Selected 'Yes' checkbox");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select 'Yes' checkbox");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(DeleteAccomodation);
                ReportLog("Passed", "Clicked on accomodation remove button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on accomodation remove button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ConfirmAccomodationRemove);
                ReportLog("Passed", "Clicked on removal confirmation command");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on removal confirmation command");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(AccomodationRemovalConfirmation);
                ReportLog("Passed", "Clicked on removal confirmation ok button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on removal confirmation ok button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(AccomodationDropdown);
                ReportLog("Passed", "Clicked on accomodation selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on accomodation selection dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(YesOption);
                ReportLog("Passed", "Selected 'Yes' option");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select 'Yes' option");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(AssignAccomodation);
                ReportLog("Passed", "Clicked on assign button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on assign button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(AccomodationConfirmation);
                ReportLog("Passed", "Clicked on language assign confirmation");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on language assign confirmation");
                throw ex;
            }
            QuickSleep();
        }

        public void Industry(string Industry)
        {
            try
            {
                ClickElement(IndustryIcon);
                ReportLog("Passed", "Clicked on industry link");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on industry link");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(IndustryCheckbox);
                ReportLog("Passed", "Selected Competency checkbox");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select Competency checkbox");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(RemoveIndustry);
                ReportLog("Passed", "Clicked on industry remove button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on industry remove button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ConfirmIndustryRemove);
                ReportLog("Passed", "Clicked on removal confirmation command");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on removal confirmation command");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(IndustryRemovalConfirmation);
                ReportLog("Passed", "Clicked on removal confirmation ok button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on removal confirmation ok button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(IndustryDropdown);
                ReportLog("Passed", "Clicked on industry dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on industry dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                foreach (IWebElement industry in IndustryList)
                {
                    if (industry.Text.Contains(Industry))
                    {
                        ClickElement(industry);
                        break;
                    }
                }
                ReportLog("Passed", "Selected " + Industry + " industry");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select industry");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(Click4);
                ReportLog("Passed", "Clicked on pre assign button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on pre assign button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(AssignIndustry);
                ReportLog("Passed", "Clicked on assign button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on assign button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(IndustryConfirmation);
                ReportLog("Passed", "Clicked on language assign confirmation");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on language assign confirmation");
                throw ex;
            }
            QuickSleep();
        }

        public void ProctorAvailability()
        {
            try
            {
                ClickElement(ProctorAvailabilityTab);
                ReportLog("Passed", "Clicked on proctor availability tab");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on proctor availability tab");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(AssertScheduledStatus.Displayed);
                ReportLog("Passed", "Asserted Scheduled status visibility");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert Scheduled status visibility");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(AssertWaitingForProctorStatus.Displayed);
                ReportLog("Passed", "Asserted waiting for proctor status visibility");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert waiting for proctor status visibility");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(AssertVerificationInProgresStatus.Displayed);
                ReportLog("Passed", "Asserted verification in progress status visibility");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert verification in progress status visibility");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(AssertVerificationInProgresStatus.Displayed);
                ReportLog("Passed", "Asserted in progress status visibility");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert in progress status visibility");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(AssertActualLogoutStatus.Displayed);
                ReportLog("Passed", "Asserted actual logout status visibility");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert actual logout status visibility");
                throw ex;
            }
            QuickSleep();
            ScreenCapture(driver, "Proctor availability page");
            HardSleep();
            driver.SwitchTo().Window(driver.WindowHandles[1]);
        }

        public void OperationsAndProctorFlowSTEP1()
        {
            HardSleep();
            try
            {
                Assert.True(ShiftLoginAssert.Displayed);
                ReportLog("Passed", "Asserted proctor shift login time");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert proctor shift login time");
                throw ex;
            }
            QuickSleep();
            ScreenCapture(driver, "Proctor shift commencement");
            HardSleep();
            string ShiftHour = getDataParser().extractDataLoginCredentials("ShiftHour");
            ProctorAvailabilityFlowPage proctorAvailabilityFlowPage = new ProctorAvailabilityFlowPage(driver);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            proctorAvailabilityFlowPage.ProctorOperatorFlowSTEP2(ShiftHour);
        }

        public void OperationsAndProctorFlowSTEP2()
        {
            HardSleep();
            try
            {
                string toTime = ToTime.Text;
                string highlightedTime = HighlightedToTimeTable.Text;
                Assert.AreEqual(toTime, highlightedTime);
                Console.WriteLine(toTime, highlightedTime);
                ReportLog("Passed", "Asserted proctor shift ending time");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert proctor shift ending time");
                throw ex;
            }
            QuickSleep();
            ScreenCapture(driver, "Proctor shift time alteration");
            HardSleep();
            ProctorAvailabilityFlowPage proctorAvailabilityFlowPage = new ProctorAvailabilityFlowPage(driver);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            proctorAvailabilityFlowPage.ProctorOperatorFlowSTEP3();
        }

        public void OperationsAndProctorFlowSTEP3()
        {
            HardSleep();
            try
            {
                Assert.True(BreakTimeStart.Displayed);
                ReportLog("Passed", "Asserted proctor break time starting");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert proctor break time starting");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(BreakIcon.Displayed);
                ReportLog("Passed", "Asserted proctor break time using break icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert proctor break time using break icon");
                throw ex;
            }
            QuickSleep();
            ScreenCapture(driver, "Proctor break time commencement");
            HardSleep();
            ProctorAvailabilityFlowPage proctorAvailabilityFlowPage = new ProctorAvailabilityFlowPage(driver);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            proctorAvailabilityFlowPage.ProctorOperatorFlowSTEP4();
        }

        public void OperationsAndProctorFlowSTEP4()
        {
            HardSleep();
            try
            {
                Assert.True(BreakTimeOver.Displayed);
                ReportLog("Passed", "Asserted proctor break time ending");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert proctor break time ending");
                throw ex;
            }
            QuickSleep();
            try
            {
                Assert.True(AvailableIcon.Displayed);
                ReportLog("Passed", "Asserted proctor break time using available icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert proctor break time using available icon");
                throw ex;
            }
            QuickSleep();
            ScreenCapture(driver, "Proctor break time ending");
            HardSleep();
            ProctorAvailabilityFlowPage proctorAvailabilityFlowPage = new ProctorAvailabilityFlowPage(driver);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            proctorAvailabilityFlowPage.ProctorOperatorFlowSTEP5();
        }

        public void OperationsAndProctorFlowSTEP5()
        {
            HardSleep();
            try
            {
                Assert.True(ActiveRequestStatus.Displayed);
                ReportLog("Passed", "Asserted proctor active request status");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert proctor active request status");
                throw ex;
            }
            QuickSleep();
            ScreenCapture(driver, "Proctor active request status");
            HardSleep();
            ProctorAvailabilityFlowPage proctorAvailabilityFlowPage = new ProctorAvailabilityFlowPage(driver);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            proctorAvailabilityFlowPage.ProctorOperatorFlowSTEP6();
        }

        public void OperationsAndProctorFlowSTEP6()
        {
            HardSleep();
            ScreenCapture(driver, "Proctor shift logged out");
            QuickSleep();
            ProctorAvailabilityFlowPage proctorAvailabilityFlowPage = new ProctorAvailabilityFlowPage(driver);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            proctorAvailabilityFlowPage.ProctorOperatorFlowSTEP7();
        }

        public void ReportsTabRosterPage(string ProctorEmployeeID,
                                         string ProctorFirstName,
                                         string ProctorLastName)
        {
            try
            {
                ClickElement(ReportsTab);
                ReportLog("Passed", "Clicked on reports tab");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on reports tab");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(ReportsEmployeeID, ProctorEmployeeID);
                ReportLog("Passed", "Entered proctor employee ID in roster page as " + ProctorEmployeeID);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter proctor employee ID in roster page");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(ReportsProctorFName, ProctorFirstName);
                ReportLog("Passed", "Entered proctor first name in roster page as " + ProctorFirstName);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter proctor first name in roster page");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(ReportsProctorLName, ProctorLastName);
                ReportLog("Passed", "Entered proctor last name in roster page as " + ProctorLastName);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter proctor last name in roster page");
                throw ex;
            }
            QuickSleep();
            try
            {
                string RosterFromDate = DateTime.Today.AddDays(-365).ToString("M/d/yyyy");
                EnterValues(rosterFromDate, RosterFromDate);
                ReportLog("Passed", "Entered from-date as " + RosterFromDate);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter end date");
                throw ex;
            }
            QuickSleep();
            try
            {
                string RosterToDate = DateTime.Now.ToString("M/d/yyyy");
                EnterValues(rosterToDate, RosterToDate);
                ReportLog("Passed", "Entered to- date as " + RosterToDate);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter start date");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(RosterSearchButton);
                ReportLog("Passed", "Clicked on search button in roster page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on search button in roster page");
                throw ex;
            }
            MediumSleep();
            ScreenCapture(driver, "Reports roster page");
            MediumSleep();
            try
            {
                ClickElement(RosterResultsExportButton);
                ReportLog("Passed", "Clicked on export button in roster page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on export button in roster page");
                throw ex;
            }
            MediumSleep();
        }

        public void ReportsCheckInCheckOutPage(string ProctorEmployeeID,
                                               string ProctorFirstName,
                                               string ProctorLastName)
        {
            try
            {
                ClickElement(CheckINCheckOutPage);
                ReportLog("Passed", "Clicked on check-in check-out page icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on check-in check-out page icon");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(CheckEmployeeID, ProctorEmployeeID);
                ReportLog("Passed", "Entered proctor employee ID in check-in check-out page as " + ProctorEmployeeID);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter proctor employee ID in check-in check-out page");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(CheckProctorFName, ProctorFirstName);
                ReportLog("Passed", "Entered proctor first name in check-in check-out page as " + ProctorFirstName);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter proctor first name in check-in check-out page");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(CheckProctorLName, ProctorLastName);
                ReportLog("Passed", "Entered proctor last name in check-in check-out page as " + ProctorLastName);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter proctor last name in check-in check-out page");
                throw ex;
            }
            QuickSleep();
            try
            {
                string checkFromDate = DateTime.Today.AddDays(-365).ToString("M/d/yyyy");
                EnterValues(CheckFromDate, checkFromDate);
                ReportLog("Passed", "Entered from-date as " + checkFromDate + " in check-in check-out page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter from-date in check-in check-out page");
                throw ex;
            }
            QuickSleep();
            try
            {
                string checkToDate = DateTime.Now.ToString("M/d/yyyy");
                EnterValues(CheckToDate, checkToDate);
                ReportLog("Passed", "Entered to-date as " + checkToDate + " in check-in check-out page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter to-date in check-in check-out page");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(CheckSearchButton);
                ReportLog("Passed", "Clicked on search button in check-in check-out page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on search button in check-in check-out page");
                throw ex;
            }
            MediumSleep();
            ScreenCapture(driver, "Reports check-in check-out page");
            MediumSleep();
            try
            {
                ClickElement(CheckResultsExportButton);
                ReportLog("Passed", "Clicked on export button in check-in check-out page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on export button in check-in check-out page");
                throw ex;
            }
            MediumSleep();
        }

        public void ReportsBreakTime(string ProctorLastName,
                                     string TeamLead)
        {
            try
            {
                ClickElement(ReportsBreakTimeIcon);
                ReportLog("Passed", "Clicked on break time page icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on break time page icon");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(BreakTimeProctorName, ProctorLastName);
                ReportLog("Passed", "Entered proctor name in break time page as " + ProctorLastName);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter proctor name in break time page");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(BreakTimeTeamLead, TeamLead);
                ReportLog("Passed", "Entered team lead name in break time page as " + TeamLead);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter team lead name in break time page");
                throw ex;
            }
            QuickSleep();
            try
            {
                string checkFromDate = DateTime.Today.AddDays(-365).ToString("M/d/yyyy");
                EnterValues(BreakTimeFromDate, checkFromDate);
                ReportLog("Passed", "Entered from-date as " + checkFromDate + " in break time page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter from-date in break time page");
                throw ex;
            }
            QuickSleep();
            try
            {
                string checkToDate = DateTime.Now.ToString("M/d/yyyy");
                EnterValues(BreakTimeToDate, checkToDate);
                ReportLog("Passed", "Entered to-date as " + checkToDate + " in break time page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter to-date in break time page");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(BreakTimeSearchButton);
                ReportLog("Passed", "Clicked on search button in break time page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on search button in break time page");
                throw ex;
            }
            MediumSleep();
            ScreenCapture(driver, "Reports break time page");
            MediumSleep();
            try
            {
                ClickElement(BreakTimeResultsExportButton);
                ReportLog("Passed", "Clicked on export button in break time page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on export button in break time page");
                throw ex;
            }
            MediumSleep();
        }

        public void ReportsExamRequestPage(string ProctorLastName,
                                           string TeamLead)
        {
            try
            {
                ClickElement(ReportsExamRequestIcon);
                ReportLog("Passed", "Clicked on exam request page icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on exam request page icon");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(ExamRequestProctorName, ProctorLastName);
                ReportLog("Passed", "Entered proctor name in exam request page as " + ProctorLastName);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter proctor name in exam request page");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(ExamRequestTeamLead, TeamLead);
                ReportLog("Passed", "Entered team lead name in exam request page as " + TeamLead);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter team lead name in exam request page");
                throw ex;
            }
            QuickSleep();
            try
            {
                string checkFromDate = DateTime.Today.AddDays(-365).ToString("M/d/yyyy");
                EnterValues(ExamRequestFromDate, checkFromDate);
                ReportLog("Passed", "Entered from-date as " + checkFromDate + " in exam request page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter from-date in exam request page");
                throw ex;
            }
            QuickSleep();
            try
            {
                string checkToDate = DateTime.Now.ToString("M/d/yyyy");
                EnterValues(ExamRequestToDate, checkToDate);
                ReportLog("Passed", "Entered to-date as " + checkToDate + " in exam request page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter to-date in exam request page");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ExamRequestSearchButton);
                ReportLog("Passed", "Clicked on search button in exam request page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on search button in exam request page");
                throw ex;
            }
            MediumSleep();
            ScreenCapture(driver, "Reports exam request page");
            MediumSleep();
            try
            {
                ClickElement(ExamRequestResultsExportButton);
                ReportLog("Passed", "Clicked on export button in exam request page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on export button in exam request page");
                throw ex;
            }
            MediumSleep();
        }

        public void ReportsVMPage(string vMUsername,
                                  string ProctorFirstName,
                                  string ProctorLastName)
        {
            try
            {
                ClickElement(ReportsVMIcon);
                ReportLog("Passed", "Clicked on VM page icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on VM page icon");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(VMUsername, vMUsername);
                ReportLog("Passed", "Entered VM Username in VM page as " + vMUsername);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter VM Username in VM page");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(VMProctorFName, ProctorFirstName);
                ReportLog("Passed", "Entered proctor first name in VM page as " + ProctorFirstName);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter proctor first name in VM page");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(VMProctorLName, ProctorLastName);
                ReportLog("Passed", "Entered proctor last name in VM page as " + ProctorLastName);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter proctor last name in VM page");
                throw ex;
            }
            QuickSleep();
            try
            {
                string checkFromDate = DateTime.Today.AddDays(-365).ToString("M/d/yyyy");
                EnterValues(VMFromDate, checkFromDate);
                ReportLog("Passed", "Entered from-date as " + checkFromDate + " in VM page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter from-date in VM page");
                throw ex;
            }
            QuickSleep();
            try
            {
                string checkToDate = DateTime.Now.ToString("M/d/yyyy");
                EnterValues(VMToDate, checkToDate);
                ReportLog("Passed", "Entered to-date as " + checkToDate + " in VM page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter to-date in VM page");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(VMSearchButton);
                ReportLog("Passed", "Clicked on search button in VM page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on search button in VM page");
                throw ex;
            }
            MediumSleep();
            ScreenCapture(driver, "Reports VM page");
            MediumSleep();
            try
            {
                ClickElement(VMResultsExportButton);
                ReportLog("Passed", "Clicked on export button in VM page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on export button in VM page");
                throw ex;
            }
            MediumSleep();
        }

        public void ReportsExamAssignmentPage(string ProctorLastName)
        {
            try
            {
                ClickElement(ReportsExamAssignmentIcon);
                ReportLog("Passed", "Clicked on exam assignment page icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on exam assignment page icon");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(VMProctorFName, ProctorLastName);
                ReportLog("Passed", "Entered proctor first name in exam assignment page as " + ProctorLastName);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter proctor first name in exam assignment page");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(ExamAssignmentExamID, StudentDashboardPage.AppoinmentID);
                ReportLog("Passed", "Entered proctor last name in exam assignment page as " + StudentDashboardPage.AppoinmentID);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter proctor last name in exam assignment page");
                throw ex;
            }
            QuickSleep();
            try
            {
                string checkFromDate = DateTime.Today.AddDays(-365).ToString("M/d/yyyy");
                EnterValues(ExamAssignmentFromDate, checkFromDate);
                ReportLog("Passed", "Entered from-date as " + checkFromDate + " in exam assignment page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter from-date in exam assignment page");
                throw ex;
            }
            QuickSleep();
            try
            {
                string checkToDate = DateTime.Now.ToString("M/d/yyyy");
                EnterValues(ExamAssignmentToDate, checkToDate);
                ReportLog("Passed", "Entered to-date as " + checkToDate + " in exam assignment page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter to-date in exam assignment page");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ExamAssignmentSearchButton);
                ReportLog("Passed", "Clicked on search button in exam assignment page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on search button in exam assignment page");
                throw ex;
            }
            MediumSleep();
            ScreenCapture(driver, "Reports exam assignment page");
            MediumSleep();
            try
            {
                ClickElement(ExamAssignmentExaportButton);
                ReportLog("Passed", "Clicked on export button in exam assignment page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on export button in exam assignment page");
                throw ex;
            }
            MediumSleep();
        }

        public void ReportsEODPage(string ProctorLastName,
                                   string TeamLead)
        {
            try
            {
                EnterValues(EODExamID, StudentDashboardPage.AppoinmentID);
                ReportLog("Passed", "Entered proctor last name in EOD page as " + StudentDashboardPage.AppoinmentID);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter proctor last name in EOD page");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(EODProctorName, ProctorLastName);
                ReportLog("Passed", "Entered proctor first name in EOD page as " + ProctorLastName);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter proctor first name in EOD page");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(EODTeamLead, TeamLead);
                ReportLog("Passed", "Entered team lead name in EOD page as " + TeamLead);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter team lead name in EOD page");
                throw ex;
            }
            QuickSleep();
            try
            {
                string checkFromDate = DateTime.Today.AddDays(-365).ToString("M/d/yyyy");
                EnterValues(EODFromDate, checkFromDate);
                ReportLog("Passed", "Entered from-date as " + checkFromDate + " in EOD page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter from-date in EOD page");
                throw ex;
            }
            QuickSleep();
            try
            {
                string checkToDate = DateTime.Now.ToString("M/d/yyyy");
                EnterValues(EODToDate, checkToDate);
                ReportLog("Passed", "Entered to-date as " + checkToDate + " in EOD page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter to-date in EOD page");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(EODSearchButton);
                ReportLog("Passed", "Clicked on search button in EOD page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on search button in EOD page");
                throw ex;
            }
            MediumSleep();
            ScreenCapture(driver, "Reports exam assignment page");
            MediumSleep();
            try
            {
                ClickElement(EODResultExportButton);
                ReportLog("Passed", "Clicked on export button in EOD page");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on export button in EOD page");
                throw ex;
            }
            MediumSleep();
        }

    }
}
