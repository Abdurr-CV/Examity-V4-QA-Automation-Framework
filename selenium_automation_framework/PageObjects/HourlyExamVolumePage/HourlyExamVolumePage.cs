using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;

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
       
        public void navigateToHourlyExamVolumepage(string userName,
                                                 string password,
                                                 string adminUserName,
                                                 string adminPassword,
                                                 string LoginAs)
        {
            string loginUrl = driver.Url;
            if (loginUrl.Contains("Login.aspx"))
            {
                string LoginUserName;
                string LoginPassword;
                LoginPage loginPage = new LoginPage(driver);
                loginPage.AssertLogin();

                if (LoginAs == "Admin")
                {
                    LoginUserName = adminUserName;
                    LoginPassword = adminPassword;
                    loginPage.signIn(LoginUserName, LoginPassword);
                    loginPage.signInAdmin();
                }
                else
                {
                    LoginUserName = userName;
                    LoginPassword = password;
                    loginPage.signIn(LoginUserName, LoginPassword);
                }
            }
            ClickElement(linkReport);
            ClickElement(iconHourlyExamVolume);
            Assert.IsTrue(AssertLogo.Displayed);
        }

        public void selectClientDropdown(int expClient)
        {
            Sleep(1000);
            if (expClient == 0)
            {
            }
            else
            {
                ClickElement(CheckBoxClientSelectionDropdown);
                Sleep(2000);
                ClickElement(unCheckAll);
                Sleep(2000);
                for (int i = 0; i < expClient; i++)
                {
                    Sleep(2000);
                    Random r = new Random();
                    int rInt = r.Next(1, selectCheckBoxClient.Count);
                    selectCheckBoxClient[rInt].Click();
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
            ClickElement(selectDate);
        }

        public void selectStatusdetails(String expStatus)
        {
            ClickElement(StatusDropdown);
            Sleep(1000);
            foreach (IWebElement status in selectStatus)
            {
                if (status.Text.Equals(expStatus))
                {
                    ClickElement(status);
                    break;
                }
            }
            Sleep(1000);
        }

        public void selectExamLevel(String expExamLevel)
        {
            ClickElement(ExamLevelDropDown);
            Sleep(1000);
            ClickElement(selectCheckAll);
            Sleep(1000);
            foreach (IWebElement examLevel in selectOtherExamLevel)
            {
                if (examLevel.Text.Equals(expExamLevel))
                {
                    ClickElement(examLevel);
                    break;
                }
            }
            Sleep(1000);
        }

        public void SelectSearch()
        {
            ClickElement(ShowDetailsButton);
            ClickElement(searchButton);
            Console.WriteLine(V4V5texts);
            Sleep(5000);
            ScreenCapture(driver);
        }
    }
}
