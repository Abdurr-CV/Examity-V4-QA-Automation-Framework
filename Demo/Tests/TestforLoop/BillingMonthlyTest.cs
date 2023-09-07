using NUnit.Framework;
using OpenQA.Selenium;
using Demo.PageObjects;
using Demo.Utilities;
using System.Collections.Generic;

namespace Demo
{
    public class BillingMonthlyTest : TestBase
    {
        private object BillingMonthlyPage;

        [Test, TestCaseSource("AddTestDataConfig")]
        public void billingMonthlyTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expMonth = getDataParser().extractDataMonthlyReportsDateSelection("expMonth");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string expError = getDataParser().extractDataLoginCredentials("expError");

            BillingMonthlyPage billingMPage = new BillingMonthlyPage(driver);
            ClientsRandomSelectionPage clientSelectionPage = new ClientsRandomSelectionPage();
            string randomclient = clientSelectionPage.ClientSelectionrandomly();
            TestContext.Progress.WriteLine(randomclient);
            billingMPage.navigateToBillingMonthly(reportTab, LoginpageUrl);
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
                billingMPage.selectSearch(expError, reportTab);
            }
        }
    }
}
