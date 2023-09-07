using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace PortalApplicationFramework.PageObjects
{
    class EnrollmentsPage : BasePage
    {
        private IWebDriver driver;
        public EnrollmentsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PAGE NAVIGATION
        [FindsBy(How = How.Id, Using = "ctl00_HyperLink4")]
        private IWebElement linkReport;
        [FindsBy(How = How.CssSelector, Using = "img[title='Enrollments']")]
        private IWebElement iconEnrollments;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lblTitle")]
        private IWebElement AssertLogo;

        //CHECKBOX CLIENT SELECTION
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$ddlClients")]
        private IWebElement CheckBoxClientSelectionDropdown;
        [FindsBy(How = How.ClassName, Using = "rcbCheckAllItemsCheckBox")]
        private IWebElement CheckAllClient;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlClients_DropDown']/div/ul/li")]
        private IList<IWebElement> selectCheckBoxClient;

        //SELECT INSTRUCTOR
        [FindsBy(How = How.Name, Using = "ctl00$ContentPlaceHolder1$ddlInstructor")]
        private IWebElement dropDownSelectInstructor;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlInstructor_DropDown']/div/ul/li")]
        private IList<IWebElement> selectInstructor;

        //SEARCH
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnSearch")]
        private IWebElement buttonSearch;

        //EXPORT DATA
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnExportOptions")]
        private IWebElement buttonExport;
        [FindsBy(How = How.Id, Using = "btnExport")]
        private IWebElement exportButton;
        [FindsBy(How = How.XPath, Using = "//input[@value='CSV']")]
        private IWebElement selectExportOption2;
        [FindsBy(How = How.Id, Using = "chkSendMail")]
        private IWebElement checkBoxEmail;
        [FindsBy(How = How.Id, Using = "txtEmail")]
        private IWebElement textBoxEmail;
        [FindsBy(How = How.Id, Using = "btnSendMail")]
        private IWebElement sendMailButton;
        [FindsBy(How = How.XPath, Using = "//table[@id='ctl00_ContentPlaceHolder1_gvExamsList_ctl00']//tr")]
        private IList<IWebElement> demo;

        public void navigateToEnrollmentspage(string reportTab, string LoginpageUrl)
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
                ClickElement(iconEnrollments);
                ReportLog("Passed", "Clicked on Enrollments icon");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on Enrollments icon");
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
                Sleep(2000);
                try
                {
                    ClickElement(CheckAllClient);
                    ReportLog("Passed", "Clicked on client selection dropdown");
                }
                catch (Exception ex)
                {
                    ReportLog("Failed", "Didn't click on client selection dropdown");
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
                for (int i = 0; i < expClient; i++)
                {
                    Sleep(2000);
                    Console.WriteLine("Entered the else block");
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

        public void selectInstructorsDropdown(String expInstuctor)
        {
            
            try
            {
                ClickElement(dropDownSelectInstructor);
                ReportLog("Passed", "Clicked on instructor selection dropdown");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't click on instructor selection dropdown");
                throw ex;
            }
            Sleep(1000);
            try
            {
                foreach (IWebElement Instructor in selectInstructor)
                {
                    if (Instructor.Text.Equals(expInstuctor))
                    {
                        ClickElement(Instructor);
                        break;
                    }
                }
                ReportLog("Passed", "Selected instructor");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't select instructor");
                throw ex;
            }
            Sleep(1000);
        }

        public void selectSearch(String expError, String email, String reportTab)
        {
            Sleep(5000);
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
                if (demo.Count > 2)
                {
                    ClickElement(buttonExport);
                    Sleep(5000);
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
                ReportLog("Passed", "Exported document");
            }
            catch (Exception ex)
            {
                ReportLog("Failed", "Didn't export document");
                throw ex;
            }
            Sleep(5000);
            /* if (demo.Count > 2)
             {
                 ClickElement(buttonExport);
                 Sleep(5000);
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
