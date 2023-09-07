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
    class ScheduledExamsMonthlyPage : BasePage
    {
        private IWebDriver driver;
        public ScheduledExamsMonthlyPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PAGE NAVIGATION
        [FindsBy(How = How.Id, Using = "ctl00_HyperLink4")]
        private IWebElement linkReport;
        [FindsBy(How = How.CssSelector, Using = "img[title='Scheduled Exams']")]
        private IWebElement iconScheduledExams;

        //CHECKBOX CLIENT SELECTION
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddlClients_Arrow")]
        private IWebElement CheckBoxClientSelectionDropdown;
        [FindsBy(How = How.ClassName, Using = "rcbCheckAllItemsCheckBox")]
        private IWebElement unCheckAll;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlClients_DropDown']/div/ul/li")]
        private IList<IWebElement> selectCheckBoxClient;

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
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnSearch")]
        private IWebElement buttonSearch;

        public void navigateToScheduledExamsPage(string userName,
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
            ClickElement(iconScheduledExams);
        }

        public void selectClientDropdown(int expClient)
        {
            Sleep(1000);
            if (expClient == 0)
            {
            }
            else
            {
                ClickElement(CheckBoxClientSelectionDropdown);
                Sleep(2000);
                ClickElement(unCheckAll);
                Sleep(2000);
                for (int i = 0; i < expClient; i++)
                {
                    Sleep(2000);
                    Random r = new Random();
                    int rInt = r.Next(1, selectCheckBoxClient.Count);
                    selectCheckBoxClient[rInt].Click();
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

        public void selectSearch()
        {
            ClickElement(buttonSearch);
            Sleep(5000);
            ScreenCapture(driver);
        }
    }
}
