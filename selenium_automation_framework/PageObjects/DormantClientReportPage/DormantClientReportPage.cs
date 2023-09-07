using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;

namespace PortalApplicationFramework.PageObjects
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

        public void navigateToDormantClientReportpage(string userName,
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
            ClickElement(iconDormantClientReport);
        }

        public void selectExport(String email)
        {
            ScreenCapture(driver);
            ClickElement(buttonExport);
            Sleep(5000);
            ClickElement(exportButton);
            ClickElement(checkBoxEmail);
            EnterValues(textBoxEmail, email);
            ClickElement(sendMailButton);
        }
    }
}
