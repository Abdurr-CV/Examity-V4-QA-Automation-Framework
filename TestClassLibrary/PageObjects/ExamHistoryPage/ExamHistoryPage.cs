using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

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

        public void navigateToExamHistorypage(string reportTab, string LoginpageUrl)
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
                ClickElement(iconExamHistory);
                ReportLog("Passed", "Clicked on Exam-history icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Exam-history icon");
                throw ex;
            }
            try
            {
                Assert.IsTrue(AssertLogo.Displayed);
                ReportLog("Passed", "Asserted");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't assert");
                throw ex;
            }
        }

        public void selectClientDropdown(String expClient1)
        {
            if (expClient1 == "random")
            {
                try
                {
                    ClickElement(singleClientSlectionDropdown);
                    ReportLog("Passed", "Clicked on client selection dropdown");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on client selection dropdown");
                    throw ex;
                }
                Sleep(2000);
                Random r = new Random();
                int rInt = r.Next(1, singleClientSelection.Count);
                try
                {
                    singleClientSelection[rInt].Click();
                    ReportLog("Passed", "selected clients");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't select clients");
                    throw ex;
                }
                Sleep(1000);
            }
            else
            {
                try
                {
                    ClickElement(singleClientSlectionDropdown);
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
                    foreach (IWebElement client in singleClientSelection)
                    {
                        if (client.Text.Equals(expClient1))
                        {
                            ClickElement(client);
                            break;
                        }
                    }
                    ReportLog("Passed", "selected clients");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't select clients");
                    throw ex;
                }
                Sleep(1000);
            }
        }

        public void typeCourseName(String course)
        {
            try
            {
                EnterValues(courseName, course);
                ReportLog("Passed", "Entered course name");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter course name");
                throw ex;
            }
        }

        public void typeExamName(String exam)
        {
            try
            {
                EnterValues(examName, exam);
                ReportLog("Passed", "Entered exam name");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter exam name");
                throw ex;
            }
        }

        public void selectSearch(String expError)
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
