using NUnit.Framework;
using OpenQA.Selenium;
using Demo.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace Demo.PageObjects
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

        public void navigateToBillingMonthly(string reportTab, string LoginpageUrl)
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
                ClickElement(iconBilling);
                ReportLog("Passed", "Clicked on Billing icon");
            }
            catch (Exception)
            {
                ReportLog("Failed", "Didn't click on Billing icon");
                driver.Navigate().GoToUrl(reportTab);
            }
            try
            {
                Assert.IsTrue(AssertLogo.Displayed);
                ReportLog("Passed", "Asserted");
            }
            catch (Exception)
            {
                ReportLog("Failed", "Didn't assert");
                driver.Navigate().GoToUrl(reportTab);
            }
        }

        public void ClickingMethod()
        {
            Sleep(1000);
            ClickElement(singleClientSlectionDropdown);
            try
            {
                ClickElement(singleClientSlectionDropdown);
                ReportLog("Passed", "Clicked on client selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on client selection dropdown");
                throw ex;
            }
            Sleep(1000);
        }

        public void selectClientDropdown(String expClient)
        {
            ClickElement(singleClientSlectionDropdown);
            try
            {
                ClickElement(singleClientSlectionDropdown);
                ReportLog("Passed", "Clicked on client selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on client selection dropdown");
                throw ex;
            }
            Sleep(1000);
            try
            {
                foreach (IWebElement client in singleClientSelection)
                {
                    if (client.Text.Equals(expClient))
                    {
                        ClickElement(client);
                        break;
                    }
                }
                ReportLog("Passed", "Selected client");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select client");
                throw ex;
            }
            Sleep(1000);
        }

        public void selectMonthDropdown(String expMonth)
        {
            try
            {
                ClickElement(dropDownMonth);
                ReportLog("Passed", "Clicked on month selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on month selection dropdown");
                throw ex;
            }
            Sleep(1000);
            try
            {
                foreach (IWebElement month in selectMonth)
                {
                    if (month.GetAttribute("innerHTML").Equals(expMonth))
                    {
                        ClickElement(month);
                        break;
                    }
                }
                ReportLog("Passed", "Selected month");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select month");
                throw ex;
            }
            Sleep(1000);
        }

        public void selectYearDropdown(String expYear)
        {
            try
            {
                ClickElement(dropDownYear);
                ReportLog("Passed", "Clicked on year selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on year selection dropdown");
                throw ex;
            }
            Sleep(1000);
            try
            {
                foreach (IWebElement year in selectYear)
                {
                    if (year.Text.Equals(expYear))
                    {
                        ClickElement(year);
                        break;
                    }
                }
                ReportLog("Passed", "Selected year");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select year");
                throw ex;
            }
            Sleep(1000);
        }

        public void selectSearch(String expError, string reportTab)
        {
            try
            {
                ClickElement(buttonSearch);
                ReportLog("Passed", "Clicked on search button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on search button");
                throw ex;
            }
            Sleep(15000);
            ScreenCapture(driver);
            try
            {
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
                ReportLog("Passed", "Exported the document");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't export the document");
                driver.Navigate().GoToUrl(reportTab);
            }
            /*if (!resultsRecord.Text.Equals("0"))
            {
                ClickElement(buttonExport);
                Sleep(10000);
                ClickElement(exportButton);
                Sleep(1000);
                ClickElement(CloseExportMessageBox);
                *//*ClickElement(invoiceButton);
                Sleep(1000);
                ClickElement(exportButton);*/
                /*ClickElement(checkBoxEmail);
                EnterValues(textBoxEmail, email);
                ClickElement(sendMailButton);*//*
                Sleep(2000);
            }
            else
            {
                ClickElement(buttonExport);
                Sleep(4000);
                driver.SwitchTo().Alert().Accept();
                Console.WriteLine(expError);
            }*/
        }

        public IList<IWebElement> GetClient()
        {
            return singleClientSelection;
        }
    }
}
