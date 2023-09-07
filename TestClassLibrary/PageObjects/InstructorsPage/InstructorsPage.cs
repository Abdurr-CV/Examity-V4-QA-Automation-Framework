using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PortalApplicationFramework.PageObjects
{
    class InstructorsPage : BasePage
    {
        private IWebDriver driver;
        public InstructorsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PAGE NAVIGATION
        [FindsBy(How = How.Id, Using = "ctl00_HyperLink4")]
        private IWebElement linkReport;
        [FindsBy(How = How.CssSelector, Using = "img[title='Instructors']")]
        private IWebElement iconInstructors;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lblTitle")]
        private IWebElement AssertLogo;

        //CHECKBOX CLIENT SELECTION
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$ddlClients")]
        private IWebElement CheckBoxClientSelectionDropdown;
        [FindsBy(How = How.ClassName, Using = "rcbCheckAllItemsCheckBox")]
        private IWebElement CheckAllClient;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlClients_DropDown']/div/ul/li")]
        private IList<IWebElement> selectCheckBoxClient;

        //EMAIL ADDRESS
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_txtEmailAddress")]
        private IWebElement emailAddress;

        //USER ID
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_txtUserId")]
        private IWebElement userID;

        //FIRST NAME
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_txtfirstname")]
        private IWebElement firstName;

        //LAST NAME
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_txtLastName")]
        private IWebElement lastName;

        //SEARCH
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnSearch")]
        private IWebElement buttonSearch;

        //EXPORT DATA
        [FindsBy(How = How.XPath, Using = "//span[@id='ctl00_ContentPlaceHolder1_lblToatlCount']")]
        private IWebElement resultsRecord;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnExportOptions")]
        private IWebElement buttonExport;
        [FindsBy(How = How.Id, Using = "btnExport")]
        private IWebElement exportButton;
        [FindsBy(How = How.XPath, Using = "//input[@value='CSV']")]
        private IWebElement selectExportOption2;
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$windowExportOptions$C$chkSendMail")]
        private IWebElement checkBoxEmail;
        [FindsBy(How = How.Id, Using = "txtEmail")]
        private IWebElement textBoxEmail;
        [FindsBy(How = How.Id, Using = "btnSendMail")]
        private IWebElement sendMailButton;

        public void navigateToInstructorspage(string reportTab, string LoginpageUrl)
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
                ClickElement(iconInstructors);
                ReportLog("Passed", "Clicked on Instructors icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Instructors icon");
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

        public void selectClientDropdown(int expClient)
        {
            Sleep(1000);
            if (expClient == 0)
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
                try
                {
                    ClickElement(CheckAllClient);
                    ReportLog("Passed", "Clicked on check-all clients");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on check-all clients");
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

        public void typeEmailAddress(String expEmail)
        {
            try
            {
                EnterValues(emailAddress, expEmail);
                ReportLog("Passed", "Entered email address");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter email address");
                throw ex;
            }
        }

        public void typeUserID(String expUserID)
        {
            try
            {
                EnterValues(userID, expUserID);
                ReportLog("Passed", "Entered user ID");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter user ID");
                throw ex;
            }
        }

        public void typeFirstName(String fName)
        {
            try
            {
                EnterValues(firstName, fName);
                ReportLog("Passed", "Entered first name");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter first name");
                throw ex;
            }
        }

        public void typeLastName(String lName)
        {
            try
            {
                EnterValues(lastName, lName);
                ReportLog("Passed", "Entered last name");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't enter last name");
                throw ex;
            }
        }

        public void selectSearch(String expError, String email, String reportTab)
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
            try
            {
                if (!resultsRecord.Text.Equals("0"))
                {
                    ClickElement(buttonExport);
                    Thread.Sleep(3000);
                    ClickElement(exportButton);
                    ClickElement(selectExportOption2);
                    ClickElement(exportButton);
                    ClickElement(checkBoxEmail);
                    EnterValues(textBoxEmail, email);
                    ClickElement(sendMailButton);
                }
                else
                {
                    Console.WriteLine(expError);
                }
                ReportLog("Passed", "Exported the document");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't export the document");
                throw ex;
            }
            /*if (!resultsRecord.Text.Equals("0"))
            {
                ClickElement(buttonExport);
                Thread.Sleep(3000);
                ClickElement(exportButton);
                ClickElement(selectExportOption2);
                ClickElement(exportButton);
                ClickElement(checkBoxEmail);
                EnterValues(textBoxEmail, email);
                ClickElement(sendMailButton);
            }
            else
            {
                Console.WriteLine(expError);
            }*/
        }
    }
}

