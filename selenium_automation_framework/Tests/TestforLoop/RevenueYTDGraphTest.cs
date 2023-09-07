using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalApplicationFramework
{
    class RevenueYTDGraphTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void RevenueYTDGraphTestPage(IWebDriver driver)

        {
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string email = getDataParser().extractDataLoginCredentials("email");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            RevenueYTDGraphPage revenueYTDGraphPage = new RevenueYTDGraphPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            revenueYTDGraphPage.navigateToRevenueYTDGraphpage(userName, password, adminUserName, adminPassword, LoginAs);
            /*int x = Int32.Parse(expClient);
            revenueYTDGraphPage.selectClientDropdown(x);*/
            revenueYTDGraphPage.selectYearDropdown(expYear);
            revenueYTDGraphPage.selectSearch(email);
        }
    }
}
