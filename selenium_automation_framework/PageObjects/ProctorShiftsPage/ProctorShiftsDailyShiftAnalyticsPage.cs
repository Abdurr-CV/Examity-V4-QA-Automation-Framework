using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.Utilities;
using SeleniumExtras.PageObjects;

namespace PortalApplicationFramework.PageObjects
{
    class ProctorShiftsDailyShiftAnalyticsPage : BasePage
    {
        private IWebDriver driver;
        public ProctorShiftsDailyShiftAnalyticsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PAGE NAVIGATION
        [FindsBy(How = How.Id, Using = "ctl00_HyperLink4")]
        private IWebElement linkReport;
        [FindsBy(How = How.CssSelector, Using = "img[title='Proctor Shifts']")]
        private IWebElement iconProctorShifts;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lblTitle")]
        private IWebElement AssertLogo;

        //TO DATE SELECTION
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_txtFromDate_popupButton")]
        private IWebElement dropDownToDatePopUpButton;
        [FindsBy(How = How.ClassName, Using = "rcSelected")]
        private IWebElement currentDate;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnYesNo")]
        private IWebElement yesNoButton;

        public void navigateToProctorShiftsPage(string userName,
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
            ClickElement(iconProctorShifts);
            Assert.IsTrue(AssertLogo.Displayed);
        }

        public void selectToDate()
        {
            ClickElement(dropDownToDatePopUpButton);
            ClickElement(currentDate);
            ClickElement(yesNoButton);
        }

        public void selectSearch()
        {
            Sleep(1000);
            ScreenCapture(driver);
        }
    }
}
