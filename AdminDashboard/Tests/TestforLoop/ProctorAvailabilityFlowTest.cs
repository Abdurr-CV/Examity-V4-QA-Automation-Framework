using AdminDashboard.PageObjects;
using AdminDashboard.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AdminDashboard
{
    class ProctorAvailabilityFlowTest : TestBase
    {
        [Test]
        public void ProctorAvailabilityFlowTestPage(IWebDriver driver)
        {
            string ProctorUserName = getDataParser().extractDataLoginCredentials("ProctorUserName");
            string ProctorPassWord = getDataParser().extractDataLoginCredentials("ProctorPassWord");
            string ShiftHour = getDataParser().extractDataLoginCredentials("ShiftHour");

            ProctorAvailabilityFlowPage proctorAvailabilityFlowPage = new ProctorAvailabilityFlowPage(driver);
            proctorAvailabilityFlowPage.ProctorLogin(ProctorUserName,
                                                     ProctorPassWord);
            proctorAvailabilityFlowPage.MyAvailabilityPageComponentAssertion();
            proctorAvailabilityFlowPage.ProctorOperatorFlowSTEP1();
            proctorAvailabilityFlowPage.ProctorOperatorFlowSTEP2(ShiftHour);
            proctorAvailabilityFlowPage.ProctorOperatorFlowSTEP3();
            proctorAvailabilityFlowPage.ProctorOperatorFlowSTEP4();
            proctorAvailabilityFlowPage.ProctorOperatorFlowSTEP5();
            proctorAvailabilityFlowPage.ProctorOperatorFlowSTEP6();
            proctorAvailabilityFlowPage.ProctorOperatorFlowSTEP7();
        }
    }
}
