using OpenQA.Selenium;
using Demo.Utilities;
using SeleniumExtras.PageObjects;
using System;

namespace Demo.PageObjects
{
    class DormantClientReportPage : BasePage
    {
        private IWebDriver driver;
        public DormantClientReportPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PAGE NAVIGATION
        [FindsBy(How = How.Id, Using = "ctl00_HyperLink4")]
        private IWebElement linkReport;
        [FindsBy(How = How.CssSelector, Using = "img[title='Dormant client report']")]
        private IWebElement iconDormantClientReport;
        [FindsBy(How = How.ClassName, Using = "header.customfont1")]
        private IWebElement AssertLogo;

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

        public void navigateToDormantClientReportpage(string reportTab, string LoginpageUrl)
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
                ClickElement(iconDormantClientReport);
                ReportLog("Passed", "Clicked on Dormant client icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Dormant client icon");
                throw ex;
            }
        }

        public void selectExport(String email, String reportTab)
        {
            ScreenCapture(driver);
            ClickElement(buttonExport);
            Sleep(5000);
            try
            {
                ClickElement(exportButton);
                ReportLog("Passed", "Clicked on export button");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on export button");
                throw ex;
            }
            Sleep(5000);
            ClickElement(checkBoxEmail);
            EnterValues(textBoxEmail, email);
            ClickElement(sendMailButton);
            Sleep(5000);
        }
    }
}
