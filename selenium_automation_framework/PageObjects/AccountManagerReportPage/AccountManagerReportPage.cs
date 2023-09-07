using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;

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

        public void navigateToAccountManagerReportpage(string userName,
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
                Sleep(1000);
                ClickElement(iconAccountManagerReport);
                Assert.IsTrue(DropdownAccountManager.Displayed);
        }

        public void selectAccountManagerDropdown(int expAccManager)
        {
            Sleep(1000);
            if (expAccManager == 0)
            {
            }
            else
            {
                ClickElement(DropdownAccountManager);
                Sleep(2000);
                ClickElement(UncheckAll);
                Sleep(2000);
                for (int i = 0; i < expAccManager; i++)
                {
                    Sleep(2000);
                    Random r = new Random();
                    int rInt = r.Next(1, SelectAccountManager.Count);
                    SelectAccountManager[rInt].Click();
                }
                Sleep(2000);
            }
        }

        public void selectYearDropdown(String expYear)
        {
            ClickElement(dropDownYearPopUpButton);
            Sleep(1000);
            ClickElement(dropDownYearPopUpButton);
            Sleep(1000);
            foreach (IWebElement Year in SelectYear)
            {
                if (Year.Text.Equals(expYear))
                {
                    ClickElement(Year);
                    break;
                }
            }
            Sleep(1000);
        }

        public void selectFromMonthDropdown(String expFromMonth)
        {
            ClickElement(dropDownFromMonthPopUpButton);
            Sleep(1000);
            foreach (IWebElement FromMonth in SelectFromMonth)
            {
                if (FromMonth.Text.Equals(expFromMonth))
                {
                    ClickElement(FromMonth);
                    break;
                }
            }
            Sleep(1000);
        }

        public void selectToMonthDropdown(String expToMonth)
        {
            ClickElement(dropDownToMonthPopUpButton);
            Sleep(1000);
            foreach (IWebElement ToMonth in SelectToMonth)
            {
                if (ToMonth.Text.Equals(expToMonth))
                {
                    ClickElement(ToMonth);
                    break;
                }
            }
            Sleep(1000);
        }

        public void selectGetReport()
        {
            ClickElement(SelectGetReport);
            Sleep(5000);
            ScreenCapture(driver);
        }
    }
}
