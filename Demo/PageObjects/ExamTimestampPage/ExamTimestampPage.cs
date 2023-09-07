using NUnit.Framework;
using OpenQA.Selenium;
using Demo.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace Demo.PageObjects
{
    class ExamTimestampPage : BasePage
    {
        private IWebDriver driver;
        public ExamTimestampPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PAGE NAVIGATION
        [FindsBy(How = How.Id, Using = "ctl00_HyperLink4")]
        private IWebElement linkReport;
        [FindsBy(How = How.CssSelector, Using = "img[title='Timestamp']")]
        private IWebElement iconExamTimestamp;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lblTitle")]
        private IWebElement AssertLogo;

        //CHECKBOX CLIENT SELECTION
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$ddlClients")]
        private IWebElement CheckBoxClientSelectionDropdown;
        [FindsBy(How = How.ClassName, Using = "rcbCheckAllItemsCheckBox")]
        private IWebElement unCheckAll;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlClients_DropDown']/div/ul/li")]
        private IList<IWebElement> selectCheckBoxClient;

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

        [FindsBy(How = How.Id, Using = "btnExport")]
        private IWebElement exportButton;
        [FindsBy(How = How.XPath, Using = "//input[@value='Excel']")]
        private IWebElement selectExportOption1;
        [FindsBy(How = How.XPath, Using = "//input[@value='CSV']")]
        private IWebElement selectExportOption2;
        

        //SEARCH
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnSearch")]
        private IWebElement buttonSearch;
        [FindsBy(How = How.XPath, Using = "//span[text()='No records available']")]
        private IWebElement labelErrorMessage;

        //EXPORT DATA
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnExportOptions")]
        private IWebElement buttonExport;
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$windowExportOptions$C$chkSendMail")]
        private IWebElement checkBoxEmail;
        [FindsBy(How = How.Id, Using = "txtEmail")]
        private IWebElement textBoxEmail;
        [FindsBy(How = How.Id, Using = "btnSendMail")]
        private IWebElement sendMailButton;
        [FindsBy(How = How.XPath, Using = "//table[@id='ctl00_ContentPlaceHolder1_gvExamsList_ctl00']//tr")]
        private IList<IWebElement> demo;

        public void navigateToExamTimestamppage(string reportTab, string LoginpageUrl)
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
                ClickElement(iconExamTimestamp);
                ReportLog("Passed", "Clicked on Exam-timestamp icon");
            }
            catch (Exception)
            {
                ReportLog("Failed", "Didn't click on Exam-timestamp icon");
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
            Sleep(1000);
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
            Sleep(5000);
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
            }*/
        }
    }
}
