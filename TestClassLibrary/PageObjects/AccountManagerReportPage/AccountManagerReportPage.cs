using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace PortalApplicationFramework.PageObjects
{
    class AccountManagerReportPage : BasePage
    {
        private IWebDriver driver;
        public AccountManagerReportPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PAGE NAVIGATION
        [FindsBy(How = How.Id, Using = "ctl00_HyperLink4")]
        private IWebElement linkReport;
        [FindsBy(How = How.XPath, Using = "//div[@id='ui-accordion-accordion-panel-3']/div/img[@title='Account Manager Report']")]
        private IWebElement iconAccountManagerReport;

        //ACCOUNT MANAGER SELECTION
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_rcbAccountManagers_Arrow")]
        private IWebElement DropdownAccountManager;
        [FindsBy(How = How.ClassName, Using = "rcbCheckAllItemsCheckBox")]
        private IWebElement UncheckAll;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_rcbAccountManagers_DropDown']/div/ul/li")]
        private IList<IWebElement> SelectAccountManager;

        //YEAR SELECTION
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddYears_Arrow")]
        private IWebElement dropDownYearPopUpButton;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddYears_DropDown']/div/ul/li")]
        private IList<IWebElement> SelectYear;

        //FROM MONTH SELECTION
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddlFromMonths_Arrow")]
        private IWebElement dropDownFromMonthPopUpButton;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlFromMonths_DropDown']/div/ul/li")]
        private IList<IWebElement> SelectFromMonth;

        //TO MONTH SELECTION
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_rcbTomonth_Arrow")]
        private IWebElement dropDownToMonthPopUpButton;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_rcbTomonth_DropDown']/div/ul/li")]
        private IList<IWebElement> SelectToMonth;

        //GET REPORT
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnSearch")]
        private IWebElement SelectGetReport;


        public void navigateToAccountManagerReportpage(string reportTab, string LoginpageUrl)
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
                ClickElement(iconAccountManagerReport);
                ReportLog("Passed", "Clicked on client icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on client icon");
                throw ex;
            }
            try
            {
                Assert.IsTrue(DropdownAccountManager.Displayed);
                ReportLog("Passed", "Asserted");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert");
                throw ex;
            }
        }

        public void selectAccountManagerDropdown(int expAccManager)
        {
            Sleep(1000);
            if (expAccManager == 0)
            {
                try
                {
                    ReportLog("Passed", "Clicked on check-all account managers");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on check-all account managers");
                    throw ex;
                }
            }
            else
            {
                try
                {
                    ClickElement(DropdownAccountManager);
                    ReportLog("Passed", "Clicked on Account Manager Dropdown");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on Account Manager Dropdown");
                    throw ex;
                }
                Sleep(2000);
                try
                {
                    ClickElement(UncheckAll);
                    ReportLog("Passed", "Clicked on Uncheck All button");

                }
                catch (Exception ex) 
                {
                    ReportLog("Failed", "Didn't click on Uncheck All button");
                    throw ex;
                }
                Sleep(2000);
                for (int i = 0; i < expAccManager; i++)
                {
                    Sleep(2000);
                    Random r = new Random();
                    int rInt = r.Next(1, SelectAccountManager.Count);
                    try
                    {
                        SelectAccountManager[rInt].Click();
                        ReportLog("Passed", "Selected Account managers");

                    }
                    catch (Exception ex)
                    {
                        ReportLog("Failed", "Didn't selected Account managers");
                        throw ex;
                    }
                }
                Sleep(2000);
            }
        }

        public void selectYearDropdown(String expYear)
        {
            try
            {
                ClickElement(dropDownYearPopUpButton);
                ReportLog("Passed", "Clicked on the year selection dropdown");

            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the year selection dropdown");
                throw ex;
            }
            Sleep(1000);
            try
            {
                ClickElement(dropDownYearPopUpButton);
                ReportLog("Passed", "Clicked on the year selection dropdown");

            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on the year selection dropdown");
                throw ex;
            }
            Sleep(1000);
            try
            {
                foreach (IWebElement Year in SelectYear)
                {
                    if (Year.Text.Equals(expYear))
                    {
                        ClickElement(Year);
                        break;
                    }
                }
                ReportLog("Passed", "selected year");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select year");
                throw ex;
            }
            Sleep(1000);
        }

        public void selectFromMonthDropdown(String expFromMonth)
        {
            try
            {
                ClickElement(dropDownFromMonthPopUpButton);
                ReportLog("Passed", "Clicked on from month dropdown");

            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on from month dropdown");
                throw ex;
            }
            Sleep(1000);
            try
            {
                foreach (IWebElement FromMonth in SelectFromMonth)
                {
                    if (FromMonth.Text.Equals(expFromMonth))
                    {
                        ClickElement(FromMonth);
                        break;
                    }
                }
                ReportLog("Passed", "selected from month");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select from month");
                throw ex;
            }
            Sleep(1000);
        }

        public void selectToMonthDropdown(String expToMonth)
        {
            try
            {
                ClickElement(dropDownToMonthPopUpButton);
                ReportLog("Passed", "Clicked on to month dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on to month dropdown");
                throw ex;
            }
            Sleep(1000);
            try
            {
                foreach (IWebElement ToMonth in SelectToMonth)
                {
                    if (ToMonth.Text.Equals(expToMonth))
                    {
                        ClickElement(ToMonth);
                        break;
                    }
                }
                ReportLog("Passed", "selected to month");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't selected to month");
                throw ex;
            }
            Sleep(1000);
        }

        public void selectGetReport(string reportTab)
        {
            try
            {
                ClickElement(SelectGetReport);
                ReportLog("Passed", "Clicked on get report");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on get report");
                throw ex;
            }
            Sleep(5000);
            ScreenCapture(driver);
        }
    }
}
