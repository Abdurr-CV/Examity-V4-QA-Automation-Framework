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
    class EvaluationsSurveyDetailsPage : BasePage
    {
        private IWebDriver driver;
        public EvaluationsSurveyDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //PAGE NAVIGATION
        [FindsBy(How = How.Id, Using = "ctl00_HyperLink4")]
        private IWebElement linkReport;
        [FindsBy(How = How.CssSelector, Using = "img[title='Evaluations']")]
        private IWebElement iconEvaluations;
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_lnkTransactions")]
        private IWebElement tabDetails;

        //SINGLE CLIENT SELECTION
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_ddlClients_Arrow")]
        private IWebElement singleClientSlectionDropdown;
        [FindsBy(How = How.XPath, Using = "//div[@id='ctl00_ContentPlaceHolder1_ddlClients_DropDown']/div/ul/li")]
        private IList<IWebElement> singleClientSelection;

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
        [FindsBy(How = How.Id, Using = "ctl00_ContentPlaceHolder1_btnExport")]
        private IWebElement buttonExport;

        public void navigateToEvaluationsPage(string userName,
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
            ClickElement(iconEvaluations);
            ClickElement(tabDetails);
        }

        public void selectClientDropdown(String expClient1)
        {
            if (expClient1 == "random")
            {
                ClickElement(singleClientSlectionDropdown);
                Sleep(2000);
                Random r = new Random();
                int rInt = r.Next(1, singleClientSelection.Count);
                singleClientSelection[rInt].Click();
                Sleep(1000);
            }
            else
            {
                ClickElement(singleClientSlectionDropdown);
                Sleep(2000);
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

        public void selectFromDate(String expFromDate)
        {
            Sleep(1000);
            ClickElement(dropDownFromDatePopUpButton);
            Sleep(2000);
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
        }

        public void selectSearch()
        {
            ClickElement(buttonSearch);
            Sleep(5000);
            ScreenCapture(driver);
            ClickElement(buttonExport);
            Sleep(5000);
        }
    }
}
