using NUnit.Framework;
using OpenQA.Selenium;
using PortalApplicationFramework.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalApplicationFramework
{
    class ProctorUtilizationReportMonthlyTest : TestBase
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        public void ProctorUtilizationReportMonthlyTestPage(IWebDriver driver)

        {
            string expProctor = getDataParser().extractDataLoginCredentials("expProctor");
            string expMonth = getDataParser().extractDataMonthlyReportsDateSelection("expMonth");
            string expYear = getDataParser().extractDataMonthlyReportsDateSelection("expYear");
            string userName = getDataParser().extractDataLoginCredentials("userName");
            string password = getDataParser().extractDataLoginCredentials("password");
            string adminUserName = getDataParser().extractDataLoginCredentials("adminUserName");
            string adminPassword = getDataParser().extractDataLoginCredentials("adminPassword");
            string LoginAs = getDataParser().extractDataLoginCredentials("LoginAs");

            ProctorUtilizationReportMonthlyPage proctorUtilizationReportMonthlyPage = new ProctorUtilizationReportMonthlyPage(driver);
            proctorUtilizationReportMonthlyPage.navigateToProctorUtilizationReportMonthlyPage(userName, password, adminUserName, adminPassword, LoginAs);
            int x = Int32.Parse(expProctor);
            proctorUtilizationReportMonthlyPage.selectProctorDropdown(x);
            proctorUtilizationReportMonthlyPage.selectMonthDropdown(expMonth);
            proctorUtilizationReportMonthlyPage.selectYearDropdown(expYear);
            proctorUtilizationReportMonthlyPage.selectSearch();
        }
    }
}
