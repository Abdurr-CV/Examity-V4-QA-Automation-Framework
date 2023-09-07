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

        public void navigateToAdministrationpage(string userName,
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
            ClickElement(iconAdministration);
            Assert.IsTrue(AssertLogo.Displayed);
        }

        public void selectClientDropdown(int expClient)
        {
            Sleep(1000);
            if (expClient == 0)
            {
                ClickElement(CheckBoxClientSelectionDropdown);
                ClickElement(CheckAllClient);
            }
            else
            {
                ClickElement(CheckBoxClientSelectionDropdown);
                for (int i = 0; i < expClient; i++)
                {
                    Sleep(2000);
                    Console.WriteLine("Entered the else block");
                    Random r = new Random();
                    int rInt = r.Next(1, selectCheckBoxClient.Count);
                    selectCheckBoxClient[rInt].Click();
                }
                Sleep(2000);
            }  
        }

        public void typeEmailAddress(String expEmail)
        {
            EnterValues(emailAddress, expEmail);
        }

        public void typeUserID(String expUserID)
        {
            EnterValues(userID, expUserID);
        }

        public void typeFirstName(String fName)
        {
            EnterValues(firstName, fName);
        }

        public void typeLastName(String lName)
        {
            EnterValues(lastName, lName);
        }

        public void selectSearch(String expError, String email)
        {
            ClickElement(buttonSearch);
            Sleep(5000);
            ScreenCapture(driver);

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
        }


    }
}
