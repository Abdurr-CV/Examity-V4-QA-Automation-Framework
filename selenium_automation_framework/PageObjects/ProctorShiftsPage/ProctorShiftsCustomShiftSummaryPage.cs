﻿using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PortalApplicationFramework.PageObjects
{
    class ProctorShiftsCustomShiftSummaryPage : BasePage
    {
        private IWebDriver driver;
        public ProctorShiftsCustomShiftSummaryPage(IWebDriver driver)
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
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lnkGraph")]
        private IWebElement tabProctorShiftsSummary;

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
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnSearch")]
        private IWebElement buttonSearch;

        //EXPORT DATA
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnExportOptions")]
        private IWebElement buttonExport;
        [FindsBy(How = How.Id, Using = "btnExport")]
        private IWebElement exportButton;
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$windowExportOptions$C$chkSendMail")]
        private IWebElement checkBoxEmail;
        [FindsBy(How = How.Id, Using = "txtEmail")]
        private IWebElement textBoxEmail;
        [FindsBy(How = How.Id, Using = "btnSendMail")]
        private IWebElement sendMailButton;
        [FindsBy(How = How.XPath, Using = "//table[@id='ctl00_ContentPlaceHolder1_gvExamsList_ctl00']//tr")]
        private IList<IWebElement> demo;

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
            ClickElement(tabProctorShiftsSummary);
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

        public void selectSearch(String expError, String email)
        {
            ClickElement(buttonSearch);
            Sleep(1000);
            ScreenCapture(driver);
            Sleep(1000);
            ClickElement(buttonExport);
            Thread.Sleep(3000);
            ClickElement(exportButton);
            ClickElement(exportButton);
            ClickElement(checkBoxEmail);
            EnterValues(textBoxEmail, email);
            ClickElement(sendMailButton);
        }
    }
}
