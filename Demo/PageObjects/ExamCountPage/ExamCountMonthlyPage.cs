using OpenQA.Selenium;
using Demo.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace Demo.PageObjects
{
    class ExamCountMonthlyPage : BasePage
    {
        private IWebDriver driver;
        public ExamCountMonthlyPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PAGE NAVIGATION
        [FindsBy(How = How.Id, Using = "ctl00_HyperLink4")]
        private IWebElement linkReport;
        [FindsBy(How = How.CssSelector, Using = "img[title='Exam Count']")]
        private IWebElement iconExamCount;
        [FindsBy(How = How.ClassName, Using = ".header.customfont1")]
        private IWebElement AssertLogo;

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

        //CHECKBOX CLIENT SELECTION
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$ddlClients")]
        private IWebElement CheckBoxClientSelectionDropdown;
        [FindsBy(How = How.ClassName, Using = "rcbCheckAllItemsCheckBox")]
        private IWebElement unCheckAll;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlClients_DropDown']/div/ul/li")]
        private IList<IWebElement> selectCheckBoxClient;

        //SECURITY LEVEL DROPDOWN
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$ddlLevels")]
        private IWebElement dropDownSecurity;
        [FindsBy(How = How.ClassName, Using = "rcbCheckAllItemsCheckBox")]
        private IWebElement unCheckAll1;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlLevels_DropDown']/div/ul/li")]
        private IList<IWebElement> selectSecurity;

        //SEARCH
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnSearch")]
        private IWebElement buttonSearch;

        //EXPORT DATA
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnExportOptions")]
        private IWebElement buttonExport;
        [FindsBy(How = How.Id, Using = "chkSendMail")]
        private IWebElement checkBoxEmail;
        [FindsBy(How = How.Id, Using = "txtEmail")]
        private IWebElement textBoxEmail;
        [FindsBy(How = How.Id, Using = "btnSendMail")]
        private IWebElement sendMailButton;

        public void navigateToExamCountMonthly(string reportTab, string LoginpageUrl)
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
                ClickElement(iconExamCount);
                ReportLog("Passed", "Clicked on Exam-count icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Exam-count icon");
                throw ex;
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

        public void selectClientDropdown(int expClient)
        {
            Sleep(1000);
            if (expClient == 0)
            {
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
                    ReportLog("Passed", "Selected client uncheck-all");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't select client uncheck-all");
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
                        ReportLog("Passed", "Selected clients");
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

        public void selectSecurityDropdown(String expSecurity)
        {
            try
            {
                ClickElement(dropDownSecurity);
                ReportLog("Passed", "Clicked on security level dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't Click on security level dropdown");
                throw ex;
            }
            Sleep(1000);
            /*unCheckAll1.Click();*/
            try
            {
                foreach (IWebElement Security in selectSecurity)
                {
                    if (Security.Text.Equals(expSecurity))
                    {
                        ClickElement(Security);
                        break;
                    }
                }
                ReportLog("Passed", "Selected security level");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't Select security level");
                throw ex;
            }
            Sleep(1000);
        }

        public void selectSearch()
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
        }

        public void selectExport(String email)
        {
            Sleep(5000);
            try
            {
                ClickElement(buttonExport);
                ReportLog("Passed", "Clicked on export button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on export button");
                throw ex;
            }
            Sleep(3000);
            ClickElement(checkBoxEmail);
            EnterValues(textBoxEmail, email);
            ClickElement(sendMailButton);
            Sleep(5000);
        }












    }
}
