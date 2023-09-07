using AdminDashboard.PageObjects;
using AdminDashboard.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AdminDashboard
{
    class WFMPortalTest : TestBase
    {
        [Test]
        public void WFMPortalTestPage(IWebDriver driver)
        {
            string WFMUsername = getDataParser().extractDataLoginCredentials(("WFMUsername"));
            string WFMPassword = getDataParser().extractDataLoginCredentials("WFMPassword");

            WFMPortalPage wFMPortalPage = new WFMPortalPage(driver);
            wFMPortalPage.LoginAsWFM(WFMUsername,
                                     WFMPassword);
            wFMPortalPage.AssignProctor();
            wFMPortalPage.FlowOfStudentAndProctor();
        }
    }
}
