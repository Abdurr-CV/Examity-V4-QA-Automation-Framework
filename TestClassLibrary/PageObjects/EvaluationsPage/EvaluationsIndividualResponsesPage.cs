using OpenQA.Selenium;
using PortalApplicationFramework.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace PortalApplicationFramework.PageObjects
{
    class EvaluationsIndividualResponsesPage : BasePage
    {
        private IWebDriver driver;
        public EvaluationsIndividualResponsesPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PAGE NAVIGATION
        [FindsBy(How = How.Id, Using = "ctl00_HyperLink4")]
        private IWebElement linkReport;
        [FindsBy(How = How.CssSelector, Using = "img[title='Evaluations']")]
        private IWebElement iconEvaluations;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lnkPayments")]
        private IWebElement tabIR;

        //CHECKBOX CLIENT SELECTION
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddlClients_Arrow")]
        private IWebElement CheckBoxClientSelectionDropdown;
        [FindsBy(How = How.ClassName, Using = "rcbCheckAllItemsCheckBox")]
        private IWebElement CheckAll;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlClients_DropDown']/div/ul/li")]
        private IList<IWebElement> selectCheckBoxClient;

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

        //STUDENT NAME
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_txtStudentName")]
        private IWebElement studentName;

        //EXAM ID
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_txtExamID")]
        private IWebElement examID;

        //SEARCH
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnSearch")]
        private IWebElement buttonSearch;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnExport")]
        private IWebElement buttonExport;

        public void navigateToEvaluationsPage(string LoginpageUrl)
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
                ReportsLog.Pass("Clicked on reports tab");
            }
            catch (Exception ex)
            {
                ReportsLog.Fail("Didn't click on reports tab");
                throw ex;
            }
            Sleep(5000);
            try
            {
                ClickElement(iconEvaluations);
                ReportsLog.Pass("Clicked on Evaluation icon");
            }
            catch (Exception ex)
            {
                ReportsLog.Fail("Didn't click on Evaluation icon");
                throw ex;
            }
            try
            {
                ClickElement(tabIR);
                ReportsLog.Pass("IR tab selected");
            }
            catch (Exception ex)
            {
                ReportsLog.Fail("Didn't select IR tab");
                throw ex;
            }
            Sleep(3000);
        }

        public void selectClientDropdown(int expClient)
        {
            Sleep(1000);
            if (expClient == 0)
            {
                try
                {
                    ClickElement(CheckBoxClientSelectionDropdown);
                    ReportsLog.Pass("Clicked on client selection dropdown");
                }
                catch (Exception ex)
                {
                    ReportsLog.Fail("Didn't click on client selection dropdown");
                    throw ex;
                }
                try
                {
                    ClickElement(CheckAll);
                    ReportsLog.Pass("Clicked on client selection dropdown");
                }
                catch (Exception ex)
                {
                    ReportsLog.Fail("Didn't click on client selection dropdown");
                    throw ex;
                }
            }
            else
            {
                try
                {
                    ClickElement(CheckBoxClientSelectionDropdown);
                    ReportsLog.Pass("Clicked on client selection dropdown");
                }
                catch (Exception ex)
                {
                    ReportsLog.Fail("Didn't click on client selection dropdown");
                    throw ex;
                }
                for (int i = 0; i < expClient; i++)
                {
                    Sleep(2000);
                    Console.WriteLine("Entered the else block");
                    Random r = new Random();
                    int rInt = r.Next(1, selectCheckBoxClient.Count);
                    try
                    {
                        selectCheckBoxClient[rInt].Click();
                        ReportsLog.Pass("selected clients");
                    }
                    catch (Exception ex)
                    {
                        ReportsLog.Fail("Didn't select clients");
                        throw ex;
                    }
                }
                Sleep(2000);
            }
        }

        public void selectFromDate(String expFromDate)
        {
            Sleep(1000);
            try
            {
                ClickElement(dropDownFromDatePopUpButton);
                ReportsLog.Pass("Clicked on from-date selection dropdown");
            }
            catch (Exception ex)
            {
                ReportsLog.Fail("Didn't click on from-date selection dropdown");
                throw ex;
            }
            Sleep(2000);
            try
            {
                foreach (IWebElement first in firstOfMonth)
                {
                    if (first.Text.Equals(expFromDate))
                    {
                        ClickElement(first);
                        break;
                    }
                }
                ReportsLog.Pass("selected from-date");
            }
            catch (Exception ex)
            {
                ReportsLog.Fail("Didn't select from-date");
                throw ex;
            }
            Sleep(1000);
        }

        public void selectToDate()
        {
            try
            {
                ClickElement(dropDownToDatePopUpButton);
                ReportsLog.Pass("Clicked on to-date selection dropdown");
            }
            catch (Exception ex)
            {
                ReportsLog.Fail("Didn't click on to-date selection dropdown");
                throw ex;
            }
            try
            {
                ClickElement(currentDate);
                ReportsLog.Pass("selected current date");
            }
            catch (Exception ex)
            {
                ReportsLog.Fail("Didn't select current date");
                throw ex;
            }
        }

        public void typeStudentName(String expStudentName)
        {
            try
            {
                EnterValues(studentName, expStudentName);
                ReportsLog.Pass("Entered student name");
            }
            catch (Exception ex)
            {
                ReportsLog.Fail("Didn't enter student name");
                throw ex;
            }
        }

        public void typeExamID(String expExamID)
        {
            try
            {
                EnterValues(examID, expExamID);
                ReportsLog.Pass("Entered the Exam ID");
               // ReportLog("Passed", "Entered exam ID name");
            }
            catch (Exception ex)
            {
                ReportsLog.Fail("Didn't enter exam ID name");
                throw ex;
            }
        }

        public void selectSearch()
        {
            Sleep(5000);
            try
            {
                ClickElement(buttonSearch);
                ReportsLog.Pass("Clicked on search button");
            }
            catch (Exception ex)
            {
                ReportsLog.Fail("Didn't click on search button");
                throw ex;
            }
            Sleep(5000);
            ScreenCapture(driver);
            Sleep(5000);
            try
            {
                ClickElement(buttonExport);
                ReportsLog.Pass("Clicked on export button");
            }
            catch (Exception ex)
            {
                ReportsLog.Fail("Didn't click on export button");
                throw ex;
            }
            Sleep(5000);
        }
    }
}

