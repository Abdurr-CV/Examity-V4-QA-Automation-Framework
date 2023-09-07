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
    class ExamSnapshotPage : BasePage
    {
        private IWebDriver driver;
        public ExamSnapshotPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PAGE NAVIGATION
        [FindsBy(How = How.Id, Using = "ctl00_HyperLink4")]
        private IWebElement linkReport;
        [FindsBy(How = How.CssSelector, Using = "img[title='Exams snapshot']")]
        private IWebElement iconExamSnapshot;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lblTitle")]
        private IWebElement AssertLogo;

        //CHECKBOX CLIENT SELECTION
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$ddlClients")]
        private IWebElement CheckBoxClientSelectionDropdown;
        [FindsBy(How = How.ClassName, Using = "rcbCheckAllItemsCheckBox")]
        private IWebElement CheckAllClient;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlClients_DropDown']/div/ul/li")]
        private IList<IWebElement> selectCheckBoxClient;

        //SELECT ACCOUNT MANAGER
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$rcbAccountManagers")]
        private IWebElement dropDownAccountManager;
        [FindsBy(How = How.ClassName, Using = "rcbCheckAllItemsCheckBox")]
        private IWebElement unCheckAll;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_rcbAccountManagers_DropDown']/div/ul/li")]
        private IList<IWebElement> selectAccountMAnager;

        //COURSE DROPDOWN
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddlCourses_Arrow")]
        private IWebElement dropDownCourses;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlCourses_DropDown']//input[@class='rcbCheckAllItemsCheckBox']")]
        private IWebElement selectAllCourses;

        //FROM DATE SELECTION
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_txtFromDate_popupButton")]
        private IWebElement dropDownFromDatePopUpButton;
        [FindsBy(How = How.XPath, Using = "//table[@id='ctl00_ContentPlaceHolder1_txtFromDate_calendar_Top']/tbody/tr/td")]
        private IList<IWebElement> firstOfMonth;

        //TO DATE SELECTION
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_txtToDate_popupButton")]
        private IWebElement dropDownToDatePopUpButton;
        [FindsBy(How = How.XPath, Using = "//table[@id='ctl00_ContentPlaceHolder1_txtToDate_calendar_Top']/tbody/tr/td")]
        private IList<IWebElement> currentDateOfMonth;

        //SEARCH
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnSearch")]
        private IWebElement buttonSearch;

        //EXPORT DATA
        [FindsBy(How = How.XPath, Using = "//span[@id='ctl00_ContentPlaceHolder1_lblToatlCount']")]
        private IWebElement resultsRecord;
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$btnExportOptions")]
        private IWebElement buttonExport;
        [FindsBy(How = How.Id, Using = "btnExport")]
        private IWebElement exportButton;
        [FindsBy(How = How.XPath, Using = "//input[@value='CSV']")]
        private IWebElement selectExportOption2;
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$windowExportOptions$C$chkSendMail")]
        private IWebElement checkBoxEmail;
        [FindsBy(How = How.Id, Using = "txtEmail")]
        private IWebElement textBoxEmail;
        [FindsBy(How = How.Id, Using = "btnSendMail")]
        private IWebElement sendMailButton;

        public void navigateToExamSnapshotpage(string userName,
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
            ClickElement(iconExamSnapshot);
            Assert.IsTrue(AssertLogo.Displayed);
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

        public void selectAccountManagerDropdown(String expAccountManager)
        {
            ClickElement(dropDownAccountManager);
            Sleep(1000);
            foreach (IWebElement accountManager in selectAccountMAnager)
            {
                if (accountManager.Text.Equals(expAccountManager))
                {
                    ClickElement(accountManager);
                    break;
                }
            }
            Sleep(1000);
        }

        /*public void selectCourseDropdown()
        {
            ClickElement(dropDownCourses);
            Sleep(1000);
            ClickElement(dropDownCourses);
            Sleep(1000);
            ClickElement(selectAllCourses);
        }*/

        public void selectFromDate(String expFromDate)
        {
            ClickElement(dropDownFromDatePopUpButton);
            Sleep(1000);
            foreach (IWebElement first in firstOfMonth)
            {
                if (first.Text.Equals(expFromDate))
                {
                    ClickElement(first);
                    break;
                }
            }
            Sleep(1000);
        }

        public void selectToDate(String expToDate)
        {
            ClickElement(dropDownToDatePopUpButton);
            Sleep(1000);
            foreach (IWebElement currentDate in currentDateOfMonth)
            {
                if (currentDate.Text.Equals(expToDate))
                {
                    ClickElement(currentDate);
                    break;
                }
            }
            Sleep(1000);
        }

        public void selectSearch(String expError)
        {
            ClickElement(buttonSearch);
            Sleep(5000);
            ScreenCapture(driver);

            if (!resultsRecord.Text.Equals("0"))
            {
                ClickElement(buttonExport);
                Sleep(3000);
                ClickElement(exportButton);
                ClickElement(selectExportOption2);
                ClickElement(exportButton);
            }
            else
            {
                Console.WriteLine(expError);
            }
        }
    }
}
