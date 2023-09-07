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
    class BillingMonthlyPage : BasePage
    {
        private IWebDriver driver;
        public BillingMonthlyPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PAGE NAVIGATION
        [FindsBy(How = How.Id, Using = "ctl00_HyperLink4")]
        private IWebElement linkReport;
        [FindsBy(How = How.CssSelector, Using = "img[title='Billing Report']")]
        private IWebElement iconBilling;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lblTitle")]
        private IWebElement AssertLogo;

        //SINGLE CLIENT SELECTION
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$ddlClients")]
        private IWebElement singleClientSlectionDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlClients_DropDown']/div/ul/li")]
        private IList<IWebElement> singleClientSelection;

        //MONTH DROPDOWN
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$ddlMonths")]
        private IWebElement dropDownMonth;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlMonths_DropDown']/div/ul/li")]
        private IList<IWebElement> selectMonth;

        //YEAR DROPDOWN
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$ddlYears1")]
        private IWebElement dropDownYear;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlYears1_DropDown']/div/ul/li")]
        private IList<IWebElement> selectYear;

        //SEARCH
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnSearch")]
        private IWebElement buttonSearch;

        //EXPORT DATA
        [FindsBy(How = How.XPath, Using = "//span[@id='ctl00_ContentPlaceHolder1_lblToatlCount1']")]
        private IWebElement resultsRecord;
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$btnExportOptions")]
        private IWebElement buttonExport;
        [FindsBy(How = How.Id, Using = "btnExport")]
        private IWebElement exportButton;
        [FindsBy(How = How.ClassName, Using = "rwCloseButton")]
        private IWebElement CloseExportMessageBox;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnInvoice1")]
        private IWebElement invoiceButton;
        /*[FindsBy(How = How.Id, Using = "chkSendMail")]
        private IWebElement checkBoxEmail;
        [FindsBy(How = How.Id, Using = "txtEmail")]
        private IWebElement textBoxEmail;
        [FindsBy(How = How.Id, Using = "btnSendMail")]
        private IWebElement sendMailButton;*/

        public void navigateToBillingMonthly(string userName,
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
                ClickElement(iconBilling);
                Assert.IsTrue(AssertLogo.Displayed);
        }

        public void ClickingMethod()
        {
            Sleep(1000);
            ClickElement(singleClientSlectionDropdown);
            Sleep(1000);
        }

        public void selectClientDropdown(String expClient)
        {
            ClickElement(singleClientSlectionDropdown);
            Sleep(1000);
            foreach (IWebElement client in singleClientSelection)
            {
                if (client.Text.Equals(expClient))
                {
                    ClickElement(client);
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
                if (month.GetAttribute("innerHTML").Equals(expMonth))
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

        public void selectSearch(String expError)
        {
            ClickElement(buttonSearch);
            Sleep(15000);
            ScreenCapture(driver);

            if (!resultsRecord.Text.Equals("0"))
            {
                ClickElement(buttonExport);
                Sleep(10000);
                ClickElement(exportButton);
                Sleep(1000);
                ClickElement(CloseExportMessageBox);
                /*ClickElement(invoiceButton);
                Sleep(1000);
                ClickElement(exportButton);*/
                /*ClickElement(checkBoxEmail);
                EnterValues(textBoxEmail, email);
                ClickElement(sendMailButton);*/
                Sleep(2000);
            }
            else
            {
                ClickElement(buttonExport);
                Sleep(4000);
                driver.SwitchTo().Alert().Accept();
                Console.WriteLine(expError);
            }
        }

        public IList<IWebElement> GetClient()
        {
            return singleClientSelection;
        }
    }
}
