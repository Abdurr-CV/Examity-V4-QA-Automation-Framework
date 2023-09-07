using NUnit.Framework;
using Demo.PageObjects;
using Demo.Utilities;
using System.Collections.Generic;

namespace Demo
{
    public class ClassLoopTest1 : TestBase

    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void AAutomationContinuity(string userName,
                                          string password,
                                          string adminUserName,
                                          string adminPassword,
                                          string LoginAs)
        {
            
            string LoginUserName;
            string LoginPassword;
            BrowserInitiation();
            LoginPage loginPage = new LoginPage(getDriver());
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
                string loginUrl = driver.Url;
                if (loginUrl.Contains("switchrole.aspx"))
                {
                    loginPage.signInUserProd();
                }
            }
        }

        [Test]
        public void BillingMonthly()
        {
            BillingMonthlyTest billingMonthly = new BillingMonthlyTest();
            billingMonthly.billingMonthlyTestPage(getDriver());
        }

       
        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData(getDataParser().extractDataLoginCredentials("userName"),
                                          getDataParser().extractDataLoginCredentials("password"),
                                          getDataParser().extractDataLoginCredentials("adminUserName"),
                                          getDataParser().extractDataLoginCredentials("adminPassword"),
                                          getDataParser().extractDataLoginCredentials("LoginAs"));
        }
    }
}
