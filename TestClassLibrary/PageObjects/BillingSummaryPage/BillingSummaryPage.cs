using OpenQA.Selenium;
using PortalApplicationFramework.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace PortalApplicationFramework.PageObjects
{
    class BillingSummaryPage : BasePage
    {
        private IWebDriver driver;
        public BillingSummaryPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PAGE NAVIGATION
        [FindsBy(How = How.Id, Using = "ctl00_HyperLink4")]
        private IWebElement linkReport;
        [FindsBy(How = How.CssSelector, Using = "img[title='Billing Summary']")]
        private IWebElement iconBillingSummary;
        [FindsBy(How = How.ClassName, Using = ".header.customfont1")]
        private IWebElement AssertLogo;

        //CHECKBOX CLIENT SELECTION
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddlClients_Arrow")]
        private IWebElement CheckBoxClientSelectionDropdown;
        [FindsBy(How = How.ClassName, Using = "rcbCheckAllItemsCheckBox")]
        private IWebElement unCheckAll;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlClients_DropDown']/div/ul/li")]
        private IList<IWebElement> selectCheckBoxClient;

        //MONTH DROPDOWN
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddlMonths_Arrow")]
        private IWebElement dropDownMonth;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlMonths_DropDown']/div/ul/li")]
        private IList<IWebElement> selectMonth;

        //YEAR DROPDOWN
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddYears_Arrow")]
        private IWebElement dropDownYear;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddYears_DropDown']/div/ul/li")]
        private IList<IWebElement> selectYear;

        //SEARCH
        [FindsBy(How = How.XPath, Using = "//span[@id='ctl00_ContentPlaceHolder1_lblToatlCount']")]
        private IWebElement resultsRecord;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnSearch")]
        private IWebElement buttonSearch;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnExportOptions")]
        private IWebElement buttonExport;
        [FindsBy(How = How.Id, Using = "btnExport")]
        private IWebElement exportButton;
        [FindsBy(How = How.Id, Using = "chkSendMail")]
        private IWebElement checkBoxEmail;
        [FindsBy(How = How.Id, Using = "txtEmail")]
        private IWebElement textBoxEmail;
        [FindsBy(How = How.Id, Using = "btnSendMail")]
        private IWebElement sendMailButton;

        public void navigateToBillingSummarypage(string reportTab, string LoginpageUrl)
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
                ClickElement(iconBillingSummary);
                ReportLog("Passed", "Clicked on Billing Summary icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Billing Summary icon");
                throw ex;
            }
            Sleep(5000);
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
            Sleep(8000);
            ScreenCapture(driver);
            try
            {
                if (!resultsRecord.Text.Equals("0"))
                {
                    ClickElement(buttonExport);
                    Sleep(5000);
                    ClickElement(exportButton);
                    Sleep(5000);
                    ClickElement(checkBoxEmail);
                    EnterValues(textBoxEmail, email);
                    ClickElement(sendMailButton);
                }
                else
                {
                    Console.WriteLine(expError);
                }
                ReportLog("Passed", "Exported document");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't export document");
                driver.Navigate().GoToUrl(reportTab);
            }
            /*if (!resultsRecord.Text.Equals("0"))
            {
                ClickElement(buttonExport);
                Sleep(5000);
                ClickElement(exportButton);
                Sleep(5000);
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
