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
    class ExamCountViewDetailsPage : BasePage
    {
        private IWebDriver driver;
        public ExamCountViewDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PAGE NAVIGATION
        [FindsBy(How = How.Id, Using = "ctl00_HyperLink4")]
        private IWebElement linkReport;
        [FindsBy(How = How.CssSelector, Using = "img[title='Exam Count']")]
        private IWebElement iconExamCount;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lnkSchedulesDetails")]
        private IWebElement tabViewDetails;
        [FindsBy(How = How.ClassName, Using = ".header.customfont1")]
        private IWebElement AssertLogo;

        //CHECKBOX CLIENT SELECTION
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$ddlClients")]
        private IWebElement CheckBoxClientSelectionDropdown;
        [FindsBy(How = How.ClassName, Using = "rcbCheckAllItemsCheckBox")]
        private IWebElement CheckAllClient;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlClients_DropDown']/div/ul/li")]
        private IList<IWebElement> selectCheckBoxClient;

        //SECURITY LEVEL DROPDOWN
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$ddlLevels")]
        private IWebElement dropDownSecurity;
        [FindsBy(How = How.ClassName, Using = "rcbCheckAllItemsCheckBox")]
        private IWebElement unCheckAll;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlLevels_DropDown']/div/ul/li")]
        private IList<IWebElement> selectSecurityLevel;

        //MONTH DROPDOWN
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$ddlMonths")]
        private IWebElement dropDownMonth;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlMonths_DropDown']/div/ul/li")]
        private IList<IWebElement> selectMonth;

        //YEAR DROPDOWN
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$ddYears1")]
        private IWebElement dropDownYear;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddYears1_DropDown']/div/ul/li")]
        private IList<IWebElement> selectYear;

        //SEARCH
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$btnSearch")]
        private IWebElement buttonSearch;
        [FindsBy(How = How.XPath, Using = "//span[text()='No Exams scheduled']")]
        private IWebElement labelErrorMessage;

        //EXPORT DATA
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$btnExportOptions1")]
        private IWebElement buttonExport;
        [FindsBy(How = How.XPath, Using = "//input[@value='CSV']")]
        private IWebElement selectExportOption2;
        [FindsBy(How = How.Id, Using = "btnExport")]
        private IWebElement exportButton;
        [FindsBy(How = How.Id, Using = "chkSendMail")]
        private IWebElement checkBoxEmail;
        [FindsBy(How = How.Id, Using = "txtEmail")]
        private IWebElement textBoxEmail;
        [FindsBy(How = How.Id, Using = "btnSendMail")]
        private IWebElement sendMailButton;
        [FindsBy(How = How.XPath, Using = "//table[@id='ctl00_ContentPlaceHolder1_gvExamsList_ctl00']//tr")]
        private IList<IWebElement> demo;

        public void navigateToExamCountViewDetails1page(string userName,
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
            ClickElement(iconExamCount);
            ClickElement(tabViewDetails);
        }

        public void selectClientDropdown(int expClient)
        {
            Sleep(1000);
            if (expClient == 0)
            {
                ClickElement(CheckBoxClientSelectionDropdown);
                ClickElement(CheckAllClient);
            }
            else
            {
                ClickElement(CheckBoxClientSelectionDropdown);
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

        public void selectSecurityLevelDropdown(String expSecurity)
        {
            ClickElement(dropDownSecurity);
            Sleep(1000);
            foreach (IWebElement Security in selectSecurityLevel)
            {
                if (Security.Text.Equals(expSecurity))
                {
                    ClickElement(Security);
                    break;
                }
            }
            Sleep(1000);
        }

        public void selectMonthDropdown(String expMonth)
        {
            ClickElement(dropDownMonth);
            Sleep(1000);
            foreach (IWebElement month in selectMonth)
            {
                if (month.Text.Equals(expMonth))
                {
                    ClickElement(month);
                    break;
                }
            }
            Sleep(1000);
        }

        public void selectYearDropdown(String expYear)
        {
            ClickElement(dropDownYear);
            Sleep(1000);
            foreach (IWebElement year in selectYear)
            {
                if (year.Text.Equals(expYear))
                {
                    ClickElement(year);
                    break;
                }
            }
            Sleep(1000);
        }

        public void selectSearch(String expError, String email)
        {
            ClickElement(buttonSearch);
            Sleep(5000);
            ScreenCapture(driver);

            if (demo.Count > 2)
            {
                ClickElement(buttonExport);
                Sleep(3000);
                ClickElement(exportButton);
                ClickElement(selectExportOption2);
                ClickElement(exportButton);
                ClickElement(checkBoxEmail);
                EnterValues(textBoxEmail, email);
                ClickElement(sendMailButton);
            }
            else
            {
                Console.WriteLine(expError);
            }
        }
    }
}
