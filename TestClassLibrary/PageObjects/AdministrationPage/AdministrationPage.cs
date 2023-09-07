using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace PortalApplicationFramework.PageObjects
{
    class AdministrationPage : BasePage
    {
        private IWebDriver driver;
        public AdministrationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PAGE NAVIGATION
        [FindsBy(How = How.Id, Using = "ctl00_HyperLink4")]
        private IWebElement linkReport;
        [FindsBy(How = How.CssSelector, Using = "img[title='Admins']")]
        private IWebElement iconAdministration;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lblTitle")]
        private IWebElement AssertLogo;
        
        //CHECKBOX CLIENT SELECTION
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddlClients_Arrow")]
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
        [FindsBy(How = How.ClassName, Using = "rgNoRecords")]
        private IWebElement labelErrorMessage;
        [FindsBy(How = How.ClassName, Using = "rgRow")]
        private IWebElement resultSheet;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnExportOptions")]
        private IWebElement buttonExport;
        [FindsBy(How = How.Id, Using = "btnExport")]
        private IWebElement exportButton;
        [FindsBy(How = How.XPath, Using = "//input[@value='Excel']")]
        private IWebElement selectExportOption1;
        [FindsBy(How = How.XPath, Using = "//input[@value='CSV']")]
        private IWebElement selectExportOption2;
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$windowExportOptions$C$chkSendMail")]
        private IWebElement checkBoxEmail;
        [FindsBy(How = How.Id, Using = "txtEmail")]
        private IWebElement textBoxEmail;
        [FindsBy(How = How.Id, Using = "btnSendMail")]
        private IWebElement sendMailButton;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lblErrorMessage")]
        private IWebElement NoRecordsAvailable;

        public void navigateToAdministrationpage(string LoginpageUrl)
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
                ClickElement(iconAdministration);
                ReportLog("Passed", "Clicked on Administration icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Administration icon");
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
                    ReportLog("Passed", "Clicked on client checkbox dropdown");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on client checkbox dropdown");
                    throw ex;
                }
                try
                {
                    ClickElement(CheckAllClient);
                    ReportLog("Passed", "Clicked on check-all");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on check-all");
                    throw ex;
                }
            }
            else
            {
                try
                {
                    ClickElement(CheckBoxClientSelectionDropdown);
                    ReportLog("Passed", "Clicked on client checkbox dropdown");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on client checkbox dropdown");
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
                        ReportLog("Passed", "selected client");
                    }
                    catch (Exception ex)
                    {
                        ReportLog("Failed", "Didn't select client");
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

        public void selectSearch(String expError, String email, string reportTab)
        {
            try
            {
                ClickElement(buttonSearch);
                ReportLog("Passed", "Clicked on search");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on search");
                throw ex;
            }
            Sleep(5000);
            ScreenCapture(driver);
            try
            {
                if (!resultsRecord.Text.Equals("0"))
                {
                    ClickElement(buttonExport);
                    Sleep(3000);
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
                ReportLog("Passed", "Exported documents");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't export documents");
                throw ex;
            }
            /*if (!resultsRecord.Text.Equals("0"))
            {
                ClickElement(buttonExport);
                Sleep(3000);
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
