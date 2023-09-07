using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class BillingCustomTest : TestBase
    {
        private object BillingCustomPage;

        [Test, TestCaseSource("AddTestDataConfig")]
        public void BillingCustomTestPage(IWebDriver driver)
        {
            string expClient1 = getDataParser().extractDataLoginCredentials("expClient1");
            string expFromDate = getDataParser().extractDataCustomReportsDateSelection("expFromDate");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");


            BillingCustomPage billingCusPage = new BillingCustomPage(driver);
            /*ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            string randomclient = clientSelectionPage.ClientSelectionrandomly();
            TestContext.Progress.WriteLine(randomclient);*/
            billingCusPage.navigateToBillingCustomPage(userName, password, adminUserName, adminPassword, LoginAs);
            billingCusPage.selectClientDropdown(expClient1);
            billingCusPage.selectFromDate(expFromDate);
            billingCusPage.selectToDate();
            billingCusPage.selectSearch(expError, email);
            /*IList<IWebElement> elements = billingCusPage.GetClient();
            for (int i = 0; i < elements.Count; i++)
            {
                string randomclient_a = elements[i].GetAttribute("innerHTML");
                billingCusPage.selectClientDropdown(randomclient_a);
                if (i == 0)
                {
                    billingCusPage.selectFromDate(expFromDate);
                    billingCusPage.selectToDate();
                }
                billingCusPage.selectSearch(expError, email);
            }*/
        }
    }
}
