using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace PortalApplicationFramework.PageObjects
{
    class HourlyExamVolumePage : BasePage
    {
        private IWebDriver driver;
        public HourlyExamVolumePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PAGE NAVIGATION
        [FindsBy(How = How.Id, Using = "ctl00_HyperLink4")]
        private IWebElement linkReport;
        [FindsBy(How = How.CssSelector, Using = "img[title='Hourly Exam Volume']")]
        private IWebElement iconHourlyExamVolume;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lblTitle")]
        private IWebElement AssertLogo;

        //CHECKBOX CLIENT SELECTION
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddlClients_Arrow")]
        private IWebElement CheckBoxClientSelectionDropdown;
        [FindsBy(How = How.ClassName, Using = "rcbCheckAllItemsCheckBox")]
        private IWebElement unCheckAll;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlClients_DropDown']/div/ul/li")]
        private IList<IWebElement> selectCheckBoxClient;

        //SELECT DATE
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_txtFromDate_popupButton")]
        private IWebElement datePopUpButton;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_txtFromDate_calendar_Title")]
        private IWebElement selectMonthYear;
        [FindsBy(How = How.XPath, Using = "//table[@id='ctl00_ContentPlaceHolder1_txtFromDate_calendar_FastNavPopup']//tr/td/a")]
        private IWebElement selectMonthandYear;
        [FindsBy(How = How.Id, Using = "rcMView_OK")]
        private IWebElement confirmMonthYear;
        [FindsBy(How = How.XPath, Using = "//table[@id='ctl00_ContentPlaceHolder1_txtFromDate_calendar_Top']//tr/td/a")]
        private IWebElement selectDate;
        
        //SELECT STATUS
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddlTransactionStatus_Arrow")]
        private IWebElement StatusDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlTransactionStatus_DropDown']/div/ul/li")]
        private IList<IWebElement> selectStatus;

        //SELECT EXAM LEVEL
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddlExamSecurity_Arrow")]
        private IWebElement ExamLevelDropDown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlExamSecurity_DropDown']//input[@class='rcbCheckAllItemsCheckBox']")]
        private IWebElement selectCheckAll;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlExamSecurity_DropDown']/div/ul/li")]
        private IList<IWebElement> selectOtherExamLevel;

        //SHOW DETAILS BUTTON & SEARCH
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnYesNo")]
        private IWebElement ShowDetailsButton;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnSearch")]
        private IWebElement searchButton;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lblcount")]
        private IWebElement V4V5texts;
       
        public void navigateToHourlyExamVolumepage(string reportTab, string LoginpageUrl)
        {
            if (driver.Url.Contains(LoginpageUrl) || driver.Title.Contains("Examity Dashboard :: Login"))
            {
                string userName = getDataParser().extractDataLoginCredentials("userName");
                string password = getDataParser().extractDataLoginCredentials("password");
                string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
                string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
                string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

                string LoginUserName;
                string LoginPassword;
                LoginPage loginPage = new LoginPage(driver);
                /*loginPage.AssertLogin();*/

                if (LoginAs == "Admin")
                {
                    Console.WriteLine("Entered the Admin if block");
                    LoginUserName = adminUserName;
                    LoginPassword = adminPassword;
                    loginPage.signIn(LoginUserName, LoginPassword);
                    loginPage.signInAdmin();
                }
                else
                {
                    Console.WriteLine("Entered the User else block");
                    LoginUserName = userName;
                    LoginPassword = password;
                    loginPage.signIn(LoginUserName, LoginPassword);
                    if (driver.Url.Contains("switchrole.aspx"))
                    {
                        loginPage.signInUserProd();
                    }
                }
            }
            Sleep(5000);
            try
            {
                ClickElement(linkReport);
                ReportLog("Passed", "Clicked on reports tab");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on reports tab");
                throw ex;
            }
            Sleep(5000);
            try
            {
                ClickElement(iconHourlyExamVolume);
                ReportLog("Passed", "Clicked on Hourly exam volume icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Hourly exam volume icon");
                throw ex;
            }
            try
            {
                Assert.IsTrue(AssertLogo.Displayed);
                ReportLog("Passed", "Asserted");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert");
                throw ex;
            }
            Sleep(5000);
        }

        public void selectClientDropdown(int expClient)
        {
            Sleep(1000);
            if (expClient == 0)
            {
                try
                {
                    ReportLog("Passed", "Clicked on check-all clients");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on check-all clients");
                    throw ex;
                }
            }
            else
            {
                try
                {
                    ClickElement(CheckBoxClientSelectionDropdown);
                    ReportLog("Passed", "Clicked on client selection dropdown");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on client selection dropdown");
                    throw ex;
                }
                Sleep(2000);
                try
                {
                    ClickElement(unCheckAll);
                    ReportLog("Passed", "Clicked on uncheck-all");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on uncheck all");
                    throw ex;
                }
                Sleep(2000);
                for (int i = 0; i < expClient; i++)
                {
                    Sleep(2000);
                    Random r = new Random();
                    int rInt = r.Next(1, selectCheckBoxClient.Count);
                    try
                    {
                        selectCheckBoxClient[rInt].Click();
                        ReportLog("Passed", "selected clients");
                    }
                    catch (Exception ex)
                    {
                        ReportLog("Failed", "Didn't select clients");
                        throw ex;
                    }
                }
                Sleep(2000);
            }
        }

        public void selectDateDetails()
        {
            ClickElement(datePopUpButton);
            ClickElement(selectMonthYear);
            ClickElement(selectMonthandYear);
            ClickElement(confirmMonthYear);
            try
            {
                ClickElement(selectDate);
                ReportLog("Passed", "selected date");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select date");
                throw ex;
            }
        }

        public void selectStatusdetails(String expStatus)
        {
            try
            {
                ClickElement(StatusDropdown);
                ReportLog("Passed", "Clicked on status selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on status selection dropdown");
                throw ex;
            }
            Sleep(1000);
            try
            {
                foreach (IWebElement status in selectStatus)
                {
                    if (status.Text.Equals(expStatus))
                    {
                        ClickElement(status);
                        break;
                    }
                }
                ReportLog("Passed", "selected status");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select status");
                throw ex;
            }
            Sleep(1000);
        }

        public void selectExamLevel(String expExamLevel)
        {
            try
            {
                ClickElement(ExamLevelDropDown);
                ReportLog("Passed", "Clicked on exam level selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on exam level selection dropdown");
                throw ex;
            }
            Sleep(1000);
            try
            {
                ClickElement(selectCheckAll);
                ReportLog("Passed", "selected check-all");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select check-all");
                throw ex;
            }
            Sleep(1000);
            try
            {
                foreach (IWebElement examLevel in selectOtherExamLevel)
                {
                    if (examLevel.Text.Equals(expExamLevel))
                    {
                        ClickElement(examLevel);
                        break;
                    }
                }
                ReportLog("Passed", "selected exam level");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select exam level");
                throw ex;
            }
            Sleep(1000);
        }

        public void SelectSearch()
        {
            ClickElement(ShowDetailsButton);
            ClickElement(searchButton);
            try
            {
                ClickElement(searchButton);
                ReportLog("Passed", "Clicked on search button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on search button");
                throw ex;
            }
            Console.WriteLine(V4V5texts);
            Sleep(5000);
            ScreenCapture(driver);
        }
    }
}
