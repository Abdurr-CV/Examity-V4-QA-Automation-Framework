using OpenQA.Selenium;
using Demo.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace Demo.PageObjects
{
    class RevenueYTDGraphPage : BasePage
    {
        private IWebDriver driver;
        public RevenueYTDGraphPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PAGE NAVIGATION
        [FindsBy(How = How.Id, Using = "ctl00_HyperLink4")]
        private IWebElement linkReport;
        [FindsBy(How = How.CssSelector, Using = "img[title='Revenue YTD Report']")]
        private IWebElement iconRevenueYTDReport;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lnkTransactions")]
        private IWebElement tabRevenueYTDGraph;

        //CHECKBOX CLIENT SELECTION
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddlClients_Arrow")]
        private IWebElement CheckBoxClientSelectionDropdown;
        [FindsBy(How = How.ClassName, Using = "rcbCheckAllItemsCheckBox")]
        private IWebElement unCheckAll;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlClients_DropDown']/div/ul/li")]
        private IList<IWebElement> selectCheckBoxClient;

        //YEAR DROPDOWN
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddYears_Arrow")]
        private IWebElement dropDownYear;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddYears_DropDown']/div/ul/li")]
        private IList<IWebElement> selectYear;

        //SEARCH
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

        public void navigateToRevenueYTDGraphpage(string reportTab, string LoginpageUrl)
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
                ClickElement(iconRevenueYTDReport);
                ReportLog("Passed", "Clicked on Revenue YTD icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Revenue YTD icon");
                throw ex;
            }
            try
            {
                ClickElement(tabRevenueYTDGraph);
                ReportLog("Passed", "Custom tab selected");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select custom tab");
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
                    ReportLog("Passed", "Clicked on check-all client");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on check-all client");
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

        public void selectSearch(String email, String reportTab)
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
            ClickElement(buttonExport);
            Sleep(5000);
            try
            {
                ClickElement(exportButton);
                ReportLog("Passed", "Clicked on button export");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on button export");
                throw ex;
            }
            Sleep(5000);
            ClickElement(exportButton);
            try
            {
                ClickElement(exportButton);
                ReportLog("Passed", "Clicked on button export");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on button export");
                throw ex;
            }
            ClickElement(checkBoxEmail);
            EnterValues(textBoxEmail, email);
            ClickElement(sendMailButton);
        }
    }
}
