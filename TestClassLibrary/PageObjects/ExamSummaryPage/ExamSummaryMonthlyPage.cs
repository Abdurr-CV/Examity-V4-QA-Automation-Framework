using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace PortalApplicationFramework.PageObjects
{
    class ExamSummaryMonthlyPage : BasePage
    {
        private IWebDriver driver;
        public ExamSummaryMonthlyPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PAGE NAVIGATION
        [FindsBy(How = How.Id, Using = "ctl00_HyperLink4")]
        private IWebElement linkReport;
        [FindsBy(How = How.CssSelector, Using = "img[title='Exam Summary']")]
        private IWebElement iconExamSummary;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lnkMonth")]
        private IWebElement tabMonthly;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lblTitle")]
        private IWebElement AssertLogo;

        //MONTH DROPDOWN
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$ddlMonths")]
        private IWebElement dropDownMonth;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlMonths_DropDown']/div/ul/li")]
        private IList<IWebElement> selectMonth;

        //YEAR DROPDOWN
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$ddlYear1")]
        private IWebElement dropDownYear;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlYear1_DropDown']/div/ul/li")]
        private IList<IWebElement> selectYear;

        //CHECKBOX CLIENT SELECTION
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$ddlClients")]
        private IWebElement CheckBoxClientSelectionDropdown;
        [FindsBy(How = How.ClassName, Using = "rcbCheckAllItemsCheckBox")]
        private IWebElement CheckAllClient;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlClients_DropDown']/div/ul/li")]
        private IList<IWebElement> selectCheckBoxClient;

        //STATUS DROPDOWN
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$ddlTransactionStatus")]
        private IWebElement dropDownStatus;
        /*[FindsBy(How = How.ClassName, Using = "rcbCheckAllItemsCheckBox")]
        private IWebElement unCheckAll;*/
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlTransactionStatus4_DropDown']/div/ul/li")]
        private IList<IWebElement> selectStatus;

        //SEARCH
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$btnSearch")]
        private IWebElement buttonSearch;

        //EXPORT DATA
        [FindsBy(How = How.XPath, Using = "//span[@id='ctl00_ContentPlaceHolder1_lblToatlCount1']")]
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

        public void navigateToExamSummary1page(string reportTab, string LoginpageUrl)
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
            try
            {
                ClickElement(tabMonthly);
                ReportLog("Passed", "Clicked on monthly tab");
            }
            catch (Exception)
            {
                ReportLog("Failed", "Didn't click on monthly tab");
                driver.Navigate().GoToUrl(reportTab);
            }
        }

        public void selectMonthDropdown(String expMonth)
        {
            Sleep(3000);
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
                    if (month.Text.Equals(expMonth))
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

        public void selectStatusDropdown(String expStatus)
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
            /*unCheckAll.Click();*/
            try
            {
                foreach (IWebElement Status in selectStatus)
                {
                    if (Status.Text.Equals(expStatus))
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

        public void selectSearch(String expError, String email)
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
                throw ex;
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
