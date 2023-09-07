using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;

namespace PortalApplicationFramework
{
    class ProctorUtilizationReportTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ProctorUtilizationReportTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expProctor = getDataParser().extractDataLoginCredentials("expProctor");
            string expMonth = getDataParser().extractDataMonthlyReportsDateSelection("expMonth");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string expError = getDataParser().extractDataLoginCredentials("expError");
            string email = getDataParser().extractDataLoginCredentials("email");

            ProctorUtilizationReportPage proctorUtilizationReportPage = new ProctorUtilizationReportPage(driver);
            proctorUtilizationReportPage.navigateToProctorUtilizationReportPage(reportTab, LoginpageUrl);
            int x = Int32.Parse(expProctor);
            proctorUtilizationReportPage.selectProctorDropdown(x);
            proctorUtilizationReportPage.selectMonthDropdown(expMonth);
            proctorUtilizationReportPage.selectYearDropdown(expYear);
            proctorUtilizationReportPage.selectSearch(expError, email, reportTab);
        }
    }
}
