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
    class BillingCustomPage : BasePage
    {
        private IWebDriver driver;
        public BillingCustomPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PAGE NAVIGATION
        [FindsBy(How = How.Id, Using = "ctl00_HyperLink4")]
        private IWebElement linkReport;
        [FindsBy(How = How.CssSelector, Using = "img[title='Billing Report']")]
        private IWebElement iconExamSummary;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lnkCustom")]
        private IWebElement tabCustom;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lblTitle")]
        private IWebElement AssertLogo;

        //SINGLE CLIENT SELECTION
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$ddlClientsCstm")]
        private IWebElement singleClientSlectionDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlClientsCstm_DropDown']/div/ul/li")]
        private IList<IWebElement> singleClientSelection;

        //FROM DATE SELECTION
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_txtFromDate_popupButton")]
        private IWebElement dropDownFromDatePopUpButton;
        [FindsBy(How = How.XPath, Using = "//table[@id='ctl00_ContentPlaceHolder1_txtFromDate_calendar_Top']/tbody/tr/td")]
        private IList<IWebElement> firstOfMonth;


        //TO DATE SELECTION
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_txtToDate_popupButton")]
        private IWebElement dropDownToDatePopUpButton;
        [FindsBy(How = How.ClassName, Using = "rcSelected")]
        private IWebElement currentDate;

        //SEARCH
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnSearchCstm")]
        private IWebElement buttonSearch;


        //EXPORT DATA
        [FindsBy(How = How.XPath, Using = "//span[@id='ctl00_ContentPlaceHolder1_lblToatlCount2']")]
        private IWebElement resultsRecord;
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$btnExportCstm")]
        private IWebElement buttonExport;
        [FindsBy(How = How.Id, Using = "btnExport")]
        private IWebElement exportButton;
        [FindsBy(How = How.XPath, Using = "//input[@value='Excel']")]
        private IWebElement selectExportOption1;
        [FindsBy(How = How.XPath, Using = "//input[@value='CSV']")]
        private IWebElement selectExportOption2;
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$btnExportOptions")]
        private IWebElement checkBoxEmail;
        [FindsBy(How = How.Id, Using = "txtEmail")]
        private IWebElement textBoxEmail;
        [FindsBy(How = How.Id, Using = "btnSendMail")]
        private IWebElement sendMailButton;

        public void navigateToBillingCustomPage(string userName,
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
            ClickElement(iconExamSummary);
            Assert.IsTrue(AssertLogo.Displayed);
            ClickElement(tabCustom);
            Sleep(2000);
        }

        public void selectClientDropdown(String expClient1)
        {
            if (expClient1 == "random")
            {
                ClickElement(singleClientSlectionDropdown);
                Sleep(2000);
                Random r = new Random();
                int rInt = r.Next(1, singleClientSelection.Count);
                singleClientSelection[rInt].Click();
                Sleep(1000);
            }
            else
            {
                ClickElement(singleClientSlectionDropdown);
                Sleep(2000);
                foreach (IWebElement client in singleClientSelection)
                {
                    if (client.Text.Equals(expClient1))
                    {
                        ClickElement(client);
                        break;
                    }
                }
                Sleep(1000);
            }
        }

        public void selectFromDate(String expFromDate)
        {
            Sleep(1000);
            ClickElement(dropDownFromDatePopUpButton);
            Sleep(2000);
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

        public void selectToDate()
        {
            ClickElement(dropDownToDatePopUpButton);
            ClickElement(currentDate);
        }

        public void selectSearch(String expError, String email)
        {
            ClickElement(buttonSearch);
            Sleep(13000);
            ScreenCapture(driver);
            if (!resultsRecord.Text.Equals("0"))
            {
                ClickElement(buttonExport);
                Sleep(5000);
                driver.SwitchTo().Alert().Accept();
               
            }
            else
            {
                Console.WriteLine(expError);
            }
        }

        public IList<IWebElement> GetClient()
        {
            return singleClientSelection;
        }
    }
}
