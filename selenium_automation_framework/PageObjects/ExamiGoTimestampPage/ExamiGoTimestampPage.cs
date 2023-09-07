using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;

namespace PortalApplicationFramework.PageObjects.ExamiGoTimestampPage
{
    class ExamiGoTimestampPage : BasePage
    {
        private IWebDriver driver;
        public ExamiGoTimestampPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PAGE NAVIGATION
        [FindsBy(How = How.Id, Using = "ctl00_HyperLink4")]
        private IWebElement linkReport;
        [FindsBy(How = How.XPath, Using = "//div[@id='ui-accordion-accordion-panel-3']/div/span")]
        private IList<IWebElement> iconExamiGoTimestamp;
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

        //SEARCH
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$btnSearch")]
        private IWebElement buttonSearch;
        [FindsBy(How = How.XPath, Using = "//span[text()='No records available']")]
        private IWebElement labelErrorMessage;

        //EXPORT DATA
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$btnExportOptions")]
        private IWebElement buttonExport;

        public void navigateToExamiGoTimestampPage(String selectIcon,
                                                 string userName,
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
            Sleep(1000);
            foreach (IWebElement icon in iconExamiGoTimestamp)
            {
                if (icon.Text.Equals(selectIcon))
                {
                    ClickElement(icon);
                    break;
                }
            }
            Sleep(1000);
            Assert.IsTrue(AssertLogo.Displayed);
        }

        public void selectFromDate(String expFromDate)
        {
            ClickElement(dropDownFromDatePopUpButton);
            Sleep(1000);
            foreach (IWebElement first in firstOfMonth)
            {
                if (first.Text.Equals(expFromDate))
                {
                    ClickElement(first);
                    break;
                }
            }
            Sleep(1000);
        }

        public void selectToDate()
        {
            ClickElement(dropDownToDatePopUpButton);
            ClickElement(currentDate);
            ClickElement(dropDownToDatePopUpButton);
        }

        public void selectSearch(String expError)
        {
            ClickElement(buttonSearch);
            Sleep(5000);
            ScreenCapture(driver);

            if (!labelErrorMessage.Displayed)
            {
                Console.WriteLine("Pass");
            }
            else
            {
                Console.WriteLine(expError);
            }
        }

    }
}
