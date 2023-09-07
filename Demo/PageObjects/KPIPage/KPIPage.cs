using NUnit.Framework;
using OpenQA.Selenium;
using Demo.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace Demo.PageObjects
{
    class KPIPage : BasePage
    {
        private IWebDriver driver;
        public KPIPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PAGE NAVIGATION
        [FindsBy(How = How.Id, Using = "ctl00_HyperLink4")]
        private IWebElement linkReport;
        [FindsBy(How = How.CssSelector, Using = "img[title='KPI']")]
        private IWebElement iconKPI;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lblTitle")]
        private IWebElement AssertLogo;

        //SINGLE CLIENT SELECTION
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$ddlClients")]
        private IWebElement singleClientSlectionDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlClients_DropDown']/div/ul/li")]
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
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnSearch")]
        private IWebElement buttonSearch;

        //EXPORT DATA
        [FindsBy(How = How.XPath, Using = "//span[text()='No records available']")]
        private IWebElement labelErrorMessage;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnExportOptions")]
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
        [FindsBy(How = How.XPath, Using = "//table[@id='ctl00_ContentPlaceHolder1_gvExamsList_ctl00']//tr")]
        private IList<IWebElement> demo;

        public void navigateToKPIpage(string reportTab, string LoginpageUrl)
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
                ClickElement(iconKPI);
                ReportLog("Passed", "Clicked on KPI icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on KPI icon");
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
        }

        public void selectClientDropdown(String expClient1)
        {
            if (expClient1 == "random")
            {
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
                Sleep(2000);
                Random r = new Random();
                int rInt = r.Next(1, singleClientSelection.Count);
                try
                {
                    singleClientSelection[rInt].Click();
                    ReportLog("Passed", "selected clients");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't select clients");
                    throw ex;
                }
                Sleep(1000);
            }
            else
            {
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
                Sleep(2000);
                try
                {
                    foreach (IWebElement client in singleClientSelection)
                    {
                        if (client.Text.Equals(expClient1))
                        {
                            ClickElement(client);
                            break;
                        }
                    }
                    ReportLog("Passed", "selected clients");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't select clients");
                    throw ex;
                }
                Sleep(1000);
            }
        }

        public void selectFromDate(String expFromDate)
        {
            try
            {
                ClickElement(dropDownFromDatePopUpButton);
                ReportLog("Passed", "Clicked on from-date selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on from-date selection dropdown");
                throw ex;
            }
            Sleep(2000);
            try
            {
                foreach (IWebElement first in firstOfMonth)
                {
                    if (first.Text.Equals(expFromDate))
                    {
                        ClickElement(first);
                        break;
                    }
                }
                ReportLog("Passed", "selected from-date");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select from-date");
                throw ex;
            }
            Sleep(1000);
        }

        public void selectToDate()
        {
            try
            {
                ClickElement(dropDownToDatePopUpButton);
                ReportLog("Passed", "Clicked on to-date selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on to-date selection dropdown");
                throw ex;
            }
            try
            {
                ClickElement(currentDate);
                ReportLog("Passed", "selected current date");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select cureent date");
                throw ex;
            }
            ClickElement(dropDownToDatePopUpButton);
        }

        public void selectSearch(String expError, String email, String reportTab)
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
            Sleep(1000);
            ScreenCapture(driver);
            try
            {
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
                ReportLog("Passed", "Exported the document");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't export the document");
                throw ex;
            }
            /*if (demo.Count > 2)
            {
                ClickElement(buttonExport);
                Thread.Sleep(3000);
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
            }*/
        }
    }
}
