using OpenQA.Selenium;
using PortalApplicationFramework.Utilities;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalApplicationFramework.PageObjects
{
    class ProctorUtilizationReportPage : BasePage
    {
        private IWebDriver driver;
        public ProctorUtilizationReportPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PAGE NAVIGATION
        [FindsBy(How = How.Id, Using = "ctl00_HyperLink4")]
        private IWebElement linkReport;
        [FindsBy(How = How.CssSelector, Using = "img[title='Proctor Utilization Report']")]
        private IWebElement iconProctorUtilizationReport;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lnkProctorViewDetails")]
        private IWebElement tabViewDetails;

        //CHECKBOX PROCTOR SELECTION
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddlProctors_Arrow")]
        private IWebElement CheckBoxProctorSelectionDropdown;
        [FindsBy(How = How.ClassName, Using = "rcbCheckAllItemsCheckBox")]
        private IWebElement unCheckAll;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlProctors_DropDown']/div/ul/li")]
        private IList<IWebElement> selectCheckBoxProctor;

        //MONTH DROPDOWN
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddlMonths_Arrow")]
        private IWebElement dropDownMonth;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlMonths_DropDown']/div/ul/li")]
        private IList<IWebElement> selectMonth;

        //YEAR DROPDOWN
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddYears_Arrow")]
        private IWebElement dropDownYear;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddYears_DropDown']/div/ul/li")]
        private IList<IWebElement> selectYear;

        //SEARCH
        [FindsBy(How = How.XPath, Using = "//span[@id='ctl00_ContentPlaceHolder1_lblToatlCount']")]
        private IWebElement resultsRecord;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnSearch")]
        private IWebElement buttonSearch;
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

        public void navigateToProctorUtilizationReportPage(string userName,
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
            ClickElement(iconProctorUtilizationReport);
            ClickElement(tabViewDetails);
        }

        public void selectProctorDropdown(int expProctor)
        {
            Sleep(1000);
            if (expProctor == 0)
            {
            }
            else
            {
                ClickElement(CheckBoxProctorSelectionDropdown);
                Sleep(2000);
                ClickElement(unCheckAll);
                Sleep(2000);
                for (int i = 0; i < expProctor; i++)
                {
                    Sleep(2000);
                    Random r = new Random();
                    int rInt = r.Next(1, selectCheckBoxProctor.Count);
                    selectCheckBoxProctor[rInt].Click();
                }
                Sleep(2000);
            }
        }

        public void selectMonthDropdown(String expMonth)
        {
            ClickElement(dropDownMonth);
            Sleep(1000);
            foreach (IWebElement month in selectMonth)
            {
                if (month.Text.Equals(expMonth))
                {
                    ClickElement(month);
                    break;
                }
            }
            Sleep(1000);
        }

        public void selectYearDropdown(String expYear)
        {
            ClickElement(dropDownYear);
            Sleep(1000);
            foreach (IWebElement year in selectYear)
            {
                if (year.Text.Equals(expYear))
                {
                    ClickElement(year);
                    break;
                }
            }
            Sleep(1000);
        }

        public void selectSearch(String expError, String email)
        {
            ClickElement(buttonSearch);
            Sleep(13000);
            ScreenCapture(driver);

            if (!resultsRecord.Text.Equals("0"))
            {
                ClickElement(buttonExport);
                Sleep(6000);
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
