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

namespace PortalApplicationFramework.PageObjects
{
    class ExamHistoryPage : BasePage
    {
        private IWebDriver driver;
        public ExamHistoryPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PAGE NAVIGATION
        [FindsBy(How = How.Id, Using = "ctl00_HyperLink4")]
        private IWebElement linkReport;
        [FindsBy(How = How.CssSelector, Using = "img[title='Exam Details History']")]
        private IWebElement iconExamHistory;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lblTitle")]
        private IWebElement AssertLogo;

        //SINGLE CLIENT SELECTION
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$ddlClients")]
        private IWebElement singleClientSlectionDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlClients_DropDown']/div/ul/li")]
        private IList<IWebElement> singleClientSelection;

        //COURSE NAME
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_txtCourseName")]
        private IWebElement courseName;

        //EXAM NAME
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_txtExamDetails")]
        private IWebElement examName;

        //SEARCH
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$btnSearch")]
        private IWebElement buttonSearch;
        [FindsBy(How = How.XPath, Using = "//span[text()='No Exams available']")]
        private IWebElement labelErrorMessage;

        public void navigateToExamHistorypage(string userName,
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
            ClickElement(iconExamHistory);
            Assert.IsTrue(AssertLogo.Displayed);
        }

        public void selectClientDropdown(String expClient1)
        {
            if (expClient1 == "random")
            {
                ClickElement(singleClientSlectionDropdown);
                Random r = new Random();
                int rInt = r.Next(1, singleClientSelection.Count);
                singleClientSelection[rInt].Click();
            }
            else
            {
                ClickElement(singleClientSlectionDropdown);
                Sleep(1000);
                foreach (IWebElement client in singleClientSelection)
                {
                    if (client.Text.Equals(expClient1))
                    {
                        ClickElement(client);
                        break;
                    }
                }
                Sleep(1000);
            }
        }

        public void typeCourseName(String course)
        {
            EnterValues(courseName, course);
        }

        public void typeExamName(String exam)
        {
            EnterValues(examName, exam);
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
