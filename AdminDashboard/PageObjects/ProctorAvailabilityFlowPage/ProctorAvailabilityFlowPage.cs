using AdminDashboard.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace AdminDashboard.PageObjects
{
    class ProctorAvailabilityFlowPage : BasePage
    {
        public ProctorAvailabilityFlowPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public IWebDriver driver;
        string ProctorEmployeeID = "Admin";
        string ProctorID = "adproc2lang@examity.com";
        string ProctorShiftTime = "03:30 AM - 12:30 PM";
        string ProctorWeekOff = "Sunday";
        string ProctorTeamLead = "TL";
        string ProctorLocation = "HYD - Center 2";
        string Category = "1, 3, 6, 7, 10";

        // LOGIN PAGE
        [FindsBy(How = How.Id, Using = "txtUserName")]
        private IWebElement ProctorUsername;
        [FindsBy(How = How.Id, Using = "txtPassword")]
        private IWebElement ProctorPassword;
        [FindsBy(How = How.Id, Using = "btnLogin_input")]
        private IWebElement LoginButton;

        // MY AVAILABILITY TAB
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_lblEmpID")]
        private IWebElement ProcEmployeeID;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_lblProctorID")]
        private IWebElement ProcID;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_lblShiftTime")]
        private IWebElement ProcShiftTime;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_lblWeekOff")]
        private IWebElement WeekOff;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_lblTeamLead")]
        private IWebElement TeamLead;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_lblLocation")]
        private IWebElement ProcLocation;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_lblCategory")]
        private IWebElement ProcCategory;

        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_btnLogin")]
        private IWebElement ShiftLogin;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_gvTimings_ctl00_ctl04_EditButton")]
        private IWebElement EditShiftTiming;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_gvTimings_ctl00_ctl04_rcbHours_Input")]
        private IWebElement ShiftTimeHoursDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ProctorContent_gvTimings_ctl00_ctl04_rcbHours_DropDown']/div/ul/li")]
        private IList<IWebElement> HoursList;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_gvTimings_ctl00_ctl04_UpdateButton")]
        private IWebElement SaveShiftTimeChangeButton;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_btnBreakStart")]
        private IWebElement StartBreak;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_btnBreakEnd")]
        private IWebElement EndBreak;
        [FindsBy(How = How.Id, Using = "ctl00_lnkProductivity")]
        private IWebElement MyProductivityTab;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_btnRequest")]
        private IWebElement RequestExamButton;
        [FindsBy(How = How.Id, Using = "ctl00_lnkAvailability")]
        private IWebElement MyAvailabilityTab;
        [FindsBy(How = How.Id, Using = "ctl00_ProctorContent_btnLogout")]
        private IWebElement ShiftLogoutButton;
        [FindsBy(How = How.Id, Using = "ctl00_lnlLogout")]
        private IWebElement LogoutTab;

        public void ProctorLogin(string ProctorUserName,
                                 string ProctorPassWord)
        {
            try
            {
                EnterValues(ProctorUsername, ProctorUserName);
                ReportLog("Passed", "Entered proctor username as " + ProctorUserName);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter proctor username");
                throw ex;
            }
            QuickSleep();
            try
            {
                EnterValues(ProctorPassword, ProctorPassWord);
                ReportLog("Passed", "Entered proctor password as " + ProctorPassWord);
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter proctor password");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(LoginButton);
                ReportLog("Passed", "Clicked on proctor login button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on proctor login button");
                throw ex;
            }
            QuickSleep();
        }

        public void MyAvailabilityPageComponentAssertion()
        { 
            try
            {
                string procEmployeeID = ProcEmployeeID.Text;
                Assert.AreEqual(procEmployeeID, ProctorEmployeeID);
                Console.WriteLine(procEmployeeID, ProcEmployeeID);
                ReportLog("Passed", "Asserted proctor employee ID");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert proctor employee ID");
                throw ex;
            }
            QuickSleep();
            try
            {
                string procID = ProcID.Text;
                Assert.AreEqual(procID, ProctorID);
                Console.WriteLine(procID, ProctorID);
                ReportLog("Passed", "Asserted proctor ID");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert proctor ID");
                throw ex;
            }
            QuickSleep();
            try
            {
                string procShiftTime = ProcShiftTime.Text;
                Assert.AreEqual(procShiftTime, ProctorShiftTime);
                Console.WriteLine(procShiftTime, ProctorShiftTime);
                ReportLog("Passed", "Asserted proctor shift time");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert proctor shift time");
                throw ex;
            }
            QuickSleep();
            try
            {
                string weekOff = WeekOff.Text;
                Assert.AreEqual(weekOff, ProctorWeekOff);
                Console.WriteLine(weekOff, ProctorWeekOff);
                ReportLog("Passed", "Asserted proctor week off");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert proctor week off");
                throw ex;
            }
            QuickSleep();
            try
            {
                string teamLead = TeamLead.Text;
                Assert.AreEqual(teamLead, ProctorTeamLead);
                Console.WriteLine(teamLead, ProctorTeamLead);
                ReportLog("Passed", "Asserted proctor week off");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert proctor week off");
                throw ex;
            }
            QuickSleep();
            try
            {
                string procLocation = ProcLocation.Text;
                Assert.AreEqual(procLocation, ProctorLocation);
                Console.WriteLine(procLocation, ProctorLocation);
                ReportLog("Passed", "Asserted proctor location");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert proctor location");
                throw ex;
            }
            QuickSleep();
            try
            {
                string procCategory = ProcCategory.Text;
                Assert.AreEqual(procCategory, Category);
                Console.WriteLine(procCategory, Category);
                ReportLog("Passed", "Asserted proctor category");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert proctor category");
                throw ex;
            }
            QuickSleep();
        }

        public void ProctorOperatorFlowSTEP1()
        {
            HardSleep();
            try
            {
                ClickElement(ShiftLogin);
                ReportLog("Passed", "Clicked on shift login button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on shift login button");
                throw ex;
            }
            HardSleep();
            OperationsDashboardPage operationsDashboardPage = new OperationsDashboardPage(driver);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            operationsDashboardPage.OperationsAndProctorFlowSTEP1();
        }

        public void ProctorOperatorFlowSTEP2(string ShiftHour)
        {
            HardSleep();
            try
            {
                ClickElement(EditShiftTiming);
                ReportLog("Passed", "Clicked on shift time edit button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on shift time edit button");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ShiftTimeHoursDropdown);
                ReportLog("Passed", "Clicked on shift time hourly dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on shift time hourly dropdown");
                throw ex;
            }
            QuickSleep();
            try
            {
                foreach (IWebElement hour in HoursList)
                {
                    if (hour.Text.Contains(ShiftHour))
                    {
                        ClickElement(hour);
                        break;
                    }
                }
                ReportLog("Passed", "Selected " + ShiftHour + " hourly change");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select hourly shift change");
                throw ex;
            }
            MediumSleep();
            try
            {
                ClickElement(SaveShiftTimeChangeButton);
                ReportLog("Passed", "Clicked on hourly shift time change save button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on hourly shift time change save button");
                throw ex;
            }
            HardSleep();
            OperationsDashboardPage operationsDashboardPage = new OperationsDashboardPage(driver);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            operationsDashboardPage.OperationsAndProctorFlowSTEP2();
        }

        public void ProctorOperatorFlowSTEP3()
        {
            HardSleep();
            try
            {
                ClickElement(StartBreak);
                ReportLog("Passed", "Clicked on start break time");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on start break time");
                throw ex;
            }
            HardSleep();
            OperationsDashboardPage operationsDashboardPage = new OperationsDashboardPage(driver);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            operationsDashboardPage.OperationsAndProctorFlowSTEP3();
        }

        public void ProctorOperatorFlowSTEP4()
        {
            HardSleep();
            try
            {
                ClickElement(EndBreak);
                ReportLog("Passed", "Clicked on end break time");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on end break time");
                throw ex;
            }
            HardSleep();
            OperationsDashboardPage operationsDashboardPage = new OperationsDashboardPage(driver);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            operationsDashboardPage.OperationsAndProctorFlowSTEP4();
        }

        public void ProctorOperatorFlowSTEP5()
        {
            HardSleep();
            try
            {
                ClickElement(MyProductivityTab);
                ReportLog("Passed", "Clicked on 'my productivity' tab");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on 'my productivity' tab");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(RequestExamButton);
                ReportLog("Passed", "Clicked on request exam button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on request exam button");
                throw ex;
            }
            HardSleep();
            OperationsDashboardPage operationsDashboardPage = new OperationsDashboardPage(driver);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            operationsDashboardPage.OperationsAndProctorFlowSTEP5();
        }

        public void ProctorOperatorFlowSTEP6()
        {
            HardSleep();
            try
            {
                ClickElement(MyAvailabilityTab);
                ReportLog("Passed", "Clicked on my availability tab");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on my availability tab");
                throw ex;
            }
            QuickSleep();
            try
            {
                ClickElement(ShiftLogoutButton);
                ReportLog("Passed", "Clicked on shift logout button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on shift logout button");
                throw ex;
            }
            HardSleep();
            OperationsDashboardPage operationsDashboardPage = new OperationsDashboardPage(driver);
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            operationsDashboardPage.OperationsAndProctorFlowSTEP6();
        }

        public void ProctorOperatorFlowSTEP7()
        {
            HardSleep();
            try
            {
                ClickElement(LogoutTab);
                ReportLog("Passed", "Clicked on logout button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on logout button");
                throw ex;
            }
            FasterSleep();
            driver.SwitchTo().Window(driver.WindowHandles[1]).Close();
        }
    }
}
