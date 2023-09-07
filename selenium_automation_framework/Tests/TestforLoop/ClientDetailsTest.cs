using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;
using System.Collections.Generic;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class ClientDetailsTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ClientDetailsTestPage(IWebDriver driver)
        {
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            ClientDetailsPage clientDetailsPage = new ClientDetailsPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            clientDetailsPage.navigateToClientDetailspage(userName, password, adminUserName, adminPassword, LoginAs);
            int x = Int32.Parse(expClient);
            clientDetailsPage.selectClientDropdown(x);
            clientDetailsPage.selectSearch(expError, email);
        }
    }
}
