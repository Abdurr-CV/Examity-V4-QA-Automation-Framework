using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using System.Collections.Generic;

namespace PortalApplicationFramework
{
    //[Parallelizable(ParallelScope.Self)]
    public class BillingMonthlyTest : TestBase
    {
        private object BillingMonthlyPage;

        [Test, TestCaseSource("AddTestDataConfig")]
        public void billingMonthlyTestPage(IWebDriver driver)
        {
            string expMonth = getDataParser().extractDataMonthlyReportsDateSelection("expMonth");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            BillingMonthlyPage billingMPage = new BillingMonthlyPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            string randomclient = clientSelectionPage.ClientSelectionrandomly();
            TestContext.Progress.WriteLine(randomclient);
            billingMPage.navigateToBillingMonthly(userName, password, adminUserName, adminPassword, LoginAs);
            billingMPage.ClickingMethod();
            IList<IWebElement> elements = billingMPage.GetClient();
            for (int i = 0; i < elements.Count; i++)
            {
                string randomclient_a = elements[i].GetAttribute("innerHTML");
                billingMPage.selectClientDropdown(randomclient_a);
                if (i == 0)
                {
                    billingMPage.selectMonthDropdown(expMonth);
                    billingMPage.selectYearDropdown(expYear);
                }
                billingMPage.selectSearch(expError);
            }
        }
    }
}
