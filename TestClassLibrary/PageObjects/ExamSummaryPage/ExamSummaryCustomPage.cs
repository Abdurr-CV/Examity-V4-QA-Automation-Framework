using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace PortalApplicationFramework.PageObjects
{
    class ExamSummaryCustomPage : BasePage
    {
        private IWebDriver driver;
        public ExamSummaryCustomPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PAGE NAVIGATION
        [FindsBy(How = How.Id, Using = "ctl00_HyperLink4")]
        private IWebElement linkReport;
        [FindsBy(How = How.CssSelector, Using = "img[title='Exam Summary']")]
        private IWebElement iconExamSummary;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lblTitle")]
        private IWebElement AssertLogo;

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

        //CHECKBOX CLIENT SELECTION
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$ddlClientsCstm")]
        private IWebElement CheckBoxClientSelectionDropdown;
        [FindsBy(How = How.ClassName, Using = "rcbCheckAllItemsCheckBox")]
        private IWebElement CheckAllClient;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlClientsCstm_DropDown']/div/ul/li")]
        private IList<IWebElement> selectCheckBoxClient;

        //STATUS SELECTION
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$ddlTransactionStatus4")]
        private IWebElement dropDownStatus;
        [FindsBy(How = How.ClassName, Using = "rcbCheckAllItemsCheckBox")]
        private IWebElement unCheckAll;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlTransactionStatus4_DropDown']/div/ul/li")]
        private IList<IWebElement> selectStatus;

        //SEARCH
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnsearch4")]
        private IWebElement buttonSearch;

        //EXPORT DATA
        [FindsBy(How = How.XPath, Using = "//span[@id='ctl00_ContentPlaceHolder1_lblToatlCount2']")]
        private IWebElement resultsRecord;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_ImageButton2")]
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

        public void navigateToExamSummarypage(string reportTab, string LoginpageUrl)
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
                ClickElement(iconExamSummary);
                ReportLog("Passed", "Clicked on Exam-Summary icon");
            }
            catch (Exception)
            {
                ReportLog("Failed", "Didn't click on Exam-Summary icon");
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
        }

        public void selectClientDropdown(int expClient)
        {
            Sleep(1000);
            if (expClient == 0)
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
                try
                {
                    ClickElement(CheckAllClient);
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

        public void selectStatuses(String expSelection)
        {
            try
            {
                ClickElement(dropDownStatus);
                ReportLog("Passed", "Clicked on status dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on status dropdown");
                throw ex;
            }
            Sleep(1000);
            try
            {
                unCheckAll.Click();
                ReportLog("Passed", "Clicked on uncheck-all");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on uncheck-all");
                throw ex;
            }
            Sleep(1000);
            try
            {
                foreach (IWebElement Status in selectStatus)
                {
                    if (Status.Text.Equals(expSelection))
                    {
                        ClickElement(Status);
                        break;
                    }
                }
                ReportLog("Passed", "selected status");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select status");
                throw ex;
            }
            Sleep(1000);
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
                if (!resultsRecord.Text.Equals("0"))
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
                driver.Navigate().GoToUrl(reportTab);
            }
            /*if (!resultsRecord.Text.Equals("0"))
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
