using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;

namespace PortalApplicationFramework
{
    public class ClientDetailsTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ClientDetailsTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string expClient = getDataParser().extractDataLoginCredentials("expClient");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");

            ClientDetailsPage clientDetailsPage = new ClientDetailsPage(driver);
            clientDetailsPage.navigateToClientDetailspage(reportTab, LoginpageUrl);
            int x = Int32.Parse(expClient);
            clientDetailsPage.selectClientDropdown(x);
            clientDetailsPage.selectSearch(expError, email, reportTab);
        }
    }
}
