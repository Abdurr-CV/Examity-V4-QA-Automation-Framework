using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using PortalApplicationFramework.Utilities;
using System;

namespace PortalApplicationFramework
{
    class ProctorUtilizationReportMonthlyTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ProctorUtilizationReportMonthlyTestPage(IWebDriver driver)

        {
            string LoginpageUrl = getDataParser().extractDataLoginCredentials("LoginpageUrl");
            string reportTab = getDataParser().extractDataLoginCredentials("reportTab");
            string expProctor = getDataParser().extractDataLoginCredentials("expProctor");
            string expMonth = getDataParser().extractDataMonthlyReportsDateSelection("expMonth");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");

            ProctorUtilizationReportMonthlyPage proctorUtilizationReportMonthlyPage = new ProctorUtilizationReportMonthlyPage(driver);
            proctorUtilizationReportMonthlyPage.navigateToProctorUtilizationReportMonthlyPage(reportTab, LoginpageUrl);
            int x = Int32.Parse(expProctor);
            proctorUtilizationReportMonthlyPage.selectProctorDropdown(x);
            proctorUtilizationReportMonthlyPage.selectMonthDropdown(expMonth);
            proctorUtilizationReportMonthlyPage.selectYearDropdown(expYear);
            proctorUtilizationReportMonthlyPage.selectSearch();
        }
    }
}
